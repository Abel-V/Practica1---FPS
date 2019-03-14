using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaVida : MonoBehaviour
{
    public int cantidadSalud = 5;
    [SerializeField] private float velocidadGiro = 100f; //no quiero que la modifiquen, pero si que se vea desde el inspector


    // Update is called once per frame
    void Update()
    {
        Rotar();
    }

    private void Rotar() {
        transform.Rotate(new Vector3(0, Time.deltaTime * velocidadGiro, 0));
    }

    private void OnTriggerEnter(Collider other) {
        /*
         * 1. La caja ha sido atravesada por el Player?
         * (debemos asignar la etiqueta/tag "Player" a nuestro gameObject Player)
         */
         if (other.gameObject.CompareTag("Player")) {
            int saludPlayer;
            Player thePlayer = other.gameObject.GetComponent<Player>(); //cogemos el script "Player" del gameObject Player,
            saludPlayer = thePlayer.salud;

            if (saludPlayer != thePlayer.saludMax) { //si la salud del player está al máximo, la caja no desaparece
                saludPlayer = thePlayer.ModificarSalud(cantidadSalud);
                //y llamamos a su método ModificarSalud, pasándole como argumento el valor de salud que otorga la caja
                Destroy(this.gameObject);
            }
        }
    }
}
