using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// a class that manages player behaviour related to interaction
public class InteractAction : AbstractBehaviour
{

    private ActionColliderManager ColManager;
    [HideInInspector]
    public InventoryManager inventoryManager;
    public TextManager textManager;
    public bool canInteract ;
    public bool isInteracting;
    public bool isPickingUp ;
    public bool isDropping ;
    public bool isTalking;
    
    public string gameObjectTag;
    [HideInInspector]
    public GameObject otherObject;
    public int promptTracker;
    public bool isReleased = true;// ovo mora da se promeni u input manageru da nema mashovanja a i b dugmica

    void Start()
    {
        canInteract = false;
        isInteracting = false;
        isPickingUp = false;
        isDropping = false;
        isTalking = false;
        textManager = FindObjectOfType<TextManager>();
        ColManager = GetComponent<ActionColliderManager>();
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }
    private void Update()
    {
        
        if (!isPickingUp & !canInteract & !isInteracting & !isDropping &!isTalking) // dropping check/ non interaction
        {
            if (inputState.GetButtonValue(inputButtons[0]) & isReleased)
            {
                Debug.Log("nothing to interact with");
                promptTracker = 0;

            }
            if (inputState.GetButtonValue(inputButtons[1]) & isReleased)
            { //WE ARE TRYING TO DROP
                if (inventoryManager.GetHandItem() == null & inventoryManager.GetPocketItem() == null)
                { // NOTHING TO DROP
                    promptTracker = 0;

                }
                else
                {// SOMETHING TO DR0P
                    promptTracker = 1;
                }
                otherObject = this.gameObject;
                otherObject.GetComponent<TextTrigger>().TriggerText(promptTracker);
                
                isDropping = true;
                ToggleScripts(false);
                canInteract = false;
                
            }
            CheckIfReleased();
        }

        if (canInteract)// check for everything else
        {
            if (inputState.GetButtonValue(inputButtons[0]) & isReleased)
            {
                otherObject = ColManager.GetActiveCollider().GetComponent<BoxInteraction>().otherObject.gameObject; 
                // gets collision information from the active colider
                if (otherObject.tag == "PickUp")
                {
                    isPickingUp = true;
                    ToggleScripts(false);
                    canInteract = false;
                    promptTracker = 0;
                }
                else if (otherObject.tag == "NPC" )
                {
                    
                    Debug.Log("Interactiong with NPC, solving quests");
                    otherObject.GetComponent<NPC>().TrySolveQuests(); //we are only solving quests for now
                    this.GetComponent<PlayerStats>().talkedTo.Add(otherObject);
                    isInteracting = true;
                    promptTracker = 0;
                    Debug.Log("You are now interacting with this game object, pres A for cont and B for Exir prompt");
                    ToggleScripts(false);
                    canInteract = false;
                }
                else
                {
                    isInteracting = true;
                    promptTracker = 0;
                    Debug.Log("You are now interacting with this game object, pres A for cont and B for Exir prompt");
                    ToggleScripts(false);
                    canInteract = false;
                }
             
            }
        
            CheckIfReleased();
            // missling check for pickup
        }
        if (isInteracting)
        {
            switch (promptTracker)
            {
                case 0:
                    

                    if (inputState.GetButtonValue(inputButtons[0]) & isReleased)
                    {
                        promptTracker = 1;
                        Debug.Log("This is cont, you have pressed A; pres any button to exit");
                    }
                    else if (inputState.GetButtonValue(inputButtons[1]) & isReleased)
                    
                    {
                        promptTracker = 2;
                    }
                    break;
                case 1:
                    
                    if (inputState.GetButtonValue(inputButtons[0]) & isReleased)
                    {
                        promptTracker = 2;
                    }
                    else if (inputState.GetButtonValue(inputButtons[1]) & isReleased)

                    {
                        promptTracker = 2;
                        Debug.Log("This is the exit message, press any button to resume controll");
                    }
                    break;
                case 2:
                    
                    if ((inputState.GetButtonValue(inputButtons[0]) || inputState.GetButtonValue(inputButtons[1])) &isReleased)
                    {
                        ToggleScripts(true);
                        promptTracker = 0;
                        isInteracting = false;
                    }
                    break;
                default:
                    break;
            }

            CheckIfReleased();
        }
        if (isPickingUp)
        {
            switch (promptTracker)
            {
                case 0:
                    Debug.Log("Picking up object, pres A to hold in hand, press B to refuse");

                    if (inputState.GetButtonValue(inputButtons[0]) & isReleased)
                    {
                        if (inventoryManager.GetHandItem() == null)
                        {
                            inventoryManager.SetHandItem(otherObject); // this sets the hand item
                            promptTracker = 0;
                            isPickingUp = false;
                            ToggleScripts(true);
                        }
                        else if (inventoryManager.GetHandItem() != null & inventoryManager.GetPocketItem() == null)
                        {
                            promptTracker = 1;
                        }
                        else if (inventoryManager.GetHandItem() != null & inventoryManager.GetPocketItem() != null)
                        {
                            promptTracker = 2;
                        }
                    }
                    else if (inputState.GetButtonValue(inputButtons[1]) & isReleased)

                    {
                        promptTracker = 0;
                        isPickingUp = false;
                        ToggleScripts(true);
                    }

                    break;


                case 1:
                    Debug.Log("I dont have space in my hand, send to pocket instead? A for yes, B for No");
                    if (inputState.GetButtonValue(inputButtons[0]) & isReleased)
                    {
                        if (inventoryManager.GetPocketItem() == null)
                        {
                            inventoryManager.SetPocketItem(otherObject);
                            promptTracker = 0;
                            isPickingUp = false;
                            ToggleScripts(true);
                        }
                        else
                        {
                            Debug.Log("There has been an error");
                            promptTracker = 0;
                            isPickingUp = false;
                            ToggleScripts(true);
                        }
                    }
                    else if (inputState.GetButtonValue(inputButtons[1]) & isReleased)
                    {
                        promptTracker = 0;
                        isPickingUp = false;
                        ToggleScripts(true);
                    }
                    break;


                case 2:
                    Debug.Log("inventory full! Replace item in hand? A for yes, B for No");
                    if (inputState.GetButtonValue(inputButtons[0]) & isReleased) // replaces hand item
                    {
                        inventoryManager.DropHandItem();
                        inventoryManager.SetHandItem(otherObject);
                        promptTracker = 0;
                        isPickingUp = false;
                        ToggleScripts(true);

                    }
                    else if (inputState.GetButtonValue(inputButtons[1]) & isReleased)
                    {
                        promptTracker = 0;
                        isPickingUp = false;
                        ToggleScripts(true);
                    }
                    break;

                default:
                    break;

            }
            CheckIfReleased();
        }
        if (isDropping)
        {
            
            switch (promptTracker)
            {
                case 0:
                   
                        // nothing to drop, end inventory
                        if (inputState.GetButtonValue(inputButtons[0]) & isReleased)
                        {
                            isDropping = false;
                            promptTracker = 0;
                            ToggleScripts(true);
                            textManager.EndDialogue();

                        }
                        else if (inputState.GetButtonValue(inputButtons[1]) & isReleased)
                        {
                            isDropping = false;
                            promptTracker = 0;
                            ToggleScripts(true);
                            textManager.EndDialogue();
                        }

                    break;
                case 1:
                     // THERE IS SOMETHING TO DROP, DO YOU WISH TO DROP
                    if (inputState.GetButtonValue(inputButtons[0]) & isReleased)
                    {
                        promptTracker = 2;
                        textManager.DisplayNextSentence(promptTracker);
                    }
                    else if (inputState.GetButtonValue(inputButtons[1]) & isReleased)

                    {
                        isDropping = false;
                        promptTracker = 0;
                        ToggleScripts(true);
                        textManager.EndDialogue();
                    }
                    break;

                case 2:
                    Debug.Log("To drop item from hand press A, from pocket press B");
                    if (inputState.GetButtonValue(inputButtons[0]) & isReleased) // A button
                    {
                        if (inventoryManager.GetHandItem() != null)
                        { // We dropped from hand
                            inventoryManager.DropHandItem();
                            isDropping = false;
                            promptTracker = 0;
                            ToggleScripts(true);
                            textManager.EndDialogue();

                        }
                        
                        else if (inventoryManager.GetHandItem() == null & inventoryManager.GetPocketItem() != null)
                        { // Nothing in hand, something in pocket
                            promptTracker = 3;
                            textManager.DisplayNextSentence(promptTracker);
                        }
                        
                        
                    }
                    else if (inputState.GetButtonValue(inputButtons[1]) & isReleased) // B button

                    {  //WE WANT TO DROP FROM POCKET
                        if (inventoryManager.GetPocketItem() != null)
                        {
                            inventoryManager.DropPocketItem();
                            isDropping = false;
                            promptTracker = 0;
                            ToggleScripts(true);
                            textManager.EndDialogue();

                        }
                       
                        else if (inventoryManager.GetPocketItem() == null & inventoryManager.GetHandItem() != null)
                        {// WE HAVE NOTHING IN POCKET
                            promptTracker = 4;
                            textManager.DisplayNextSentence(promptTracker);
                        }
                    }
                    break;

                case 3: // if hand was empty but pocket wasnt
                    
                     Debug.Log("No item in hand, drop item from pocket instead! A for yes, B for no");
                        if (inputState.GetButtonValue(inputButtons[0]) & isReleased)
                        {
                            inventoryManager.DropPocketItem();
                            isDropping = false;
                            promptTracker = 0;
                            ToggleScripts(true);
                            textManager.EndDialogue();
                        }
                        else if (inputState.GetButtonValue(inputButtons[1]) & isReleased)
                        {
                            isDropping = false;
                            promptTracker = 0;
                            ToggleScripts(true);
                            textManager.EndDialogue();
                        }
                   
                    break;

                case 4: //pocket is empty but hand isnt
                      Debug.Log("No item in pocket, drop item from hand instead! A for yes, B for no");
                        if (inputState.GetButtonValue(inputButtons[0]) & isReleased)
                        {
                            inventoryManager.DropHandItem();
                            isDropping = false;
                            promptTracker = 0;
                            ToggleScripts(true);
                            textManager.EndDialogue();
                        }
                        else if (inputState.GetButtonValue(inputButtons[1]) & isReleased)
                        {
                            isDropping = false;
                            promptTracker = 0;
                            ToggleScripts(true);
                            textManager.EndDialogue();
                        }
                   
                    break;
                default:
                    break;
            }

            CheckIfReleased();
        }
        if (isTalking)// not case based yet but probably will be
        {
            switch (promptTracker)
            {
               
                case 0:// First Sentence

                    if (inputState.GetButtonValue(inputButtons[0]) && isReleased)
                    {
                        promptTracker = 1;
                        textManager.DisplayNextSentence(promptTracker);

                    }

                    else if (inputState.GetButtonValue(inputButtons[1]) && isReleased)
                    {
                        isTalking = false;
                        ToggleScripts(true);
                        promptTracker = 0;
                        textManager.EndDialogue();
                    }
                    break;
                case 1:
                    if (inputState.GetButtonValue(inputButtons[0]) && isReleased)
                    {
                        promptTracker = 2;
                        textManager.DisplayNextSentence(promptTracker);

                    }

                    else if (inputState.GetButtonValue(inputButtons[1]) && isReleased)
                    {
                        isTalking = false;
                        ToggleScripts(true);
                        promptTracker = 0;
                        textManager.EndDialogue();
                    }
                    break;
                case 2:
                    if (inputState.GetButtonValue(inputButtons[0]) && isReleased)
                    {
                        isTalking = false;
                        ToggleScripts(true);
                        promptTracker = 0;
                        textManager.EndDialogue();

                    }

                    else if (inputState.GetButtonValue(inputButtons[1]) && isReleased)
                    {
                        isTalking = false;
                        ToggleScripts(true);
                        promptTracker = 0;
                        textManager.EndDialogue();
                    }
                    break;
            }
           

            CheckIfReleased();
        }

        CheckIfReleased();
    }

    public void CheckIfReleased() //checks input continuosly to see wether the player has released the button
    {
        if (isReleased & (inputState.GetButtonValue(inputButtons[0]) || inputState.GetButtonValue(inputButtons[1])))
        {
            isReleased = !isReleased;
        }
        if (!isReleased & !(inputState.GetButtonValue(inputButtons[0]) || inputState.GetButtonValue(inputButtons[1])))
        {
            isReleased = !isReleased;
        }
    }
    
}
