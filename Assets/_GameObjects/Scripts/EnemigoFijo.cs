using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFijo : Enemigo
{
    enum Estado { Idle, Attack, Reload };
    private Estado estado = Estado.Idle;

    public GameObject prefabBalas;
    public Transform spawnPoint;
    public float fuerzaDisparo = 1000;
    public float cadenciaDisparo = 1;

    public Transform ejeRotacion;

    private void Disparar() {
        GameObject bala = Instantiate(prefabBalas, spawnPoint.position, spawnPoint.rotation);
        bala.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * fuerzaDisparo);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            estado = Estado.Attack;
            InvokeRepeating("Disparar", 0, 1/cadenciaDisparo);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            estado = Estado.Idle;
            CancelInvoke();
        }
    }

    private void Update() {
        if (estado == Estado.Attack) {
            //ejeRotacion.LookAt(transformPlayer.position+transformPlayer.up); //mira al Player (un metro más arriba, gracias al .up)
            ejeRotacion.LookAt(transformPlayer.position + new Vector3(0,0.5f,0)); //mira al Player (un metro más arriba, gracias al .up)
        }
    }
}
