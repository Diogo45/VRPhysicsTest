using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEditor;



public class ProceduralWalk : MonoBehaviour
{
    [System.Serializable]
    public struct LegIK
    {
        public GameObject target;
        public GameObject hint;
    }



    public LegIK rightLeg;
    public Transform[] rightLegBones;
    private float[] rightLegLenght;

    public LegIK leftLeg;
    public Transform[] leftLegBones;
    private float[] leftLegLenght;


    public SteamVR_Action_Vector2 leftJoystick;
    public SteamVR_Input_Sources leftHand;

    public SteamVR_Action_Vector2 rightJoystick;
    public SteamVR_Input_Sources rightHand;


    public float LLegOffset;
    public float RLegOffset;

    private float time;

    public float YActivation;
    [Range(0, 1f)]
    public float ZActivation;


    public float YOffset;

    [Range(0.5f, 5f)]
    public float Velocity;
    public float feetMult;

    public float FeetHeightOffset;

    private Transform LTarget;
    private Transform RTarget;

    public float rotationOffset;

    public MeshRenderer Debug;

    public Vector4[] LFootInitialRotations;
    public Vector4[] RFootInitialRotations;

    public Vector4[] LFootFinalRotations;
    public Vector4[] RFootFinalRotations;

    // Start is called before the first frame update
    void Start()
    {
        rightLegLenght = new float[rightLegBones.Length - 1];
        leftLegLenght = new float[leftLegBones.Length - 1];

        //LFootInitialRotations = new Vector4[2];
        //RFootInitialRotations = new Vector4[2];

        //LFootFinalRotations = new Vector4[2];
        //RFootFinalRotations = new Vector4[2];

        for (int i = 0; i < rightLegLenght.Length; i++)
        {
            rightLegLenght[i] = Vector3.Distance(rightLegBones[i].position, rightLegBones[i + 1].position);
            leftLegLenght[i] = Vector3.Distance(leftLegBones[i].position, leftLegBones[i + 1].position);
        }

        LTarget = leftLeg.target.transform;
        RTarget = rightLeg.target.transform;

        //for (int i = 0; i < LFootInitialRotations.Length; i++)
        //{
        //    LFootInitialRotations[i] += QuaternionToVector4(leftLegBones[2 + i].transform.localRotation);
        //    RFootInitialRotations[i] += QuaternionToVector4(rightLegBones[2 + i].transform.localRotation);

        ////    LFootFinalRotations[i] = new Vector4(0.2f, 0, 0, 0);
        ////    RFootFinalRotations[i] = new Vector4(0.2f, 0, 0, 0);
        //}


    }

    // Update is called once per frame
    void Update()
    {
        Debug.material.color = Color.white;

        RaycastHit hit;

        if (Physics.Raycast(RTarget.position + Vector3.up, Vector3.down, out hit))
        {
            Debug.material.color = Color.red;

            RTarget.position = new Vector3(rightLeg.target.transform.localPosition.x, hit.point.y + YActivation * Mathf.Clamp01(Mathf.Sin((time + YOffset) * Velocity)), ZActivation * Mathf.Sin(time * Velocity + RLegOffset));

            RTarget.position = new Vector3(RTarget.position.x, RTarget.position.y + (rightLegBones[2].position - rightLegBones[4].position).y, RTarget.position.z);

            var timeScaleL = Mathf.Clamp01(Mathf.Sin(time * Velocity + LLegOffset));
            var timeScaleR = Mathf.Clamp01(Mathf.Sin(time * Velocity - (LLegOffset * 2f)));

            LTarget.transform.localRotation = Quaternion.Slerp(Vec4ToQuat(LFootInitialRotations[0]), Vec4ToQuat(LFootFinalRotations[0]), timeScaleL);
            RTarget.transform.localRotation = Quaternion.Slerp(Vec4ToQuat(RFootInitialRotations[0]), Vec4ToQuat(RFootFinalRotations[0]), timeScaleR);

            leftLegBones[3].transform.localRotation = Quaternion.Slerp(Vec4ToQuat(LFootInitialRotations[1]), Vec4ToQuat(LFootFinalRotations[1]), timeScaleL);
            rightLegBones[3].transform.localRotation = Quaternion.Slerp(Vec4ToQuat(RFootInitialRotations[1]), Vec4ToQuat(RFootFinalRotations[1]), timeScaleR);


            //Target.localRotation = Quaternion.Slerp();
        }

        if (Physics.Raycast(LTarget.position + Vector3.up, Vector3.down, out hit))
        {
            LTarget.position = new Vector3(leftLeg.target.transform.localPosition.x, hit.point.y + YActivation * Mathf.Clamp01(Mathf.Sin((time - YOffset) * Velocity)), ZActivation * Mathf.Sin(-time * Velocity + LLegOffset));

            LTarget.position = new Vector3(LTarget.position.x, LTarget.position.y + (leftLegBones[2].position - leftLegBones[4].position).y, LTarget.position.z);


        }

        time += Time.deltaTime;



    }

    static Vector4 QuaternionToVector4(Quaternion rot)
    {
        return new Vector4(rot.x, rot.y, rot.z, rot.w);
    }

    static Quaternion Vec4ToQuat(Vector4 rot)
    {
        return new Quaternion(rot.x, rot.y, rot.z, rot.w);
    }
}
