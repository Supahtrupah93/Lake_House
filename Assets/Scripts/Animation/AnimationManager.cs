using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    // Class used to manage player animations of any kind
    private Animator anim;
    private TurnAction turnAction;
    private WalkAction walkAction;
    void Start()
    {
        anim = GetComponent<Animator>();
        turnAction = GetComponent<TurnAction>();
        walkAction = GetComponent<WalkAction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkAction.isWalking)
        {
            anim.SetInteger("AnimState", turnAction.walkDirection);
        }
        else
        {
            anim.SetInteger("AnimState", turnAction.walkDirection *-1);
        }
        
    }
}
