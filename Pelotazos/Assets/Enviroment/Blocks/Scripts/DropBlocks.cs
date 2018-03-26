using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PullObjects))]
public class DropBlocks : MonoBehaviour {    
    private List<Vector3> lstBlocksPosition = new List<Vector3>();    
    private PullObjects pull;
    void Awake()
    {
        CreatePositions();
        pull = GetComponent<PullObjects>();
    }

	private void CreatePositions()
	{
		Camera cam = Camera.main;

		for (int x = 0; x < 19; x++)
		{
			lstBlocksPosition.Add(new Vector3(0, 0, 0));
		}

		Vector3 max = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));        
		Vector3 min = cam.ScreenToWorldPoint(new Vector3(0, 0, 10));
		float y = (17 * (max.y*2)) / 100;

		lstBlocksPosition[0] = new Vector3(min.x+0.5f, -1, 0);
		lstBlocksPosition[1] = new Vector3(min.x+0.5f, 0, 0);
		lstBlocksPosition[2] = new Vector3(min.x+0.5f, 1, 0);
		lstBlocksPosition[3] = new Vector3(-1, (max.y-y)-0.5f, 0); 
		lstBlocksPosition[4] = new Vector3(0, (max.y-y)-0.5f, 0);
		lstBlocksPosition[5] = new Vector3(1, (max.y-y)-0.5f, 0); 
		lstBlocksPosition[6] = new Vector3(max.x-0.5f, 1, 0); 
		lstBlocksPosition[7] = new Vector3(max.x-0.5f, 0, 0);
		lstBlocksPosition[8] = new Vector3(max.x-0.5f, -1, 0);
        lstBlocksPosition[9] = new Vector3(0, 0, 0);
        lstBlocksPosition[10] = new Vector3(0, -1, 0);
        lstBlocksPosition[11] = new Vector3(0, 1, 0);
        lstBlocksPosition[12] = new Vector3(1, -1, 0);
        lstBlocksPosition[13] = new Vector3(1, 0, 0);
        lstBlocksPosition[14] = new Vector3(1, 1, 0);
        lstBlocksPosition[15] = new Vector3(-1, 0, 0);
        lstBlocksPosition[16] = new Vector3(-1, -1, 0);
        lstBlocksPosition[17] = new Vector3(-1, 1, 0);
        lstBlocksPosition[18] = new Vector3(2, 2, 0);
    }


    public void StartConfig(int numberOfObject)
    {
        pull.SetNumberOfObject = numberOfObject;
        pull.CreateList();
    }

    public void Drop(DescriptionBlocks descriptionBlock)
    {
        Vector3 spawnPosition = lstBlocksPosition[descriptionBlock.Position];
        GameObject obj = pull.GetObject(spawnPosition, Quaternion.identity);
        
        if (obj != null)
            obj.SetActive(true);
    }
    
}
