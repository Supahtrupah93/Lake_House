using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState
{
    Locked,
    Unlocked,
    Solved
}

public enum QuestType
{
    TalkTo,
    Item,
    OutsideCondition,
    Time

}

public class Quest : MonoBehaviour // this means i have to instantiate quests as game objects ingame
{
    [HideInInspector]
    public QuestManager qm;
    public QuestCondition condition;
    public string questName; // name of quest
    public Quest[] dependentQuests; // list of quests that depend on this quest
    public ItemText sentences; // dialogue asociated with said quest
    public QuestState status; // status of said quest
    public Quest[] permalockQuests;

    
    void Start()
    {
        condition.pairedQuest = this;
        qm = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrySolve() 
    {
        if (condition.CheckCondition())
        {
            qm.SolveQuest(this);
            Debug.Log("..."+this.name + "...  Has been succesfully solved");
        }
        else
        {
            Debug.Log("..." + this.name + "...  has failed to solve");
        }
        
    }


}
