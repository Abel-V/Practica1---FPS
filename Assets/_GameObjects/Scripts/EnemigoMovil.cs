using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovil : Enemigo
{
    public float velocidad = 5;
    private float angulo;
    private const int INICIO_ROTATE = 5;
    private const int TIEMPO_ENTRE_ROTATES = 3;
    private const int ANGULO_MIN = -90;
    private const int ANGULO_MAX = 90;

    //private Rigidbody rb;

    protected override void Start() {
        InvokeRepeating("Rotar", INICIO_ROTATE, TIEMPO_ENTRE_ROTATES); //invoca el metodo Rotar cada 3 segundos (y tarda 5 en invocarlo la primera vez)
        //rb.constraints = RigidbodyConstraints.FreezeRotationZ;  
        //rb.constraints = RigidbodyConstraints.FreezeRotationX;
        //así no se vuelca con las montañas (lo he marcado desde el inspector)
        base.Start(); //OVERRIDE para que me salga el texto de vida encima de cada enemigo
        //vale para indicarle que debe ejecutar tanto el Start del padre como este (el del hijo)
    }

    
    public void Update() //public para que lo hereden los hijos
    {
        transform.Translate(Vector3.forward*Time.deltaTime*velocidad);
    }
    
    private void Rotar() {
        angulo = Random.Range(ANGULO_MIN, ANGULO_MAX);
        transform.Rotate(new Vector3(0, angulo, 0));
    }
}
