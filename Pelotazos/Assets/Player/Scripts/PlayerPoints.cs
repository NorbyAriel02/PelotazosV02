using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour {
	public float apples;
    public float pointsByApple = 50;
    private float timeBetweenApple;
    private float score;
    private float multiplier;
    void Start()
    {
        multiplier = 1;
        timeBetweenApple = 0;
        score = 0;
    }
    
	void Update () {
        timeBetweenApple += Time.deltaTime;
        ScoreMultiplier();
    }

	void OnTriggerEnter2D(Collider2D other)
	{		
		if (other.tag.Equals ("Apple")) {
			apples += 1;
            timeBetweenApple = 0;
            score += multiplier * pointsByApple; 
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		
	}

    private void ScoreMultiplier()
    {
        if(timeBetweenApple < 0.5f)
        {
            multiplier = 200;
        }
        else if(timeBetweenApple < 2f)
        {
            multiplier = 50;
        }
        else
        {
            multiplier = 1;
        }
    }

    public float GetTimeBetweenApple { get { return timeBetweenApple; } }
    public float GetApples { get { return apples; } }
    public float Score { get { return score; } }
}
