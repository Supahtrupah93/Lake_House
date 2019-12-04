using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a class that with box triggers for interaction
public class BoxInteraction : MonoBehaviour
{
    private Collider2D boxCollider;
    private InteractAction interactAction;
    [HideInInspector]
    public Collider2D otherObject = null;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        interactAction = GetComponentInParent<InteractAction>();
    }

    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D col)
    {
       
        // This sets can interact to true wihtou regarding wether the object can interact or not
        otherObject = col;
        //Debug.Log(otherObject);
        interactAction.canInteract = true;
        
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        //Debug.Log("No longer Collding with   "+col.name);
        interactAction.canInteract = false;
        otherObject = null;
    }

}
