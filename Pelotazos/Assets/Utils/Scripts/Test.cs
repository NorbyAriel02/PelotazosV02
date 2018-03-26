using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	void Start () {
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
            Pos();
	}
	private void Pos()
	{
        //Application.CaptureScreenshot(PathHelper.ScremShot);
        Debug.Log(PathHelper.ScremShot);
	}
    
}
