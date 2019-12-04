using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPathMovement : MonoBehaviour
{
    public GameObject[] Points;
    public int currentNode;
    public Vector3 currentNodePosition;
    public GameObject pathUser;
    public bool isLooping = false;
    public bool isPausing = false;
    public bool isPatrolling = false;
    public bool isReverse = false;
    public float speed = 1; //increment speed
    public float Timer;

    
    public virtual void Start()
    {
        CheckNode();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Timer += Time.deltaTime * speed;

        if (pathUser.transform.position != currentNodePosition)
        {
            pathUser.transform.position = Vector3.Lerp(pathUser.transform.position, currentNodePosition, Timer);
        }
        else
        {
            if (isReverse)
            {
                if (currentNode > 0)
                {
                    currentNode--;
                    CheckNode();
                }
                else
                {
                    isReverse = !isReverse;
                    currentNode++;
                    CheckNode();
                }
            }
            else
            {

                if (currentNode < Points.Length -1)
                {
                    currentNode++;
                    CheckNode();
               
                }
                else if (isLooping)
                {
                    currentNode = 0;
                    CheckNode();
                }
                else if (isPatrolling)
                {
                    isReverse = !isReverse;
                    currentNode--;
                    CheckNode();
                    
            
                }   
            }
            
        }
    }

    public void CheckNode()
    {
        Timer = 0;
        currentNodePosition = Points[currentNode].transform.position;
    }
}
