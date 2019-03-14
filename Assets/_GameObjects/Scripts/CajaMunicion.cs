using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunicion : MonoBehaviour {
   
    [SerializeField] private float velocidadGiro = 100f; //no quiero que la modifiquen, pero si que se vea desde el inspector


    // Update is called once per frame
    void Update() {
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
            Arma scriptArma = other.gameObject.GetComponentInChildren<Arma>(); //cogemos el script "Arma" de cualquiera de los hijos del gameObject Player
            if (scriptArma.AñadirCargador()) {
                Destroy(this.gameObject);
            }
        }
    }
}
