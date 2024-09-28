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

        GameManager.instance.playerActive = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CheckforActor(QuestStage stage, int index, int maxIndex) {

        if (stage.dialogue.dialogues[index].actor == ACTORS.player) {
            switch (stage.dialogue.dialogues[index].line.Length) {
                case 1:
                    TextPanelManager.instance.ShowTextPanel("Player: " + stage.dialogue.dialogues[index].line[0]);
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
        return -1;
    }
}
