using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : Singleton<SwipeDetection>
{
    [SerializeField]
    private float minDistance = 0.2f;
    [SerializeField]
    private float maxTime = 1f;
    [SerializeField]
    private float dirThreshold = 0.9f;

    private Input_Manager inputManager;
    private Player_Controller player;


    private Vector2 startPos;
    private float startTime;
    private Vector2 endPos;
    private float endTime;

    //private Vector3 scale;

    private void Awake()
    {
        inputManager = Input_Manager.Instance;
        //player = GetComponent<Player_Controller>();
        //scale = new Vector3(5f, 5f, 0f);
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStarted;
        inputManager.OnEndTouch += SwipeEnded;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStarted;
        inputManager.OnEndTouch -= SwipeEnded;
    }

    private void SwipeStarted(Vector2 position, float time)
    {
        startPos = position;
        startTime = time;
    }

    private void SwipeEnded(Vector2 position, float time)
    {
        endPos = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector2.Distance(startPos, endPos) >= minDistance && (endTime - startTime) <= maxTime)
        {
            Debug.Log("Swipe Detected");
            Debug.DrawLine(startPos, endPos, Color.red, 5f);
            Vector2 direction = endPos - startPos;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;

            slimeAbilities(direction2D);
        }
    }

    private void slimeAbilities(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > dirThreshold)
        {
            Debug.Log("Stretching Ability");
            //player.transform.localScale += new Vector3(5f, 5f, 1f);
            //player.transform.localScale += scale;

        }
        else if (Vector2.Dot(Vector2.down, direction) > dirThreshold)
        {
            Debug.Log("Shrinking Ability");
            //player.transform.localScale += new Vector3(5f, 5f, 1f);
            //player.transform.localScale += scale;

        }

        else if (Vector2.Dot(Vector2.right , direction) > dirThreshold)
        {
            Debug.Log("Stick Right Ability");
            //player.transform.localScale += new Vector3(5f, 5f, 1f);
            //player.transform.localScale += scale;

        }

        if (Vector2.Dot(Vector2.left, direction) > dirThreshold)
        {
            Debug.Log("Stick Left Ability");
            //player.transform.localScale += new Vector3(5f, 5f, 1f);
            //player.transform.localScale += scale;

        }

        //pythagoras theorem for the diagonal SPLIT ability
    }
}
