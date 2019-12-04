using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject pocketStorage;
    public GameObject pocketItem;
    [HideInInspector]
    public GameObject handStorage;
    public GameObject handItem;

    public GameObject[] gameObjects;

    public void Awake()
    {
        pocketStorage = GameObject.Find("PocketStorageSpace");
        handStorage = GameObject.Find("HandStorageSpace");

        gameObjects = GameObject.FindGameObjectsWithTag("PickUp");
    }


    public GameObject GetPocketItem()
    {
        return pocketItem;
    }

    public void SetPocketItem(GameObject item)
    {
        item.transform.position = pocketStorage.transform.position;
        pocketItem = item;
    }

    public GameObject GetHandItem()
    {
        return handItem;
    }

    public void SetHandItem(GameObject item)
    {
        item.transform.position = handStorage.transform.position;
        handItem = item;

    }

    public void DropHandItem()
    {
        handItem.transform.position = GameObject.Find("Player").transform.position;
        handItem.GetComponent<SortingOrder>().SetSortingOrder();
        handItem = null;
    }

    public void DropPocketItem()
    {
        pocketItem.transform.position = GameObject.Find("Player").transform.position;
        pocketItem.GetComponent<SortingOrder>().SetSortingOrder();
        pocketItem = null;
    }
}
