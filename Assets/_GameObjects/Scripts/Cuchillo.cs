using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : MonoBehaviour
{
    [SerializeField] int damage = 20;
    private const int TIME_TO_DESTROY = 40;
    public Rigidbody rb;
    private bool clavado = false;
    private float yAngle;
    //private float yRotation;

    private void OnCollisionEnter(Collision collision) {
        //collision.gameObject me proporciona el objeto con el que ha colisionado
        if (collision.gameObject.CompareTag("Enemy")) { //al enemigo final no le afectan
            //Es un enemigo
            collision.gameObject.GetComponent<Enemigo>().RecibirDamage(damage);
            transform.SetParent(collision.gameObject.transform);
            Clavarse();
        } else if (!collision.gameObject.CompareTag("Player"))
        {
            transform.SetParent(collision.gameObject.transform);
            Clavarse();
        }
    }

    private void Start() {
        yAngle = transform.eulerAngles.y;
        //yRotation = transform.rotation.y;
        Invoke("AutoDestroy", TIME_TO_DESTROY);
    }

    private void AutoDestroy() {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (clavado == false)
        {
            transform.Rotate(20, 0, 0);
            //yRotation = transform.rotation.y;
        }
    }

    private void Clavarse()
    {
        clavado = true;
        //transform.rotation = Quaternion.Euler(-45, yRotation, 0);
        //transform.localRotation = Quaternion.Euler(-45, transform.localRotation.y, transform.rotation.z);
        //ContactPoint cp = collision.GetContact(0);
        //Vector3 cpNormal = cp.normal;
        //gameObject.transform.localRotation = Quaternion.LookRotation(cpNormal * -1);
        gameObject.transform.rotation = Quaternion.Euler(45, transform.eulerAngles.y, 0);
        rb.isKinematic = true;
        //rb.constraints = RigidbodyConstraints.FreezeAll;

    }
}
