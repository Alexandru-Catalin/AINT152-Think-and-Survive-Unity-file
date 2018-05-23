using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public float destroyTime = 5.0f;

    // Use this for initialization
    void Start()
    {
        Invoke("Die", destroyTime);

    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}
