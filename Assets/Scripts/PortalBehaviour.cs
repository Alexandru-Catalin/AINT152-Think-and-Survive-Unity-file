using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour {
    public int health = 1;
    public GameObject portalPrefab;
    public float adjustPortalAngle = 0.0f;
    private Transform player;

    // Use this for initialization
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x,
            transform.eulerAngles.y,
            transform.eulerAngles.z + adjustPortalAngle);
            Instantiate(portalPrefab, transform.position, newRot);
            GetComponent<AddScore>().DoSendScore();
            Destroy(gameObject);
        }
    }


    void FixedUpdate()
    {
        //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }
}
