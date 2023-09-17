using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    private SpriteRenderer m_SpriteRenderer;
    private Human m_Target = null;

    private Rigidbody2D m_Rigidbody;

    void Start()
    {
        m_SpriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        Texture2D texture = new Texture2D(2, 2);
        Color32[] colors = new Color32[4];
        //texture.SetPixels(new Color[4])
        m_SpriteRenderer.sprite = Sprite.Create(texture, new Rect(Vector2.zero, Vector2.one), new Vector2(0.5f, 0.5f), 32);

        m_Rigidbody = gameObject.AddComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if(m_Target != null)
        {
            Vector2 direction = (Vector2)(transform.position - m_Target.transform.position).normalized;
            m_Rigidbody.MovePosition(direction * moveSpeed);
        }



    }
}
