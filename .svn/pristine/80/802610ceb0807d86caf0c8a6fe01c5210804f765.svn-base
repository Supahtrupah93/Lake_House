using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buttons
{
    Left,
    Right,
    Up, Down, A, B
  
}

public enum Conditions
{
    GreaterThan,LessThan
}

[System.Serializable]
public class InputAxisState
{
    public string Axisname;
    public float offValue;
    public Buttons button;
    public Conditions condition;
    
    public bool GetInputAxisStateValue()
    {
        float val = Input.GetAxisRaw(Axisname);

        switch (condition)
        {
            case Conditions.GreaterThan:
                return val > offValue;
            case Conditions.LessThan:
                return val < offValue;
            default:
                return false;
        }
    }

}

public class InputManager : MonoBehaviour
{
    public InputAxisState[] inputs;
    public InputState inputState;
    

    
        void Update()
    {
        foreach (var input in inputs)
        {

            inputState.SetButtonValue(input.button, input.GetInputAxisStateValue());
           
        }
    }
}

