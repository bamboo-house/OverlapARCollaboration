using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkTransformAttacher : NetworkBehaviour
{
    [SerializeField]
    public Transform NetworkHeadTransform;
    [SerializeField]
    public Transform NetworkLeftHandTransform;
    [SerializeField]
    public Transform NetworkRightHandTransform;

    private Transform LocalHeadTransform;
    private Transform LocalLeftHandTransform;
    private Transform LocalRightHandTransform;

    void Start()
    {
        Debug.Log("NetworkTransformAttacher Start!");

    }

    public override void FixedUpdateNetwork()
    {
        LocalHeadTransform = GameObject.FindWithTag("HeadTarget").GetComponent<Transform>();
        LocalLeftHandTransform = GameObject.FindWithTag("LeftHandTarget").GetComponent<Transform>();
        LocalRightHandTransform = GameObject.FindWithTag("RightHandTarget").GetComponent<Transform>();
        Debug.Log(LocalLeftHandTransform.position);
        Debug.Log(LocalHeadTransform.position);

        if (Object.HasStateAuthority)
        {
            NetworkHeadTransform.position = LocalHeadTransform.position;
            NetworkHeadTransform.rotation = LocalHeadTransform.rotation;

            NetworkLeftHandTransform.position = LocalLeftHandTransform.position;
            NetworkLeftHandTransform.rotation = LocalLeftHandTransform.rotation;

            NetworkRightHandTransform.position = LocalRightHandTransform.position;
            NetworkRightHandTransform.rotation = LocalRightHandTransform.rotation;
        }
    }

}
