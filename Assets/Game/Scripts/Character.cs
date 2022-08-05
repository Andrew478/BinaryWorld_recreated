using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Character : MonoBehaviour
{
    public bool isPlayable = false;
    Rigidbody2D rb;

    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) Move(Vector2.up);
        else if (Input.GetKey(KeyCode.S)) Move(Vector2.down);
        else if (Input.GetKey(KeyCode.A)) Move(isPlayable ? Vector2.left : -Vector2.left);
        else if (Input.GetKey(KeyCode.D)) Move(isPlayable ? Vector2.right : -Vector2.right
            );
    }


    void Move(Vector2 direction)
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * speedMultiplier * Time.fixedDeltaTime;
        rb.MovePosition(position + translation);
    }
}
