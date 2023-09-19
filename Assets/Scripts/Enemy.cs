using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //The movement speed of this Enemy
    public float moveSpeed = 100.0f;
    //The velocity of the spin of the Enemy
    public float spinSpeed = 500.0f;
    //A bool to keep track of if the Human is alive or not
    public bool isAlive { get; private set; } = true; 
    //The direction that this object is trying to move
    public Vector2 moveDirection { get; private set; } = Vector2.zero;
    //The target that this enemy wants to kill. It desires Human blood.
    private Human m_Target = null;
    //The Sprite Renderer component that renders a sprite on the screen
    public SpriteRenderer spriteRenderer { get; private set; }
    //The Rigidbody component that handles forces and frictions applied to this object
    public Rigidbody2D rigidbody { get; private set; }
    //The collider component shaped as a circle that the Rigidbody2D will use to collide with other colliders
    public CircleCollider2D bodyCollider { get; private set; }
    //The collider component shaped as a box that is set as a trigger instead of a collider
    public BoxCollider2D bodyTrigger { get; private set; }

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
        rigidbody.gravityScale = 0.0f;
        rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rigidbody.drag = 0.4f;

        //Create a CircleCollider2D as a collider with settings
        bodyCollider = gameObject.AddComponent<CircleCollider2D>();
        bodyCollider.isTrigger = false;
        bodyCollider.radius = 0.035f;

        //Create a BoxCollider2D as a trigger with settings
        bodyTrigger = gameObject.AddComponent<BoxCollider2D>();
        bodyTrigger.isTrigger = true;

        //Create the texture and sprite for the Enemy
        Texture2D texture = new Texture2D(2, 2);
        Color32[] colors = new Color32[4] { Color.red, Color.red, Color.red, Color.red };
        texture.SetPixels32(colors);
        texture.Apply();

        //Create a sprite from the newly created texture
        Sprite sprite = Sprite.Create(texture, new Rect(Vector2.zero, Vector2.one), new Vector2(0.5f, 0.5f), 16);
        spriteRenderer.sprite = sprite;

        //Find a target
        m_Target = FindObjectOfType<Human>();

        //Make sure that the Enemy collider does not physically collide with the Human collider
        Physics2D.IgnoreCollision(bodyCollider, m_Target.movementCollider);
    }

    /// <summary>
    /// Update() is called by Unity every frame
    /// </summary>
    void Update()
    {
        //Simple AI movement
        if(m_Target != null)
        {
            //Move towards target
            Vector2 directionTowardsTarget = (Vector2)(m_Target.transform.position - transform.position).normalized;
            Move(directionTowardsTarget);
        }
        else
        {
            //Don't move
            Move(Vector2.zero);
        }

        //Handle rotation
        transform.eulerAngles += new Vector3(0.0f, 0.0f, spinSpeed * Time.deltaTime);
    }

    /// <summary>
    /// FixedUpdate() is called by Unity every physics step
    /// </summary>
    private void FixedUpdate()
    {
        //The Enemy will only move if it has a move direction and is Alive
        if(moveDirection == Vector2.zero || !isAlive) return;

        //Do movement
        rigidbody.AddForce(moveDirection * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    /// <summary>
    /// Call this function to set the movement direction you want to go. Set the Vector2 direction parameter to (0.0f,0.0f) if you want to stop moving.
    /// </summary>
    public void Move(Vector2 direction)
    {
        //The Enemy should not be able to Move if it is not Alive.
        if(!isAlive) return;

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
