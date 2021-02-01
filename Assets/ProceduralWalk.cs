using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ProceduralWalk : MonoBehaviour
{
    public struct LegIK
    {
        public GameObject target;
        public GameObject hint;
    }

    public LegIK rightLeg;
    public LegIK leftLeg;

    public SteamVR_Action_Vector2 leftJoystick;
    public SteamVR_Input_Sources leftHand;

    public SteamVR_Action_Vector2 rightJoystick;
    public SteamVR_Input_Sources rightHand;


    // Start is called before the first frame update
    void Start()
    {
        //leftJoystick.AddOnUpdateListener()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
