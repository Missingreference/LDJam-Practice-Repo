using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{

    public Human human;

    void Awake()
    {
        human = GetComponent<Human>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;
        if(Input.GetKey(KeyCode.A)) 
        {
            direction += -Vector2.left;
        }
        if(Input.GetKey(KeyCode.D))
        {
            direction += Vector2.left;
        }
        if(Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if(Input.GetKey(KeyCode.S))
        {
            direction += -Vector2.down;
        }

        human.moveDirection = direction;
    }
}
