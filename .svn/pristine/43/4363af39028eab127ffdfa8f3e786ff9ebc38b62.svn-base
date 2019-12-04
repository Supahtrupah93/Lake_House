using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionColliderManager : AbstractBehaviour
{
    public GameObject[] actionColliders;
    /*
    public Collider2D colliderLeft;
    public Collider2D colliderRight;
    public Collider2D colliderUp;
    public Collider2D colliderDown;
    */
    [HideInInspector]
    public GameObject activeBox = null;
    [HideInInspector]
    public Collider2D activeCollider;
    private int turnDirection;

    
    void Start()
    {
       
    }

    
    void Update()
    {
        foreach (var input in inputButtons)
        {
            // prosledjujem metodi GetButtonValue key tipa Button iz liste inputbuttons
            if (inputState.GetButtonValue(input))
            {
                // ako je value true, prosledi taj clan enuma kastovan u int (od 0 do 3) 
                //u vrednost turn direction koju kasnije setujemo u AnimState za kontrolu animacije

                turnDirection = (int)input;
            }

        }

        foreach (GameObject collider in actionColliders)
        {
            if (actionColliders[turnDirection] == collider)
            {
                collider.GetComponent<BoxCollider2D>().enabled = true;
                activeBox = collider;
                activeCollider = activeBox.GetComponent<BoxCollider2D>();
               
            }
            else
            {
                collider.GetComponent<BoxCollider2D>().enabled = false;
            }

            
        }


    }

    public Collider2D GetActiveCollider()
    {
        
        return activeCollider;
    }

    public GameObject GetActiveGameObject()
    {

        return activeBox;
    }

}
