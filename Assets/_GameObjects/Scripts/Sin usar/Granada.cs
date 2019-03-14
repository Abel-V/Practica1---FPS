using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    public float radio = 3;
    public float tiempoParaExplotar = 3;
    public float fuerzaExplosion = 1000;
    public float fuerzaSalto = 400;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Detonar", tiempoParaExplotar);
    }

    private void Detonar()
    {
        GetComponent<Rigidbody>().isKinematic = true; //desactivamos el rigidbody
        Collider[] afectados = Physics.OverlapSphere(transform.position, radio);
        foreach (Collider afectado in afectados)
        {
            if (afectado.GetComponent<Rigidbody>() != null)
            {
                afectado.GetComponent<Rigidbody>().AddExplosionForce(fuerzaExplosion, transform.position, radio, fuerzaSalto);
            }
        }
    }
}
