using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    public GameObject enemigoFinal;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enemigoFinal.SetActive(true); //previamente lo tenemos desactivado desde el inspector
        }
    }
}