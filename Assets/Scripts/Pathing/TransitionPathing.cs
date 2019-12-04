using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPathing : AbstractPathMovement
{
    // Start is called before the first frame update
    public override void Start()
    {

        base.Start();
        //pathUser = GameObject.FindGameObjectWithTag("Player");
        currentNode = 0;
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
