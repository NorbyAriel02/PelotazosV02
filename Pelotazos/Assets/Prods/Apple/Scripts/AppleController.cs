using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour {
	public int point;
	public int GetPoint { get { return point; } }
    public GameObject objFX;
    private GameObject objFxApple;
    private AppleFXController fx;
	void Start () {
        objFxApple = Instantiate(objFX);
        fx = objFxApple.GetComponent<AppleFXController>();
	}
	
	
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
            objFxApple.SetActive(true);
            fx.Play();
			gameObject.SetActive (false);
		}
	}
}
