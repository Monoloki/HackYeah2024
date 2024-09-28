using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 0)]
public class Quest : ScriptableObject
{
    public bool done;
    public int questProgress;
    public QuestStage[] questStages;
    
}

[Serializable]
public class QuestStage {
    public bool done;
    public Dialogue dialogue;
    public int objective;
    public int objectiveTarget;
}

[Serializable]
public class Dialogue {
    public DialogueLine[] dialogues;

}

[Serializable]
public class DialogueLine {
    public string[] line;
    public ACTORS actor;
}

[Serializable]
public enum ACTORS {
    player = 0,
    penguin = 1,

}
