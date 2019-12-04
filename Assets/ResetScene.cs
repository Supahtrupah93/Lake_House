using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    [HideInInspector]
    public GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        Debug.Log(gm.NumberOfLoops);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("Lake");
            gm.NumberOfLoops += 1;

        }
    }
}
