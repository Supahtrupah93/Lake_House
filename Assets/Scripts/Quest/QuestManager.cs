using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> allQuests;
    public List<Quest> lockedQuests;
    public List<Quest> unlockedQuests;
    public List<Quest> solvedQuests = new List<Quest>();
    public List<Quest> permaLockedQuests = new List<Quest>();
    private void Awake()
    {
        UpdateQuests();
    }

    public void UpdateQuests()
    {
        
            //get all quests from Quest manager
            
            foreach (var item in FindObjectsOfType<Quest>())
            {
                allQuests.Add(item);
            }

            //once this is done, sort items localy
            foreach (var item in allQuests)
            {
                if (item.status == QuestState.Locked)
                {
                    lockedQuests.Add(item);
                }
                else if (item.status == QuestState.Unlocked)
                {
                    unlockedQuests.Add(item);
                }
                else if (item.status == QuestState.Solved)
                {
                    solvedQuests.Add(item);
                }
                else
                {
                    Debug.Log("Error: Wrong quest state");
                }
            }
        
        
    }

    public void UnlockQuest(Quest quest)
    {
        if (permaLockedQuests.Contains(quest))
        {
            Debug.Log("Quest is permalocked");
        }
        else
        {

            // change quest state, move quest state from Locked to unlocked
            quest.status = QuestState.Unlocked;
            lockedQuests.Remove(quest);
            unlockedQuests.Add(quest);
        }
    }
    public void PermalockQuest(Quest quest)
    {// can only lock and unlocked quest, not solved one, and not an already locked one

        if (quest.status == QuestState.Unlocked)
        {
            // change quest state, move quest state from unlocked to locked
            quest.status = QuestState.Locked;
            unlockedQuests.Remove(quest);
            permaLockedQuests.Add(quest);

        }
        else if (quest.status == QuestState.Locked)
        {
            Debug.Log("Quest already Locked");
        }
        else
        {
            Debug.Log("Quest already SolVed");
        }
    }
    public void SolveQuest(Quest quest)
    {   // change quest state, move quest state from unlocked to solved
        quest.status = QuestState.Solved;
        unlockedQuests.Remove(quest);
        solvedQuests.Add(quest);

        foreach (var item in quest.dependentQuests) // also unlocks all dependent quests
        {
            UnlockQuest(item);
        }
    }
    // quests will have methods on them that call these methods when they are being solved, some quests
    // will unlock others, while some quests will lock others if they hadnt been solved yet
    
}
