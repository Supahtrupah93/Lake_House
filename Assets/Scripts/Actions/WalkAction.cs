using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAction : AbstractBehaviour
{
    public float speed = 1f;
    public bool isWalking;
    public int diagonalValue; // 0 for null, 1 for left, 2 for right


    void Start()
    {
        inputState = GetComponent<InputState>();
    }

    // Update is called once per frame
    void Update()
    {
        bool left = inputState.GetButtonValue(inputButtons[0]);
        bool right = inputState.GetButtonValue(inputButtons[1]);
        bool up = inputState.GetButtonValue(inputButtons[2]);
        bool down = inputState.GetButtonValue(inputButtons[3]);

        //Debug.Log("==left== " + left + " ==right== " + right + "=== up ===" + up + "=== down ==="+ down);
        if (left || right || up || down)  
        {
            isWalking = true;
            bool diagonal = false;
            // movement is happening
            if ((left&&up) || (left&&down) || (right&&up) || (right && down))
            {
                diagonal = true;
                if (left & up)
                {
                    rb.velocity = new Vector2(Time.deltaTime * -1, Time.deltaTime).normalized * speed;
                    diagonalValue = 1;
                }
                if (left & down)
                {
                    rb.velocity = new Vector2(Time.deltaTime * -1,  Time.deltaTime * -1).normalized * speed;
                    diagonalValue = 1;
                }
                if (right & up)
                {
                    rb.velocity = new Vector2(Time.deltaTime,  Time.deltaTime).normalized * speed;
                    diagonalValue = 2;
                }
                if (right & down)
                {
                    rb.velocity = new Vector2( Time.deltaTime, Time.deltaTime * -1).normalized * speed;
                    diagonalValue = 2;
                }
            }
            else
            {
                diagonal = false;
                diagonalValue = 0;
            }

            if (!diagonal)
            {
                if (left)
                {
                    rb.velocity = new Vector2(Time.deltaTime*-1, 0).normalized * speed;
                }
           
                if (right)
                {
                    rb.velocity = new Vector2(Time.deltaTime, 0).normalized * speed;
                }       
                if (up)
                {
                    rb.velocity = new Vector2(0, Time.deltaTime).normalized*speed;
                }
                if (down)
                {
                    rb.velocity = new Vector2(0, Time.deltaTime * -1).normalized * speed;
                }

            }
            
        }

        else
        {
            isWalking = false;
            rb.velocity = new Vector2(0, 0);
        }

    }

        void OnDisable()
        {
            isWalking = false;
            rb.velocity = new Vector2(0, 0);
        }
}
