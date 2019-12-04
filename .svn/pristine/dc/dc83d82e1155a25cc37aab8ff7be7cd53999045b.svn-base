using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public enum Areas
{
    //List of all the areas the player can visit
    Lake,
    GroundFloor,
    UpperFloor,
    Basement,
    NorhternForrest,
    SouthernForrest,


}

public class GameManager : MonoBehaviour
{
    public GameTracker gameTracker;
    public int NumberOfLoops = 0;
    public static GameManager gmInstance;
   

    private void Awake()
    {
        gameTracker = FindObjectOfType<GameTracker>();
        MakeSingleton();
    }
    public void Update()
    {
        /*
        if (Input.GetKeyDown("k"))
        {
            object[] data = { (int)45, "Hello", FindObjectsOfType<GameObject>(), 0.312, FindObjectsOfType<PlayerStats>() };
            
        }*/
    }
    private void MakeSingleton()
    {
        if (gmInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gmInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
