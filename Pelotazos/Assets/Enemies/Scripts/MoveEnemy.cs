using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {
	public Vector2 Force;
	public float PowerForce = 100;
	private Rigidbody2D rbBallEnemy;

	void Awake() {
		rbBallEnemy = GetComponent<Rigidbody2D> ();
		
	}

    void Start()
    {
        rbBallEnemy.AddForce(Force * PowerForce, ForceMode2D.Impulse);
    }
		
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Vector2 normal = new Vector2();
        Vector2 vel = Vector2.zero;
        if(rbBallEnemy.velocity != Vector2.zero)
            vel = rbBallEnemy.velocity.normalized;

        ContactPoint2D[] ContactPoints = other.contacts;
		foreach (ContactPoint2D Contact in ContactPoints) {
			normal = Contact.normal;	
		}
		rbBallEnemy.AddForce (-(vel+normal)*PowerForce, ForceMode2D.Impulse);
	}
}
