using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Transform rigRotTarget;
    public Vector3 trackingPosOffset;
    public Vector3 trackingRotOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPosOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotOffset);
    }

}

public class VRRig : MonoBehaviour
{
    public Animator animator;

    public VRMap head;
    public VRMap LHand;
    public VRMap RHand;

    public Transform headConstraint;
    public Vector3 headBodyOffset;
    public Vector3 feetOffset;
    public float turnSmoothness;

    

    public SteamVR_Action_Vector2 leftJoystick;
    public SteamVR_Input_Sources leftHand;

    public SteamVR_Action_Vector2 rightJoystick;
    public SteamVR_Input_Sources rightHand;

    public Transform[] LeftLegBones;
    public Transform[] RightLegBones;

    public GameObject debug;

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }


 
    private void Update()
    {
        if(InputHandler.ih.W == InputKey.Down)
        {
            animator.speed += 0.01f;
        }

        if (InputHandler.ih.S == InputKey.Down)
        {
            animator.speed -= 0.01f;
        }
        //legAnimation.speed = leftJoystick.axis.y;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        //Vector3 rightFootPos = animator.GetIKPosition(AvatarIKGoal.RightFoot);
        
        //RaycastHit hit;

        //if (Physics.Raycast(rightFootPos + Vector3.up, Vector3.down, out hit))
        //{
        //    animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
        //    animator.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + feetOffset);
        //}
        //else
        //{
        //    animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0f);
        //}

        //Vector3 leftFootPos = animator.GetIKPosition(AvatarIKGoal.LeftFoot);
        //debug.transform.position = leftFootPos;

        //if (Physics.Raycast(leftFootPos + Vector3.up, Vector3.down, out hit))
        //{
        //     animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
        //    animator.SetIKPosition(AvatarIKGoal.LeftFoot, new Vector3(LeftLegBones[2].position.x, LeftLegBones[2].position.y + (LeftLegBones[2].position - LeftLegBones[4].position).y, LeftLegBones[2].position.z));
        //}
        //else
        //{
        //    animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0f);
        //}
    }
    void FixedUpdate()
    {
        //transform.position = headConstraint.position + headBodyOffset;
        //transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, turnSmoothness);

        //head.Map();
        //LHand.Map();
        //RHand.Map();
    }
}
