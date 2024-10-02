using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    float bulletSpeed = 10.0f;
    Vector3 originalPosition;
    public Vector3 hitLocation;
    bool hasShot = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get original position
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasShot) {
            if (hitLocation == null) {
                return;
            } else {
                hasShot = true;
                // Set the bullet to move towards the hit location
                GetComponent<Rigidbody>().velocity = (hitLocation - originalPosition).normalized * bulletSpeed;
            }
        }
        // If the bullet is too far from the original position, destroy it
        if (Vector3.Distance(originalPosition, transform.position) > 50.0f) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        // If bullet hit anything other than the player, destroy the bullet
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet") {
            // Log the name of the object that the bullet hit
            Debug.Log("Bullet hit " + other.gameObject.name);
            Destroy(gameObject);
        }
    }
}
