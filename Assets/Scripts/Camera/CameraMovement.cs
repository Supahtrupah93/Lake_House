using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Image blackScreen;
    public float time = 3f;
    

    public Vector3 velocity = Vector3.zero;

    public float dragTime = .15f;

    public bool XMaxEnabled = false;
    public float XMaxValue = 0;
    public bool XMinEnabled = false;
    public float XMinValue = 0;
    public bool YMaxEnabled = false;
    public float YMaxValue = 0;
    public bool YMinEnabled = false;
    public float YMinValue = 0;
    
    public static CameraMovement cminstance;


   
    void Awake()
    {
        blackScreen.canvasRenderer.SetAlpha(1f);
        
  
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = target.position;

        //vertical

        if (YMinEnabled & YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(targetPos.y, YMinValue, YMaxValue);
        }
        else if (YMinEnabled)
        {
            targetPos.y = Mathf.Clamp(targetPos.y, YMinValue, targetPos.y);
        }
        else if (YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(targetPos.y, targetPos.y, YMaxValue);
        }

        //horizontal

        if (XMinEnabled & XMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(targetPos.x, XMinValue, XMaxValue);
        }
        else if (XMinEnabled)
        {
            targetPos.x = Mathf.Clamp(targetPos.x, XMinValue, targetPos.x);
        }
        else if (XMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(targetPos.x, targetPos.x, XMaxValue);
        }

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dragTime);
    }
    public void FadeToBlack()
    {
        blackScreen.color = Color.black;
        blackScreen.canvasRenderer.SetAlpha(0.0f);
        blackScreen.CrossFadeAlpha(1.0f, time, false);
    }
    public void FadeFromBlack()
    {
        
        blackScreen.color = Color.black;
        blackScreen.canvasRenderer.SetAlpha(1.0f);
        blackScreen.CrossFadeAlpha(0.0f, time, false);
        
    }
    /*private void MakeSingleton()
    {
        if (cminstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            cminstance = this;
            DontDestroyOnLoad(gameObject);
        }
    } */
}
