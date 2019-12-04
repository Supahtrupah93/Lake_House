using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialConditionTest : QuestCondition
{

    protected bool SpecialBool;
    //This one test if the player visited the "BasementArea"
    public void Start()
    {
        conditionType = ConditionType.Special; // must be special
    }
    public void Update()
    {// checks every frame until player enters area
        if (ps.activeArea == Areas.Basement && !SpecialBool)
        {
            SpecialBool = true;
        }
    }
    public override bool Special()
    {
        return SpecialBool;
    }
}
