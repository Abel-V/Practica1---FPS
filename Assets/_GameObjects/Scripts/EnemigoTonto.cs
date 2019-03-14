using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTonto : EnemigoMovil
{
    private int timeToDestroy;

    protected override void Start() {
        timeToDestroy = Random.Range(60, 80); //segundos
        Invoke("AutoDestroy", timeToDestroy);
        base.Start();
    }

    private void AutoDestroy() {
        Morir();
    }

}
