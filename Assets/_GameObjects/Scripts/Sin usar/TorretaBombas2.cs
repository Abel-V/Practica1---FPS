using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaBombas2 : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Space)) //carga la fuerza del proyectil
        {
            fuerza += Time.deltaTime;
        } else if (Input.GetKeyup(KeyCode.Space))
        {
            Disparar();
            fuerza = 0;
        }
        */
    }

    void Disparar()
    {
        GameObject proyectil = Instantiate(prefabProyectil, spawnPoint.position, spawnPoint.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(Vector3.forward * fuerza);
    }
}
