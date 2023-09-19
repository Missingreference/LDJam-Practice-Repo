using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //The reference to the camera that is being controlled by this CameraController
    public Camera camera { get; private set; }

    //The Target that the camera will follow
    public GameObject target = null;

    /// <summary>
    /// Start() is called by Unity when an instance of this script is created
    /// </summary>
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    /// <summary>
    /// Start() is called by Unity when an instance of this script is created
    /// </summary>
    void Update()
    {
        //Check if we have a target to follow.
        if(target == null)
        {
            //No target to follow, do nothing.
            return;
        }

        //We have a target, follow it!
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10.0f);
    }
}
