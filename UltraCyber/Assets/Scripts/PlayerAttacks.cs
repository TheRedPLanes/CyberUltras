using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefab;
    public GameObject meleeSwipe;
    public float shootSpeed = 10f;
    public float meleeSpeed = 1f;
    public float meleeLifetime = 1f;
    public float bulletLifetime = 2f;
    public bool flipped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
        if (moveX < 0)
        {
            //we're moving to the left
            //flip our sprite
            GetComponent<SpriteRenderer>().flipX = true;
            flipped = true;
        }
        else if (moveX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            flipped = false;
        }
        //if we press the "shoot button" (left click)
        if (Input.GetButtonDown("Fire1"))
        {
            if (flipped == true)
            {
                Vector3 shootDir = new Vector3(-1, 0,0 );
                //spawn a bullet
                //GameObject bullet = GetComponent<SpriteRenderer>().flipX;
                
                GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                bullet.GetComponent<SpriteRenderer>().flipX = true;

                //push the bullet in the direction of the direction the player is facing
                //destination (mousePosition) - starting position (transform.position)

                shootDir.Normalize();
                bullet.GetComponent<Rigidbody2D>().velocity = shootDir * shootSpeed;
                Destroy(bullet, bulletLifetime);
            } else if (flipped == false)
            {
                Vector3 shootDir = new Vector3(1, 0, 0);
                //spawn a bullet
                GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                //push the bullet in the direction of the direction the player is facing
                //destination (mousePosition) - starting position (transform.position)

                shootDir.Normalize();
                bullet.GetComponent<Rigidbody2D>().velocity = shootDir * shootSpeed;
                Destroy(bullet, bulletLifetime);
            }
            
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (flipped == true)
            {
                Vector3 shootDir = new Vector3(-1, 0, 0);
                //spawn a bullet
                GameObject melee = Instantiate(meleeSwipe, transform.position, Quaternion.identity);
                //push the bullet in the direction of the direction the player is facing
                //destination (mousePosition) - starting position (transform.position)

                shootDir.Normalize();
                melee.GetComponent<Rigidbody2D>().velocity = shootDir * meleeSpeed;
                Destroy(melee, meleeLifetime);
            }
            else if (flipped == false)
            {
                Vector3 shootDir = new Vector3(1, 0, 0);
                //spawn a bullet
                GameObject melee = Instantiate(meleeSwipe, transform.position, Quaternion.identity);
                //push the bullet in the direction of the direction the player is facing
                //destination (mousePosition) - starting position (transform.position)

                shootDir.Normalize();
                melee.GetComponent<Rigidbody2D>().velocity = shootDir * meleeSpeed;
                Destroy(melee, meleeLifetime);
            }

        }
    }
}
