using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncepad : MonoBehaviour
{
    public float bounceForce = 10f; // Adjust this value in the Inspector for desired bounce height

    // Use OnTriggerEnter if your bounce pad is set as a Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply an upward force to the Rigidbody
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
        // If the player uses a custom movement system without a Rigidbody,
        // might need to call a specific jump/bounce function on their script.
        // Example:
        // PlayerController player = other.GetComponent<PlayerController>();
        // if (player != null)
        // {
        //     player.Jump(bounceForce); // Assuming PlayerController has a Jump method
        // }
    }

    // Use OnCollisionEnter if your bounce pad has a regular Collider (not a Trigger)
    // private void OnCollisionEnter(Collision collision)
    // {
    //     Rigidbody rb = collision.rigidbody;
    //     if (rb != null)
    //     {
    //         rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
    //     }
    // }
}

