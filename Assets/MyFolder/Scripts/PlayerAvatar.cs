using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerAvatar : NetworkBehaviour
{
    [SerializeField]
    public Transform NetworkLeftHandTransform;

    private Transform LocalLeftHandTransform;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LeftHand Start!");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void FixedUpdateNetwork()
    {
        //LocalLeftHandTransform = GameObject.Find("Controller (left)").GetComponent<Transform>();
        //Debug.Log(LocalLeftHandTransform.position);

        //if (Object.HasStateAuthority)
        //{
        //    NetworkLeftHandTransform.position = LocalLeftHandTransform.position;
        //    NetworkLeftHandTransform.rotation = LocalLeftHandTransform.rotation;
        //}
    }
}
