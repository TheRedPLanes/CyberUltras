using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHealth : MonoBehaviour
{
    public float health = 1f;
    public float PlayerMeleeDamage = 1f;
    public static float PlayerBulletDamage = 1f;
    float deathTimer = 0f;
    public GameObject explodeHitbox;
    public float explodeSpeed = 0f;
    public float explodeLifetime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Animator animator = GetComponent<Animator>();
            if(animator != null)
            {
                animator.SetBool("isDead", true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when I am hit by a player bullet
        if (collision.gameObject.tag == "PlayerBullet")
        {
            //destroy the bullet
            Destroy(collision.gameObject);
            //reduce my hp
            health -= PlayerBulletDamage;
            //destroy myself if I get too low in health
            if (health <= 0)
            {
                GameObject explosion = Instantiate(explodeHitbox, transform.position, Quaternion.identity);
                //push the bullet in the direction of the direction the player is facing
                //destination (mousePosition) - starting position (transform.position)

                Vector2 ExplodeSpeed = new Vector2(explodeSpeed, 0);
                explosion.GetComponent<Rigidbody2D>().velocity = ExplodeSpeed;
                Destroy(explosion, explodeLifetime);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            //destroy the bullet
            
            //reduce my hp
            health--;
            //destroy myself if I get too low in health
            if (health <= 0)
            {
                GameObject explosion = Instantiate(explodeHitbox, transform.position, Quaternion.identity);
                //push the bullet in the direction of the direction the player is facing
                //destination (mousePosition) - starting position (transform.position)

                Vector2 ExplodeSpeed = new Vector2(explodeSpeed, 0);
                explosion.GetComponent<Rigidbody2D>().velocity = ExplodeSpeed;
                Destroy(explosion, explodeLifetime);
            }
        }
        if (collision.gameObject.tag == "PlayerMelee")
        {
            //destroy the bullet
            Destroy(collision.gameObject);
            //reduce my hp
            health -= PlayerMeleeDamage;
            //destroy myself if I get too low in health
            if (health <= 0)
            {
                GameObject explosion = Instantiate(explodeHitbox, transform.position, Quaternion.identity);
                //push the bullet in the direction of the direction the player is facing
                //destination (mousePosition) - starting position (transform.position)

                Vector2 ExplodeSpeed = new Vector2(explodeSpeed, 0);
                explosion.GetComponent<Rigidbody2D>().velocity = ExplodeSpeed;
                Destroy(explosion, explodeLifetime);
            }
        }
    }
}
