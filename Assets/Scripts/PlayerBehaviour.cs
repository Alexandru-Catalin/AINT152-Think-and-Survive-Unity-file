using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
	public GameObject explosionPrefab;
	public float adjustExplosionAngle = 0.0f;

    public int health = 100;

    // MAKE ANIMATIONS!!
    //private Animator gunAnim;

    // Update is called once per frame
    void Start()
    {
        //gunAnim = GetComponent<Animator>();
        SendHealthData();
    }

        private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            //GetComponent<Animator>().SetBool("isFiring", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            //GetComponent<Animator>().SetBool("isFiring", false);

        }
    }

    public void TakeDamage (int damage)
    {
        print("!!!!");
        health -= damage;
        SendHealthData();
        if(health <= 0)
        {
			Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x,
				transform.eulerAngles.y,
				transform.eulerAngles.z + adjustExplosionAngle);
			Instantiate(explosionPrefab, transform.position, newRot);
			Destroy(gameObject);
            Die();
			SceneManager.LoadScene (0);
        }
    }

    void Die()
    {

    }

    void SendHealthData()
    {
        if(OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}
