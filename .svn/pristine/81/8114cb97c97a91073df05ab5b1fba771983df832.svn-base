using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    public Camera[] cameras;
    public AreaStats[] AreaStats; //all the areas in the game, with their coordinates
    public Camera MainCamera;
    public PlayerStats playerStats;
   
    void Start()
    {
        
    }

    public void SetNewCoordinates()
    {
        
        foreach (var area in AreaStats)
        {
            if (area.Area == playerStats.activeArea)
            {
                MainCamera.GetComponent<CameraMovement>().XMaxValue = area.maxVector.x;
                MainCamera.GetComponent<CameraMovement>().YMaxValue = area.maxVector.y;
                MainCamera.GetComponent<CameraMovement>().XMinValue = area.minVector.x;
                MainCamera.GetComponent<CameraMovement>().YMinValue = area.minVector.y;
            }
        }

    }

    /*
    public Camera SetActiveCamera()      **********old code***************
    {

        Camera activeCamera = null;
        foreach (var camera in cameras)
        {
            
            if (camera.GetComponent<CameraMovement>().area == playerStats.activeArea)
            {
                camera.enabled = true;
                activeCamera = camera;
            }
            else
            {
                camera.enabled = false;
            }
        }
        Debug.Log(activeCamera + "  is the active camera");
        return activeCamera;
    } */
}
