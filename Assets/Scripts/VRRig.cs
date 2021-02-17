using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    public float speedOffset;


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
        if(InputHandler.instance.W == InputKey.Down)
        {
            animator.speed += 0.01f;
        }

        if (InputHandler.instance.S == InputKey.Down)
        {
            animator.speed -= 0.01f;
        }

        transform.position += transform.forward * (animator.speed * Time.deltaTime);
        //legAnimation.speed = leftJoystick.axis.y;
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
