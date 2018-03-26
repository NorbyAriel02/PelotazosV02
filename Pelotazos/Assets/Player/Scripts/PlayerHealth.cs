using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float health = 3;
    public Sprite[] sprite;
    private SpriteRenderer srPlayer;
	/*Voy a manejar los datos de la vida 
     * y unicamente eso para mostrar estos 
     * datos en la UI voy a usar un 
     * controlador que consuma estos datos*/
	void Start () {
        srPlayer = GetComponent<SpriteRenderer>();
	}
		
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            /* Aca podria obtener un un script comun 
             * de todos los enemigos que tenga un tipo 
             * de ataque y el valor del daño, ese valor 
             * se lo descuento a la vida y el tipo de 
             * ataque puede ser dependiendo de los elementos, 
             * me pueden envenenar o quemar y van haciendome 
             * daño en el tiempo con corrutinas en este script, 
             * de hielo y dejarme inmovil para que otro enemigo 
             * me ataque o simplemente de daño*/
            health--;
            if(health > -1)
                srPlayer.sprite = sprite[(int)health];
        }
    }

    public float GetHealt { get { return health; } }
    public float SetHealt { set { health = value; } }
}
