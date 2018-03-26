using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleDrop : MonoBehaviour {
    public GameObject Walls;
	public Vector2[] SpawnPoint;
    private Vector2[] PuntosLimites;
	private int index;
	private float timeDeliy;
	private bool OnlyOne;
	private PullObjects pull;
    private BoxCollider2D[] limites;
	
	void Start () {
        limites = Walls.GetComponentsInChildren<BoxCollider2D>();
        pull = GameObject.Find("GameController").GetComponent<PullObjects>();
        int index = 0;
        PuntosLimites = new Vector2[limites.Length];
        foreach (BoxCollider2D box in limites)
        {
            Bounds b = box.bounds;
            PuntosLimites[index] = box.bounds.extents;
            index++;
        }
		index = 0;
		timeDeliy = 0;
		OnlyOne = false;
	}

	void Update () {
		timeDeliy -= Time.deltaTime;
		if (timeDeliy < 0 && OnlyOne) {
			OnlyOne = false;
			DropAppleNow ();	
		}
	}

	public void DropAppleNow()
	{
		if (index >= SpawnPoint.Length)
			index = 0;
		
		GameObject obj = pull.GetObject (SpawnPoint [index], Quaternion.identity);
		obj.SetActive (true);
		index++;
	}
	 
	public void DelayDropApple(float value)
	{
		OnlyOne = true;
		timeDeliy = value;
	}
}
