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

        for (int i = 0; i < currentQuest.questStages[activeStage].dialogue.dialogues.Length; i++) {

            CheckforActor(currentQuest.questStages[activeStage].dialogue, i);

            yield return new WaitUntil(() => responseTrigger);
            responseTrigger = false;
        }

        TextPanelManager.instance.EndDialogue();
        GameManager.instance.playerActive = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CheckforActor(Dialogue dialogue, int index) {

        if (dialogue.dialogues[index].actor == ACTORS.player) {
            switch (dialogue.dialogues[index].line.Length) {
                case 1:
                    TextPanelManager.instance.ShowTextPanel("Player: " + dialogue.dialogues[index].line[0]);
                    break;
                case 2:
                    TextPanelManager.instance.ShowPanelOptionButtons(dialogue.dialogues[index].line);
                    break;
            }
        }
        else {
            if (dialogue.dialogues[index].line[anwserIndex] == "") {
                TriggerAnswer(); //Maybe nie dziala
                return ;
            }

            TextPanelManager.instance.ShowTextPanel($"{dialogue.dialogues[index].actor}: " + dialogue.dialogues[index].line[anwserIndex]);
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
