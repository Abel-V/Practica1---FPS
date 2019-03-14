using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabsEnemigos;
    public int TimeBetweenSpawns = 8;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarEnemigoRandom", 1, TimeBetweenSpawns);
    }

    private void GenerarEnemigoRandom()
    {
        /* //ESTE TIENE IGUAL PROBABILIDAD PARA CADA ENEMIGO SI O SI
        int numeroEnemigos = prefabsEnemigos.Length;
        int indiceEnemigoAleatorio = Random.Range(0, numeroEnemigos);
        Instantiate(prefabsEnemigos[indiceEnemigoAleatorio], transform);
        */
        
        //ESTE PERMITE ASIGNAR PROBABILIDADES, pero hace falta más líneas de codigo
        float tipoEnemigo = Random.Range(0f, 1f);
        print(tipoEnemigo);
        if (tipoEnemigo < 0.8f) //más probable
        {
            Instantiate(prefabsEnemigos[0], transform); //genera enemigo tonto (asignar en Inspector)
        }
        else
        {
            Instantiate(prefabsEnemigos[1], transform); //NO ME INSTANCIA OSOS
        }
        
    }
}
