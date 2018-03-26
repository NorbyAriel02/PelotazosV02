using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public List<GameObject> listObj;    
    private DropApple dropApple;
    private DropEnemies dropEnemies;
    private DropBlocks dropBlocksSolid;
    private DropBlocks dropBlocksHiding;
    private WallController wallsController;
	private LoadObject loadObj;
	private Level lvl;
    private float delay = 3;
    private int appleNumbersDropping = 0;

    void Awake()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(1, 1, 1);
    }

	void Start () {
        StartConfig();
    }

    void StartConfig()
    {
        loadObj = GetComponent<LoadObject>();
        lvl = loadObj.GetLevel;
        //listobj[0] son los muros limites Walls
        GameObject dataWalls = Instantiate(listObj[0], transform);
        wallsController = dataWalls.GetComponent<WallController>();
        //listobj[1] es el dropapple
        GameObject instanceDropApple = Instantiate(listObj[1], transform);
        dropApple = instanceDropApple.GetComponent<DropApple>();
        dropApple.StartConfig(6, wallsController.GetBoundariesPoint);
        SetEnemies ();
        SetBlocks();
    }
       
    void SetEnemies()
	{
        List<DescriptionEnemies> lstEnemies = (List<DescriptionEnemies>)lvl.ObjectList.Get(TypeObjectLevel.Enemies);
        //listobj[2] es el dropEnemies
        GameObject instanceDropEnemies = Instantiate(listObj[2], transform);
		dropEnemies = instanceDropEnemies.GetComponent<DropEnemies>();
		dropEnemies.StartConfig(lstEnemies.Count, wallsController.GetBoundariesPoint);		
        foreach(DescriptionEnemies enemy in lstEnemies)
        {
            dropEnemies.Drop(enemy);
        }
	}

    void SetBlocks()
    {
        List<DescriptionBlocks> lstBlock = (List<DescriptionBlocks>)lvl.ObjectList.Get(TypeObjectLevel.Blocks);
        GameObject instanceDropBlock = Instantiate(listObj[3], transform);
        GameObject instanceDropBlockHiding = Instantiate(listObj[4], transform);
        dropBlocksSolid = instanceDropBlock.GetComponent<DropBlocks>();
        dropBlocksHiding = instanceDropBlockHiding.GetComponent<DropBlocks>();
        int numSolid = 0;
        int numHiding = 0;
        foreach (DescriptionBlocks Block in lstBlock)
        {
            if (Block.Type == BlockType.Solid)
                numSolid++;

            if (Block.Type == BlockType.HidingPlace)
                numHiding++;
        }

        dropBlocksSolid.StartConfig(numSolid);
        dropBlocksHiding.StartConfig(numHiding);

        foreach (DescriptionBlocks Block in lstBlock)
        {
            if(Block.Type == BlockType.Solid)
                dropBlocksSolid.Drop(Block);

            if (Block.Type == BlockType.HidingPlace)
                dropBlocksHiding.Drop(Block);
        }
    }

    void Update () {
        delay -= Time.deltaTime;
        if (delay < 0)
        {
            dropApple.Drop();
            appleNumbersDropping += 1;
            delay = 3;
        }            
	}
        
    public int GetAppleNumbersDropping { get { return appleNumbersDropping; } }

    public void ManagerDrop()
    {

    }
}

public class PositionMatrix
{
    public List<float[]> position = new List<float[]>();
    public float width;
    public float height;
    public PositionMatrix(float w, float h)
    {
        width = w;
        height = h;
    }


}