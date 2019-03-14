using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoListo : EnemigoMovil {

    public float velocidadPersecucion = 8;

    private void Update() {
        if (EstaADistanciaDeAtaque()) { //A por él
            transform.LookAt(transformPlayer); //Mirar al jugador. transformPlayer heredado de Enemigo
            transform.Translate(Vector3.forward * Time.deltaTime * velocidadPersecucion);
        }
        base.Update();
    }
    private bool EstaADistanciaDeAtaque() {
        bool estaADistancia = false;
        if (Vector3.Distance(
            transform.position,
            transformPlayer.position) < distanciaDeteccion) {
            estaADistancia = true;
        }
        return estaADistancia;
    }
}