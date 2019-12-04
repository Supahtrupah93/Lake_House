using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class AreaTransition : AbstractBehaviour
{   
    
    public GameObject player; // for checking player stats, toggling scripts, and animation
    [HideInInspector]
    public PlayerStats playerStats;
    
    public CameraManager camManager;
    public Camera mainCamera; // for FTB and FFB methods

    public GameObject gateA; // Gate pair for transform and colision
    public Areas areaA;
    public GameObject gateB; // Gate pairfor transform and colision
    public Areas areaB;
    public GameObject destination;

    public float transitionTime; // time to wait before transitioning, also time to wait before returning controll to player
    public float camAdjustmentTime;

    public bool isEntering = false;
    public bool isExiting = false;
    public Animator animator;
    public float areaTransitionTime = 0.1f;
    [HideInInspector]
    public int direction;
   
    

    protected override void Awake()
    {
        // drop player object and find all scripts necessary and add them to the list of togglescripts
        disableScripts = new MonoBehaviour[4]; //fixed length for no reason... change this ******** Change**********
        disableScripts[0] = player.GetComponent<WalkAction>();
        disableScripts[1] = player.GetComponent<TurnAction>();
        disableScripts[2] = player.GetComponent<InteractAction>();
        disableScripts[3] = player.GetComponent<AnimationManager>();
        camManager = FindObjectOfType<CameraManager>();
        camManager.SetNewCoordinates();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
       
    }

    public void Start()
    {

        playerStats = player.GetComponent<PlayerStats>();
        transitionTime = mainCamera.GetComponent<CameraMovement>().time; // waits for FTB to finish -- tied to fade to black timing
        gateA = gameObject.transform.GetChild(0).gameObject;
        gateB = gameObject.transform.GetChild(1).gameObject; // there are only 2 children
        camManager.SetNewCoordinates();
        mainCamera.GetComponent<CameraMovement>().FadeFromBlack();
    }

    private void Update()
    { // ovde lerpujemo po x i y koordinatama, potrebrno odraditi da se lerpuje samo po x/y koordinatama respektivno 
        if (isEntering)
        {
            Debug.Log("Enetring  " + direction);
            if (direction == 1 || direction == 2) // means its going left or right // along the X axis
            {
                player.transform.position = new Vector2(Mathf.MoveTowards(player.transform.position.x, destination.transform.position.x, areaTransitionTime), player.transform.position.y);
            }
            else if (direction == 3 || direction == 4) // means its going up or down // along the Y axis
            {
                player.transform.position = new Vector2(player.transform.position.x, Mathf.MoveTowards(player.transform.position.y, destination.transform.position.y, areaTransitionTime));
            }
        }
        
        if (isExiting) // case for lerping while exiting the scene, should check destination, lerp towards other objects spawn point
        {
            GameObject exitingArea = null;
            if (destination == gateA)
            {
                exitingArea = gateB;
            }
            else if (destination == gateB)
            {
                exitingArea = gateA;
            }

            if (direction == 1 || direction == 2) // means its going left or right // along the X axis
            {
                player.transform.position = new Vector2(Mathf.MoveTowards(player.transform.position.x, exitingArea.transform.Find("SpawnPoint").position.x, (float)areaTransitionTime), player.transform.position.y);
            }
            else if (direction == 3 || direction == 4) // means its going up or down // along the Y axis
            {
                player.transform.position = new Vector2(player.transform.position.x, Mathf.MoveTowards(player.transform.position.y, exitingArea.transform.Find("SpawnPoint").position.y, (float)areaTransitionTime));
            }
            
        }
    }
     void  OnTriggerEnter2D(Collider2D collision)
    {
        
        //does not check for type of object
        //camManager.SetNewCoordinates();
        if (collision.tag == "Player")
        {

            mainCamera.GetComponent<CameraMovement>().FadeToBlack();
            //player.GetComponent<CircleCollider2D>().enabled = false;
            
            //Need to checki where to send
            if (playerStats.activeArea == areaA) // sets player area to possible areas, camera later follows
            {
                destination = gateB;
            
            }
            else if (playerStats.activeArea == areaB)
            {
                destination = gateA;
            }
            CheckMoveDirection();
            ToggleScripts(false);
            StopAllCoroutines();
            StartCoroutine("TransferToLocation", destination);
        }
        
    }

    public void CheckMoveDirection()

    {
        // refaktorisati ovaj metod, sranje je
        //Hard coding values here since there are only 4 directions and player is walking
        
        if (player.transform.position.x < destination.transform.position.x - 10) // destinacija je desno
        {
            animator.SetInteger("AnimState",2);
            player.GetComponent<TurnAction>().walkDirection = 2;
        }
        if (player.transform.position.x > destination.transform.position.x + 10) //destinacija je levo
        {
            animator.SetInteger("AnimState", 1);
            player.GetComponent<TurnAction>().walkDirection = 1;
        }
        if (player.transform.position.y > destination.transform.position.y + 10) //destinacija je dole
        {
            animator.SetInteger("AnimState", 4);
            player.GetComponent<TurnAction>().walkDirection = 4;
        }
        if (player.transform.position.y < destination.transform.position.y - 10) //destinacija je gore
        {
            animator.SetInteger("AnimState", 3);
            player.GetComponent<TurnAction>().walkDirection = 3;
        }
        direction = player.GetComponent<TurnAction>().walkDirection;
        Debug.Log(direction);

        

    }

    IEnumerator TransferToLocation(GameObject location)
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        
        isExiting = true;
        yield return new WaitForSeconds(transitionTime);
        isExiting = false;
        player.transform.position = location.transform.Find("SpawnPoint").transform.position; // ovo je spawn, nije lerpovanje pri izlazu
        
        
        yield return new WaitForSeconds(camAdjustmentTime);
        camManager.SetNewCoordinates();
        player.GetComponent<CircleCollider2D>().enabled = false;
        isEntering = true;
        mainCamera.GetComponent<CameraMovement>().FadeFromBlack();

        yield return new WaitForSeconds(transitionTime);
        player.GetComponent<CircleCollider2D>().enabled = true;
        isEntering = false;
        ToggleScripts(enabled);
        
    } 
}
