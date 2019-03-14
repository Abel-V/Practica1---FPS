/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
//INCOMPLETO, BAJAR PROYECTO "ARSENAL" DEL GITHUB DE FERNANDO


public Transform puntoMira;

// Update is called once per frame
void Update()
{
    Raycast hit;
    if (Input.GetButtonDown("Fire1"))
    {
        Ray rayo = new Ray(puntoMira.position, puntoMira.forward);
        Debug.DrawRay(puntoMira.position, puntoMira.forward * 10, Color.red, Mathf.Infinity);
        bool hayImpacto = Physics.Raycast(rayo, out hit, Mathf.Infinity);
        if (hayImpacto)
        {
            if (hit.GetComponent<Rigidbody>() != null)
            {
                hit.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100);
            }
        }
    }
}
}
*/