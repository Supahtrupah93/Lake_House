using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialConditionOne : QuestCondition
{
    public bool TestBool;
    // Start is called before the first frame update
    public override bool Special()
    {
        Debug.Log("This is the special condition override");
        if (TestBool)
        {
            return TestBool;

        }
        else
            return TestBool;
    }
}
