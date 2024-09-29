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
    Tink = 0,
    Julia = 1,
    Agnes = 2,
    Gregory = 3,
    Leonard = 4,
    Anne = 5,
    Jake = 6,
}
