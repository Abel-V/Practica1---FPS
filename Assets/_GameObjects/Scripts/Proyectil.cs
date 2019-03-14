using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] int damage = 5;
    [SerializeField] GameObject prefabImpacto;
    private const int TIME_TO_DESTROY = 20;
    public Rigidbody rb;

    private void OnCollisionEnter(Collision collision) {
        //collision.gameObject me proporciona el objeto con el que ha colisionado
        if (collision.gameObject.CompareTag("Enemy")) {
            //Es un enemigo
            collision.gameObject.GetComponent<Enemigo>().RecibirDamage(damage);
            Instantiate(prefabImpacto, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        } else if (collision.gameObject.CompareTag("FinalEnemy"))
        {
            //Es un enemigo
            collision.gameObject.GetComponent<EnemigoFinal>().RecibirDamage(damage);
            Instantiate(prefabImpacto, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            //print(collision.gameObject.name);
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void Start() {
        Invoke("AutoDestroy", TIME_TO_DESTROY);
    }

    private void AutoDestroy() {
        Destroy(this.gameObject);
    }
}
