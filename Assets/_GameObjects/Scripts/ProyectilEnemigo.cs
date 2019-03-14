using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{
    [SerializeField] int damage = 5;
    [SerializeField] GameObject prefabImpacto;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Player>().ModificarSalud(-damage);
            Instantiate(prefabImpacto, this.transform.position, this.transform.rotation);
            DestruirBala();
        } else
        {
            Instantiate(prefabImpacto, this.transform.position, this.transform.rotation);
            DestruirBala();
        }
    }

    private void DestruirBala() {
        Destroy(this.gameObject);
    }
}
