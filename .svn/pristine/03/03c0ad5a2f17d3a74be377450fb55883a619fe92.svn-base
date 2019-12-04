using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{


    private SpriteRenderer sr;
    public float posY;
    public bool isDynamic = false;
    public bool alwaysUnderneath = false;
    public float offset = 100;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        posY = transform.position.y;
        SetSortingOrder();
    }

    void Update()
    {
        if (isDynamic)
        {
            posY = transform.position.y;
            SetSortingOrder();
        }

       
    }
    public void SetSortingOrder()
    {
     
        if (alwaysUnderneath)
        {
            posY = transform.position.y;
            sr.sortingOrder = (int)(posY * -100 - offset);
        }
        else
        {
            posY = transform.position.y;
            sr.sortingOrder = (int)(posY * -100);
        }
    }
}
