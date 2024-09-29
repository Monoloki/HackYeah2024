using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
    private bool responseTrigger = false;
    private int anwserIndex = 0;


    public void TriggerAnswer(int index = 0) {
        responseTrigger = true;
        anwserIndex = index;
    }


    public void StartInteraction(Quest currentQuest) {
        Cursor.lockState = CursorLockMode.None;
        GameManager.instance.playerActive = false;
        StartCoroutine(QuestCoroutine(currentQuest));
    }

    public bool CanInteractNPC(Quest currentQuest) {
        if (CheckActiveStage(currentQuest) != currentQuest.questProgress) {
            return false;
        }
        else {
            return true;
        }
    }

    public bool CanInteractObject(Quest currentQuest, int objectIndex) {
        if (CheckActiveStage(currentQuest) == objectIndex) {
            return true;
        }
        else {
            return false;
        }

    }


    public void SetProgress(Quest currentQuest, int objectIndex) {
        int activeStage = CheckActiveStage(currentQuest);
        currentQuest.questStages[activeStage - 1].objective += 1; //TODO: niebiezpieczne -1

        int progress = currentQuest.questStages[activeStage - 1].objective;
        int max = currentQuest.questStages[activeStage - 1].objectiveTarget;

        PlayerUiManager.instance.ShowProgress(progress,max);

        if (progress == max) {
            currentQuest.questProgress += 1;
        }
    }


    private IEnumerator QuestCoroutine(Quest currentQuest) {

        TextPanelManager.instance.StartDialogue();

        int activeStage = CheckActiveStage(currentQuest);

        int linesAmount = currentQuest.questStages[activeStage].dialogue.dialogues.Length;


        for (int i = 0; i < linesAmount; i++) {

            CheckforActor(currentQuest.questStages[activeStage], i, linesAmount);

            yield return new WaitUntil(() => responseTrigger);
            responseTrigger = false;
        }

        

        TextPanelManager.instance.EndDialogue();

        if (currentQuest.done) {
            GameManager.instance.quests++;
        }


        CutSceneManager.instance.ResetCamera();
        GameManager.instance.playerActive = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CheckforActor(QuestStage stage, int index, int maxIndex) {

        if (stage.dialogue.dialogues[index].actor == ACTORS.Tink) {
            switch (stage.dialogue.dialogues[index].line.Length) {
                case 1:
                    TextPanelManager.instance.ShowTextPanel("Tink: " + stage.dialogue.dialogues[index].line[0]);
                    break;
                case 2:
                    TextPanelManager.instance.ShowPanelOptionButtons(stage.dialogue.dialogues[index].line);
                    break;
            }
        }
        else {
            if (stage.dialogue.dialogues[index].line[anwserIndex] == "") {
                TriggerAnswer();
                return ;
            }


            if (index == maxIndex - 1) {
                stage.done = true; //TODO: niebiezpieczne
            }
            
            TextPanelManager.instance.ShowTextPanel($"{stage.dialogue.dialogues[index].actor}: " + stage.dialogue.dialogues[index].line[anwserIndex]);
            
        }

    }

    private int CheckActiveStage(Quest currentQuest) {
        int index = 0;
        for (int i = 0; i < currentQuest.questStages.Length; i++) {
            if (currentQuest.questStages[i].done) {
                index = i + 1;
            }
            else {
                return index;
            }
        }
        Debug.Log("ERROR ZLE ZROBIONY SO DLA QUESTA ALBO LINIE DIALOGOWE");
        //musi byc tyle samo odpowiedzi co opcji dialogowcyh
        // "" konczy rozmowe bez progressu

        return -1;
    }
}
