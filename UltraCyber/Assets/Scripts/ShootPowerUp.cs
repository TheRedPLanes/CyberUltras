using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPowerUp : MonoBehaviour
{
    public int power = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //check to see if we hit a coin specifically
        if (collision.gameObject.tag == "ShotUp")
        {
            power++;
            //Destroy the coin gameobject that we hit
            Destroy(collision.gameObject);
        }
    }
}
