using UnityEngine;
public class LoadObject : MonoBehaviour {
	public GameObject player;
	private Level lvl;
	private SaveData dataLevel;
	void Awake () {
        //PlayerPrefs.DeleteAll();
        int numberLvl = PlayerPrefs.GetInt (KeyNames.CurrentLevel);
		numberLvl = numberLvl == 0 ? 1 : numberLvl;
		dataLevel = new SaveData();
		lvl = dataLevel.GetDataLevel(numberLvl);
	}

    public Level GetLevel { get { return lvl; } }
	public GameObject GetPlayer { get { return player; }}
}
