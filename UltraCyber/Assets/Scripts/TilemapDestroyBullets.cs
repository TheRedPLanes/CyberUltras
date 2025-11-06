using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapDestroyBullets : MonoBehaviour
{
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

        }
    }

}
    
        

    
       

        
