using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaBombas : MonoBehaviour
{
    public GameObject prefabProyectil;
    public Transform spawnPoint;
    public float fuerza;
    private float x;
    private float y;

    // DISEÑADO PARA PROYECTO DE PRUEBA EN EL CUAL TÚ CONTROLAS LA TORRETA
    void Update()
    {
        /*
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(y, x, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
        */
    }

    void Disparar()
    {
        GameObject proyectil = Instantiate(prefabProyectil, spawnPoint.position, spawnPoint.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(Vector3.forward * fuerza);
    }
}
