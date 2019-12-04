using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ConditionType
{
    TalkTo,
    Item,
    Escort,
    Special
}

public class QuestCondition : MonoBehaviour
{
    public ConditionType conditionType;
    public GameObject target;
    public bool isMet;
    [HideInInspector]
    public Quest pairedQuest; // quest handles this
    public PlayerStats ps;

    public void Awake()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public bool CheckCondition()
    {
        isMet = false; // this resets condition and forces it to recheck
        switch (conditionType)
        {
            case ConditionType.TalkTo:
                isMet = TalkTo();
                break;
            case ConditionType.Item:
                break;
            case ConditionType.Escort:
                break;
            case ConditionType.Special:
                isMet = Special();
                break;
            default:
                break;
        }
        return isMet;
    }

    private bool TalkTo() // requires generic talkto logic, npc name etc etc
    {
        if (ps.talkedTo.Contains(target))
        {
            Debug.Log("TalkTo happened");
            return true;
        }
        else
        {
            Debug.Log("Havent talked with..." + target );
            return false;
        }
        
    }

    public virtual bool Special() // this needs to be overiden in subclasses
    {
        Debug.Log("Special happened");
        return false;
    }
}
