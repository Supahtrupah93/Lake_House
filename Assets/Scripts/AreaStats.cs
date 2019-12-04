using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaStats : MonoBehaviour
{
    public Areas Area;
    public GameObject maxCorner;
    public GameObject MinCorner;
    public Vector2 maxVector;
    public Vector2 minVector;
    [HideInInspector]
    public GameObject player;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        maxVector = transform.GetChild(0).position;
        minVector = transform.GetChild(1).position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.activeArea = Area;
       
    }
}
