using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Frustum
{
    public float height;
    public float width;
}
/*Por ahora lo que tengo en mente es que el nivel 
 * sea siempre rectangular limitado por 4 colliders, 
 * esto va ser dicatado por 2 valores 
 * altura(height)  y ancho (width)*/
public class WallController : MonoBehaviour {    
    public float widthColl = 0.5f;
    public float widthCoefficient = 0.25f;
    public float heightCoefficient = 0.35f;
    public float distance = 1;
    public Transform background;
    public float discount = 1;        
    private Vector2[] boundariesPoints;
    private BoxCollider2D[] walls;
    private Camera cam;
    private Boundaries boundaries = new Boundaries();
    private Frustum frustum = new Frustum();
	void Awake () {
        walls = GetComponentsInChildren<BoxCollider2D>();
        GameObject objCam = GameObject.FindGameObjectWithTag("MainCamera");
        if (objCam != null)
            cam = objCam.GetComponent<Camera>();

        if (cam != null)
            StartConfigScreem();
    }

    public Boundaries GetBoundariesPoint { get { return boundaries; } }

    void StartConfigScreem()
    {
        GetFrustumCam(cam);
        CreateBoundaries();
        SetSizeSpriteBackground();
        SetBoundariesPoints();
    }

    private void GetFrustumCam(Camera cam)
    {
        frustum.height = 2.0f * distance * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        frustum.width = frustum.height * cam.aspect;
        #region data
        //var frustumHeight = frustumWidth / camera.aspect;
        //distance = frustumHeight * 0.5f / Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        // var camera.fieldOfView = 2.0f * Mathf.Atan(frustumHeight * 0.5f / distance) * Mathf.Rad2Deg;
#endregion
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetFrustumCam(cam);
            CreateBoundaries();
            SetSizeSpriteBackground();
        }            
	}

    void CreateBoundaries()
    {
        walls[0].size = new Vector3(frustum.width, widthColl, 0);
        walls[0].offset = new Vector2(0, frustum.height / 3);
        walls[1].size = new Vector3(frustum.width, widthColl, 0);
        walls[1].offset = new Vector2(0, -frustum.height / 3);
        walls[2].size = new Vector3(widthColl, frustum.height, 0);
        walls[2].offset = new Vector2(frustum.width / 2, 0);
        walls[3].size = new Vector3(widthColl, frustum.height, 0);
        walls[3].offset = new Vector2(-frustum.width / 2, 0);
    }

    void SetSizeSpriteBackground()
    {
        background.localScale = new Vector3((frustum.width * widthCoefficient), ((frustum.height-(frustum.height/3)) * heightCoefficient), 1);
    }
    public void SetBoundariesPoints()
    {        
        foreach (BoxCollider2D box in walls)
        {
            Vector2 point = box.offset;

            if (boundaries.maxX < point[0])
                boundaries.maxX = point[0] - discount;

            if (boundaries.minX > point[0])
                boundaries.minX = point[0] + discount;

            if (boundaries.maxY < point[1])
                boundaries.maxY = point[1] - discount;

            if (boundaries.minY > point[1])
                boundaries.minY = point[1] + discount;
        }
        boundaries.minY = (boundaries.minY / 2);
    }
}
