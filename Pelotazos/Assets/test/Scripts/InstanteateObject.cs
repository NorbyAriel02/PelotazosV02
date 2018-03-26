using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanteateObject : MonoBehaviour {
    public GameObject son;
    void Awake()
    {
        Debug.Log(Application.persistentDataPath);
    }

    void OnEnable()
    {
        
    }

    void Start()
    {
        Debug.Log("Instantiate start " + Time.deltaTime + " " + gameObject.name);
        Instantiate(son);
        Debug.Log("Instantiate Finish " + Time.deltaTime + " " + gameObject.name);
    }

    private IEnumerator Mycorrutine()
    {
        /*Mostrar reloj de espera*/
        yield return null;
    }

    void Update()
    {

    }
}
