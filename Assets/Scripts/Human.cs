using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    //The amount of force to be applied to the Rigidbody to move the Human
    public float moveSpeed = 3000.0f;
    //Health points
    public int health { get; private set; } = 100;
    //A bool to keep track of if the Human is alive or not
    public bool isAlive { get; private set; } = true;
    //The current direction the Human is trying to move
    public Vector2 moveDirection { get; private set; } = Vector2.zero;
    //The Sprite Renderer component that renders a sprite on the screen
    public SpriteRenderer spriteRenderer { get; private set; }
    //The Rigidbody component that handles forces and frictions applied to this object
    public Rigidbody2D rigidbody { get; private set; }
    //The collider component shaped as a circle that the Rigidbody2D will use to collide with other colliders
    public CircleCollider2D movementCollider { get; private set; }
    public BoxCollider2D bodyTrigger { get; private set; }

    //Sprites
    private Sprite m_FacingDownSprite;
    private Sprite m_FacingLeftSprite;
    private Sprite m_FacingUpSprite;

    /// <summary>
    /// Start() is called by Unity when an instance of this script is created
    /// </summary>
    void Start()
    {
        //Get the SpriteRenderer component. If it doesn't exist create a one
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        //Create a Rigidbody2D with settings
        rigidbody = gameObject.AddComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
        rigidbody.drag = 40.0f;
        rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rigidbody.gravityScale = 0.0f;

        //Create a CircleCollider2D as a collider with settings
        movementCollider = gameObject.AddComponent<CircleCollider2D>();
        movementCollider.isTrigger = false;
        movementCollider.radius = 0.04f;
        movementCollider.offset = new Vector2(0.0f, 0.04f);

        //Create a BoxCollider2D as a trigger with settings
        bodyTrigger = gameObject.AddComponent<BoxCollider2D>();
        bodyTrigger.isTrigger = true;
        bodyTrigger.size = new Vector2(0.07f, 0.1f);
        bodyTrigger.offset = new Vector2(0.0f, 0.07f);

        //Load all the human Sprites and put them in their own variables to use later
        m_FacingDownSprite = Resources.Load<Sprite>("Human_Down");
        m_FacingLeftSprite = Resources.Load<Sprite>("Human_Left");
        m_FacingUpSprite = Resources.Load<Sprite>("Human_Up");
    }

    /// <summary>
    /// Update() is called by Unity every frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Reduce the health of the Human the specified amount. Die() function will be called once the health is reduced to or below 0.
    /// </summary>
    public void TakeDamage(int amount)
    {
        //If the Human is not Alive then nothing should happen
        if(!isAlive) return;

        if(health - amount <= 0)
        {
            //In this case the human has taken too much damage that they reached 0 or less health and have died
            health = 0;
            Die();
        }
        else
        {
            //In this case the human still has more health to spare so simply subtract the damage from the health
            health -= amount;
        }
    }

    /// <summary>
    /// This function makes it so that this Human is now dead and will represent that by setting the isAlive boolean to false. Some other functions check if isAlive is true or false and do
    /// </summary>
    public void Die()
    {
        //Set the isAlive bool to false. Other functions will check this variable to see if they should continue to work such as TakeDamage() or thje movement code
        isAlive = false;

        //Set health to 0 just in case Die() function is called directly instead of from TakeDamage() function
        health = 0;
    }

    /// <summary>
    /// FixedUpdate() is called by Unity every physics step
    /// </summary>
    private void FixedUpdate()
    {
        if(moveDirection == Vector2.zero || !isAlive) return;

        //Do movement
        rigidbody.AddForce(moveDirection * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);

        //Choose the sprite to show
        if(Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
            if(moveDirection.x < 0)
            {
                spriteRenderer.sprite = m_FacingLeftSprite;
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.sprite = m_FacingLeftSprite;
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            spriteRenderer.flipX = false;

            if(moveDirection.y < 0)
            {
                spriteRenderer.sprite = m_FacingDownSprite;
            }
            else
            {
                spriteRenderer.sprite = m_FacingUpSprite;
            }
        }

    }

    /// <summary>
    /// Call this function to set the movement direction you want to go. Set the Vector2 direction parameter to (0.0f,0.0f) if you want to stop moving.
    /// </summary>
    public void Move(Vector2 direction)
    {
        //The Human should not be able to Move if it is not Alive.
        if(!isAlive) return;

        //Set the moveDirection vector. It will later be used by FixedUpdate() to move the Rigidbody2D 
        if(direction.magnitude > 1.0f)
        {
            //This changes the move direction vector to be normalized meaning and Vector2 will be of length 1.0f.
            //For example if we want to move right and the Move() function received vector (10.0f, 0.0f), this line will change it to (1.0f, 0.0f)
            moveDirection = direction.normalized;
        }
        else
        {
            moveDirection = direction;
        }
    }
}
