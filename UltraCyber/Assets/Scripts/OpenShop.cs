using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public Canvas shopCanvas;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        shopCanvas.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shopCanvas.enabled = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shopCanvas.enabled = false;

        }
    }
    public void BuySpeedUpgrade()
    {
        if (player.GetComponent<Collectables>() != null)
        {
            if (player.GetComponent<Collectables>().coins >= 5)
            {
                player.GetComponent<PlatformerMovement>().UpgradeSpeed();
                player.GetComponent<Collectables>().coins -= 5;
            }
            else
            {

            }
        }


    }
    public void BuyMeleeUpgrade()
    {
        if (player.GetComponent<Collectables>() != null)
        {
            if (player.GetComponent<Collectables>().coins >= 5)
            {
                player.GetComponent<EnemyHealth>().UpgradeMeleeDamage();
                player.GetComponent<Collectables>().coins -= 5;
            }
            else
            {

            }
        }


    }
    public void BuyBulletUpgrade()
    {
        if (player.GetComponent<Collectables>() != null)
        {
            if (player.GetComponent<Collectables>().coins >= 5)
            {
                player.GetComponent<EnemyHealth>().UpgradeBulletDamage();
                player.GetComponent<Collectables>().coins -= 5;
            }
            else
            {

            }
        }


    }
}
    
