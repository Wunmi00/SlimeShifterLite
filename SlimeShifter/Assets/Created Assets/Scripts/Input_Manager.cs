using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class Input_Manager : Singleton<Input_Manager>
{
    public delegate void startTouch_Event(Vector2 position, float time);
    public event startTouch_Event OnStartTouch;

    public delegate void endTouch_Event(Vector2 position, float time);
    public event endTouch_Event OnEndTouch;

    private TouchControls touchControls;

    private Vector2 initialTouchPos;
    private Vector2 endTouchPos; 


    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();

    }
    // Start is called before the first frame update
    void Start()
    {
        touchControls.Touch.Touch_Pressed.started += ctx => startTouch(ctx);
        touchControls.Touch.Touch_Pressed.canceled += ctx => endTouch(ctx);
    }

    private void startTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Started " + touchControls.Touch.Touch_Pos.ReadValue<Vector2>());
        if (OnStartTouch != null)
        {
            OnStartTouch(touchControls.Touch.Touch_Pos.ReadValue<Vector2>(), (float)context.startTime);
        }
    }

    private void endTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch ended");
        if (OnEndTouch != null)
        {
            OnEndTouch(touchControls.Touch.Touch_Pos.ReadValue<Vector2>(), (float)context.time);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
