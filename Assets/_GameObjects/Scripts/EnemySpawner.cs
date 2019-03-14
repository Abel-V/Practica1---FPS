using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject prefabEnemigo;
    public int TimeBetweenSpawns = 8;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarEnemigo", 1, TimeBetweenSpawns);
    }

    private void GenerarEnemigo()
    {
        Instantiate(prefabEnemigo, transform);
    }
}
