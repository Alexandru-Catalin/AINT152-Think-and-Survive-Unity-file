using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TntScript: MonoBehaviour {
	public int health = 10;
	public int damage = 100;




	public float adjustExplosionAngle = 0.0f;


	public UnityEvent onDestroyed;

	private Transform player;

	// Use this for initialization
	void Start()
	{

		if (GameObject.FindWithTag("Player"))
		{
			player = GameObject.FindWithTag("Player").transform;

		}
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			GetComponent<AudioSource>().Play();
			Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x,
				transform.eulerAngles.y,
				transform.eulerAngles.z + adjustExplosionAngle);

			onDestroyed.Invoke();

			//GetComponent<AddScore>().DoSendScore();
			Destroy(gameObject, 0.5f);
		}
	}
	void FixedUpdate()
	{
		//GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
	}

	void Audio(){
		if(GetComponent<AudioSource>() != null)
		{
			GetComponent<AudioSource>().Play();

		}
	}
}
