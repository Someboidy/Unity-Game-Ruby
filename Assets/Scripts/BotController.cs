using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    Animator animator; 
    public float speed = 0.5f;
    public float changeTime = 1.0f;
    int direction = 1;
    float timer;
    public bool vertical;
    Rigidbody2D rigidbody2D;
    float directionTimer;
    bool broken = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timer = changeTime;
        directionTimer = changeTime * 2; 
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (!broken)
        {
            return;
        }
        Vector2 position = rigidbody2D.position;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rigidbody2D.MovePosition(position);
    }
    void Update()
    {
        if (!broken)
        {
            return;
        }
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

    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");
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





















