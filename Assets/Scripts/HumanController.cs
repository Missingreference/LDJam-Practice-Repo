using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{

    public Human human;

    public bool leftIsPressed { get; private set; }
    public bool rightIsPressed { get; private set; }
    public bool upIsPressed { get; private set; }
    public bool downIsPressed { get; private set; }

    void Awake()
    {
        human = GetComponent<Human>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        leftIsPressed = Input.GetKey(KeyCode.A);
        rightIsPressed = Input.GetKey(KeyCode.D);
        upIsPressed = Input.GetKey(KeyCode.W);
        downIsPressed = Input.GetKey(KeyCode.S);

        Vector2 direction = Vector2.zero;
        if(leftIsPressed) 
        {
            //(-1.0f, 0.0f)
            direction += Vector2.left;
        }
        if(rightIsPressed)
        {
            //(1.0f, 0.0f)
            direction += Vector2.right;
        }
        if(upIsPressed)
        {
            //(0.0f, 1.0f)
            direction += Vector2.up;
        }
        if(downIsPressed)
        {
            //(0.0f, -1.0f)
            direction += Vector2.down;
        }

        human.Move(direction);
    }
}
