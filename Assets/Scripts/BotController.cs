using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public float speed = 0.5f;
    public float changeTime = 1.0f;
    int direction = 1;
    float timer;
    public bool vertical;
    Rigidbody2D rigidbody2D;
    float directionTimer; 

    // Start is called before the first frame update
    void Start()
    {
        timer = changeTime;
        directionTimer = changeTime * 2; 
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        rigidbody2D.MovePosition(position);
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = changeTime;
            vertical = !vertical;
        }

        directionTimer -= Time.deltaTime;
        if (directionTimer < 0)
        {
            direction = -direction;
            directionTimer = changeTime * 2;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }


}





















