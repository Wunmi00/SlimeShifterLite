using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlimeAbilities : MonoBehaviour
{
    private Vector2 startTouchPos;
    private Vector2 currentTouchPos;
    private Vector2 endTouchPos;
    private Vector2 distance;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;
   
 
    // Update is called once per frame
    void Update()
    {
        playerShrink();
    }

    public void playerShrink()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTouchPos = Input.GetTouch(0).position;
            distance = currentTouchPos - startTouchPos;

            if(!stopTouch)
            {
                if(distance.y < -swipeRange)
                {
                    Debug.Log("Shrinkkk");
                    stopTouch = true;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPos = Input.GetTouch(0).position;
            distance = endTouchPos - startTouchPos;
            if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange)
            {
                Debug.Log("Tap");
            }
        }


    }
}
