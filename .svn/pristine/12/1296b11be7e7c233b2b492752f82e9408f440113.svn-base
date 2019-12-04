using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState
{
    public bool value; 
    public bool released;
}

public enum Directions
{
    Right = 1, Left = -1

}
public class InputState : MonoBehaviour
{
    
   
    private Rigidbody2D rb;
    private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void SetButtonValue(Buttons key, bool value)
    {
        if (!buttonStates.ContainsKey(key))
            buttonStates.Add(key, new ButtonState());

        ButtonState state = buttonStates[key];
  
        state.value = value;
       
    }

    public bool GetButtonValue(Buttons key)
    {

        if (buttonStates.ContainsKey(key))
            return buttonStates[key].value;
        else
            return false;
    }
   

}
