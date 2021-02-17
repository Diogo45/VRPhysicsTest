using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public enum InputKey
{
    Up, Down, Held
}
public class InputHandler : MonoBehaviour
{

    

    public static InputHandler instance;

    public InputKey W;
    public InputKey S;

    public SteamVR_Action_Vector2 leftJoystick;
    public SteamVR_Input_Sources leftHand;

    public SteamVR_Action_Vector2 rightJoystick;
    public SteamVR_Input_Sources rightHand;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
            W = InputKey.Down;
        if (Input.GetKeyUp("w"))
            W = InputKey.Up;

        if (Input.GetKeyDown("s"))
            S = InputKey.Down;
        if (Input.GetKeyUp("s"))
            S = InputKey.Up;



    }
}
