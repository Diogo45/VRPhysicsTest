using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicRotation : MonoBehaviour
{
    ConfigurableJoint myJoint;
    Quaternion initialRotation;
    private Transform target;
    public GameObject targetGO;

    private void Start()
    {
        target = targetGO.transform;
        myJoint = GetComponent<ConfigurableJoint>();
        initialRotation = myJoint.transform.localRotation;
        //initialRotation = myJoint.transform.rotation;
    }
    void Update()
    {
          
        myJoint.SetTargetRotationLocal(target.localRotation, initialRotation);

       
    }
}
