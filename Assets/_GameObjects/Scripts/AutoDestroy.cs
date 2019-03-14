using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public int timeToDestroy = 2;

    private void Start()
    {
        Invoke("Destroy", timeToDestroy);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
