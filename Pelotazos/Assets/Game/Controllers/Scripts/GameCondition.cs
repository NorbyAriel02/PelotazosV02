using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(GameController))]
public class GameCondition : MonoBehaviour {
    public int MaxNumberApples = 5;
	private PlayerHealth playerHealth;
	private LoadObject loadObj;
	private Level lvl;
	private PlayerPoints playerPoins;
    private GameController gController;
    void Start () {
        gController = GetComponent<GameController>();        
		loadObj = GetComponent<LoadObject> ();
		GameObject player = loadObj.GetPlayer;
		if (player != null) {
			playerHealth = player.GetComponent<PlayerHealth> ();
			playerPoins = player.GetComponent<PlayerPoints> ();
		}
        Time.timeScale = 1.0f;
        lvl = loadObj.GetLevel;
	}

	void Update () {
		if (GameOver ())
			Time.timeScale = 0.0f;

		if (Won ())
            Time.timeScale = 0.0f;

    }

	public bool GameOver()
	{
		if (playerHealth.GetHealt < 1)
			return true;

        if (GetAppleNumberDropping > MaxNumberApples)
            return true;

		return false;
	}

    public float GetAppleNumberDropping { get { return (gController.GetAppleNumbersDropping - playerPoins.GetApples); } }

    public bool Won()
	{
		if (lvl.Apples <= playerPoins.GetApples)
			return true;
		
		return false;
	}
}
