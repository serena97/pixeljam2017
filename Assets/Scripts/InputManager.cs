using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputMode
{
    Keyboard, Joystick
}

public class InputManager : MonoBehaviour {

    public static InputManager instance;
    public InputMode inputMode = InputMode.Joystick;
    public KeyCode shootKey = KeyCode.Z;
    public KeyCode jumpKey = KeyCode.X;
    public KeyCode closeKey = KeyCode.C;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode shootButton = KeyCode.Joystick1Button1;
    public KeyCode jumpButton = KeyCode.Joystick1Button0;
    public KeyCode closeButton = KeyCode.Joystick1Button2;

    public static bool shoot, jump, close, left, right;
    
	void Start () {
		if(instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
	}

    void HandleJoystickDown()
    {
        if (Input.GetKeyDown(shootButton))
        {
            shoot = true;
        }
        if (Input.GetKeyDown(jumpButton))
        {
            jump = true;
        }
        if (Input.GetKeyDown(closeButton))
        {
            close = true;
        }
    }

    void HandleJoystickUp()
    {
        if (Input.GetKeyUp(shootButton))
        {
            shoot = false;
        }
        if (Input.GetKeyUp(jumpButton))
        {
            jump = false;
        }
        if (Input.GetKeyUp(closeButton))
        {
            close = false;
        }
    }
	
    void HandleJoyStickInput()
    {
        float axis = Input.GetAxisRaw("Horizontal");

        if(axis != 0)
        {
            left = axis < 0;
            right = axis > 0;
        }
        else
        {
            left = false;
            right = false;
        }

        HandleJoystickDown();
        HandleJoystickUp();
    }

    void HandleKeyboardDown()
    {
        if (Input.GetKeyDown(moveLeftKey))
        {
            left = true;
        }
        if (Input.GetKeyDown(moveRightKey))
        {
            right = true;
        }
        if (Input.GetKeyDown(shootKey))
        {
            shoot = true;
        }
        if (Input.GetKeyDown(jumpKey))
        {
            jump = true;
        }
        if (Input.GetKeyDown(closeKey))
        {
            close = true;
        }
    }

    void HandleKeyboardUp()
    {
        if (Input.GetKeyUp(moveLeftKey))
        {
            left = false;
        }
        if (Input.GetKeyUp(moveRightKey))
        {
            right = false;
        }
        if (Input.GetKeyUp(shootKey))
        {
            shoot = false;
        }
        if (Input.GetKeyUp(jumpKey))
        {
            jump = false;
        }
        if (Input.GetKeyUp(closeKey))
        {
            close = false;
        }
    }

    void HandleKeyboardInput()
    {
        HandleKeyboardDown();
        HandleKeyboardUp();
    }

	// Update is called once per frame
	void Update () {
		if(inputMode == InputMode.Joystick)
        {
            HandleJoyStickInput();
        }
        else
        {
            HandleKeyboardInput();
        }
	}
}
