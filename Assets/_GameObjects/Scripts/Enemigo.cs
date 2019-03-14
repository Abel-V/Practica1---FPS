using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    public int damage = 30; //daño que provoca el enemigo al atacar
    public int salud = 40; //salud del enemigo
    public float distanciaDeteccion = 50; //a partir de cuanto detecta al player
    public GameObject prefabExplosion; //prefab de la explosión

    private TextMesh tm;//BORRAR EN EL FUTURO
    protected Transform transformPlayer;

    //los hacemos public para que puedan heredarlos los hijos:

    protected virtual void Start() {
        tm = GetComponentInChildren<TextMesh>(); //QUITAR EN EL FUTURO
        tm.text = salud.ToString(); //QUITAR EN EL FUTURO
        transformPlayer = GameObject.Find("Player").transform; //para saber dónde está el Player
    }

    public void Atacar() {  

    }

    public void Morir() {
        Instantiate(prefabExplosion, this.transform.position, Quaternion.identity);
        //instanciamos la explosioóm en las coordenadas del enemigo.
        //Quaternion.identity coordenadas del mundo por defecto, mirar
        Destroy(this.gameObject);
    }

    public void RecibirDamage(int receivedDamage) {
        salud = salud - receivedDamage;
        salud = Mathf.Max(salud, 0);
        tm.text = salud.ToString();
        if (salud == 0) {
            Morir();
        } else {
            //sonido de dolor
        }
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Player>().ModificarSalud(-damage);
            Morir();
        }
    }
}
