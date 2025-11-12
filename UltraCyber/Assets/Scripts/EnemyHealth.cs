using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 3f;
    public float PlayerMeleeDamage = 1f;
    public static float PlayerBulletDamage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            if(health <= 0)
            {
                Destroy(gameObject);
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
                Destroy(gameObject);
            }
        }
    }
    public void UpgradeMeleeDamage()
    {
        PlayerMeleeDamage += 1f;
    }
    public void UpgradeBulletDamage()
    {
        PlayerBulletDamage += 1f;
    }
}
