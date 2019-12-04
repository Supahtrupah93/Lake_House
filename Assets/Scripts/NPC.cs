using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public QuestManager qm;
    public string NPCname;
    public List<Quest> quests; // list of quests the NPC has, in order

    public void Awake()
    {
        qm = FindObjectOfType<QuestManager>();
        foreach (var item in GetComponentsInChildren<Quest>())
        {
            quests.Add(item);
            Debug.Log(quests.Count);
        }
    }

    public void TrySolveQuests() // sendes player inqury to the quests
    {
        foreach (var q in quests)
        {
            if (q.status == QuestState.Unlocked) // solves first availible quest and then breaks
            {
                q.TrySolve();
                break;
            }
        }
    }
}
