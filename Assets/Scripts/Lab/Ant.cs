using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Ant : Enemy
{
    [SerializeField] Vector2 velocity;
    [SerializeField] Transform[] movePoints;
    

    private void Start()
    {
      
        Behavior();
    }

    private void FixedUpdate()
    {
        Behavior();

    }

    private void FlipCharacter()
    {
        velocity *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            FlipCharacter();
        }
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            FlipCharacter();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Character playerCharacter = collision.gameObject.GetComponent<Character>();
            playerCharacter.TakeDamage(2);
            
        }
    }

}
