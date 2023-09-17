using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed { get; private set; } = 10.0f;
    public int health { get; private set; } = 100;

    public bool isAlive { get; private set; }

    public Vector2 moveDirection { get; set; } = Vector2.zero;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        if(health - amount < 0)
        {
            health = 0;
            Die();
        }
        else
        {
            health -= amount;
        }
    }

    public void Die()
    {
        isAlive = false;
    }

    private void FixedUpdate()
    {

    }
}
