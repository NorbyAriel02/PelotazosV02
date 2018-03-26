using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PullObjects))]
public class DropApple : MonoBehaviour
{
    public GameObject testWalls;
    public float discount = 1;
    public int numPos = 50;
    private Vector2[] SpawnPoint;

    private PullObjects pull;
    private Boundaries boundariesPoints = new Boundaries();
    private List<Vector2> lstPosition = new List<Vector2>();
    void Awake()
    {        
        pull = GetComponent<PullObjects>();
    }

    public void StartConfig(int numberOfObject, Boundaries boundaries)
    {        
        pull.SetNumberOfObject = numberOfObject;
        pull.CreateList();
        boundariesPoints.minX = (boundaries.minX - ((20 * boundaries.minX) / 100));
        boundariesPoints.minY = (boundaries.minY - ((20 * boundaries.minY) / 100));
        boundariesPoints.maxX = (boundaries.maxX - ((20 * boundaries.maxX) / 100));
        boundariesPoints.maxY = (boundaries.maxY - ((20 * boundaries.maxY) / 100));
        CreatePositions();
    }

    void Update()
    {
        
    }

    private void CreatePositions()
    {
        for (int x = 0; x < numPos; x++)
        {
            /*
            float value = Random.Range(0f, 360f);
            float randomX = 2.5f * Mathf.Sin(value);
            value = Random.Range(0f, 360f);
            float randomY = 2.5f * Mathf.Sin(value);
            Vector2 pos = new Vector2(randomX, randomY);

            if (pos.magnitude < 1.5f)
                pos = 2 * pos;

            lstPosition.Add(pos);
            */
            float randomX = Random.Range(2.5f, boundariesPoints.maxX - 0.5f);            
            float randomY = Random.Range(2.5f, boundariesPoints.maxY - 0.5f);
            float randomX2 = Random.Range(-2.5f, boundariesPoints.minX - 0.5f);
            float randomY3 = Random.Range(-2.5f, boundariesPoints.minY - 0.5f);
            Vector2 pos = new Vector2(randomX, randomY);            
            lstPosition.Add(pos);
            pos = new Vector2(randomX2, randomY3);            
            lstPosition.Add(pos);
        }
    }

    public void Drop()
    {
        int pos = Random.Range(0, 2*numPos);
        Vector2 spawnPosition = lstPosition[pos];

        GameObject obj = pull.GetObject(spawnPosition, Quaternion.identity);
        if (obj != null)
            obj.SetActive(true);
    }    
}

