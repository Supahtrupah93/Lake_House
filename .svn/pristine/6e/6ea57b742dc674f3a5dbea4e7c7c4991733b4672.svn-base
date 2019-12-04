using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAction : AbstractBehaviour
{
    [HideInInspector]
    public int walkDirection;
    private WalkAction walkAction;
    [HideInInspector]
    public bool[] directionValues;
    void Start()
    {
        inputState = GetComponent<InputState>();
        walkAction = GetComponent<WalkAction>();
    }

    // Update is called once per frame
    void Update()
    {
        


        foreach (var input in inputButtons)
        {
            // prosledjujem metodi GetButtonValue key tipa Button iz liste inputbuttons
            if (inputState.GetButtonValue(input))
            {
                if (walkAction.diagonalValue != 0)
                {
                    if (walkAction.diagonalValue == 1)
                    {
                        walkDirection = (int)inputButtons[0] + 1; //hard coded values according to the order in which they ar assigned in inspector
                    }
                    else if (walkAction.diagonalValue == 2)
                    {
                        walkDirection = (int)inputButtons[1] + 1;
                    }
                }
                // ako je value true, prosledi taj clan enuma kastovan u int (od 0 do 3) 
                //u vrednost turn direction koju kasnije setujemo u AnimState za kontrolu animacije
                else
                walkDirection = (int)input +1;
            }

        }


    }

    
    
}
