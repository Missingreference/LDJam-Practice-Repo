using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera camera { get; private set; }

    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
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
