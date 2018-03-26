using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObjects : MonoBehaviour {
	public bool CreateListAtAwake = false;
	public bool CreateListAtStart = false;
	public GameObject obj;
	public int numberOfObject;
	public GameObject SetPrefabObject { set { obj = value; } }
	public GameObject GetPrefabObject { get { return obj; } }
	public int SetNumberOfObject { set { numberOfObject = value; } }
	public int GetNumberOfObject { get { return numberOfObject; } }
	private List<GameObject> listaObjeto;

	void Awake ()
	{
		if(CreateListAtAwake)
			CreateList();
	}

	void Start()
	{
		if (CreateListAtStart)
			CreateList();
	}

	void Update ()
	{
		
	}

	public void CreateList()
	{
		listaObjeto = new List<GameObject>();
		for (int index = 0; index < numberOfObject; index++)
		{
			GameObject _obj = Instantiate(obj, obj.transform.position, obj.transform.rotation);
			_obj.SetActive(false);
			listaObjeto.Add(_obj);
		}
	}

	public GameObject GetObject(Vector3 position, Quaternion rotation)
	{
		GameObject result = null;
		foreach (GameObject obj in listaObjeto) {
			if (!obj.activeSelf) {
				result = obj;
				result.transform.position = position;
				result.transform.rotation = rotation;
				break;
			}
		}
		return result;
	}
}
