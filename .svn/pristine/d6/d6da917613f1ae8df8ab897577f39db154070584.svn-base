using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBehaviour : MonoBehaviour
{
    public Buttons[] inputButtons;
    protected InputState inputState;
    protected Rigidbody2D rb;
    //protected CollisionState collisionState;
    public MonoBehaviour[] disableScripts;

    protected virtual void Awake()
    {
        inputState = GetComponent<InputState>();
        rb = GetComponent<Rigidbody2D>();
        //collisionState = GetComponent<CollisionState>();
    }
    protected virtual void ToggleScripts(bool value)
    {
        foreach (var script in disableScripts)
        {
            script.enabled = value;
        }
    }

    

}
