using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PullObjects))]
public class DropEnemies : MonoBehaviour {
    public float Delay;
    private PullObjects pullEnemies;    
    private Boundaries boundariesPoints = new Boundaries();
    void Awake()
    {
        pullEnemies = GetComponent<PullObjects>();        
    }

    public void StartConfig(int numberOfObject, Boundaries boundaries)
    {        
        pullEnemies.SetNumberOfObject = numberOfObject;
        pullEnemies.CreateList();
        boundariesPoints = boundaries;
    }

    public void Drop(DescriptionEnemies descriptionEnemy)
    {
        float[] scale = descriptionEnemy.Scale;
        Vector3 spawnPosition = SpawningPosition(descriptionEnemy.Position);
        
        GameObject enemy = pullEnemies.GetObject(spawnPosition, Quaternion.identity);
        if(enemy != null)
        {
            enemy.GetComponent<MoveEnemy>().PowerForce = descriptionEnemy.MagnitudVelocity;            
            enemy.transform.localScale = new Vector3(scale[0], scale[1], scale[2]);
            enemy.SetActive(true);
        }
            
    }

    private Vector3 SpawningPosition(float[] positions)
    {        
        float x = boundariesPoints.maxX - boundariesPoints.minX;
        float y = boundariesPoints.maxY - boundariesPoints.minY;

        Vector3 pos = new Vector3(GetCoor(x, positions[0]) + boundariesPoints.minX, GetCoor(y, positions[1]) + boundariesPoints.minY, 0);
        
        return pos;
    }

    private float GetCoor(float Value100, float valuePer)
    {
        return ((valuePer * Value100) / 100);
    }

    void Update()
    {
        
    }
}
