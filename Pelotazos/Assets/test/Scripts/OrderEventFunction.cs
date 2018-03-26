using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderEventFunction : MonoBehaviour {

    void Awake()
    {
        Debug.Log("Awake " + Time.deltaTime + " " + gameObject.name);
    }

    void OnEnable()
    {
        Debug.Log("OnEnable" + Time.deltaTime + " " + gameObject.name);
    }

	void Start () {
        Debug.Log("Start" + Time.deltaTime + " " + gameObject.name);
    }
	
	void Update () {
		
	}
}
