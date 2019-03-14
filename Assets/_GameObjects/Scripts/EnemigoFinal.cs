using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFinal : MonoBehaviour
{
    public int damage = 30; //daño que provoca el enemigo al atacar
    public int salud = 40; //salud del enemigo
    public float velocidad = 5;
    public GameObject prefabAparicion; //prefab del efecto de aparición
    public GameObject prefabExplosion; //prefab de la explosión
    /*
    enum Estado { Normal, Angry };
    private Estado estado = Estado.Normal;
    */
    public GameObject prefabBalas;
    public Transform spawnPoint;
    public float fuerzaDisparo = 700;
    public float tiempoMaxEntreDisparos = 1;
    //public Transform ejeRotacion;

    private TextMesh tm;
    protected Transform transformPlayer;

    private Rigidbody rb;
    private float targetManeuver;
    public float smoothing = 0.5f;
    //private float currentSpeed;

    public GameObject detectionArea;
    //public GameObject limit1;
    //public GameObject limit2;

    public GameObject prefabEsbirro;
    public Transform spawnPointEsbirro1;
    public Transform spawnPointEsbirro2;
    public GameObject prefabAparicionEsbirro;
    //private bool socorro = false;
    private float acumulador;
    public float tiempoEntreEsbirros = 15f;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponentInChildren<TextMesh>();
        tm.text = salud.ToString();
        transformPlayer = GameObject.Find("Player").transform; //para saber dónde está el Player

        Instantiate(prefabAparicion, this.transform.position, Quaternion.identity);
        //InvokeRepeating("LlamarEsbirros", 20, 15);

        rb = GetComponent<Rigidbody>();
        //currentSpeed = rb.velocity.x;
        StartCoroutine(Evade());
        StartCoroutine(Disparar());
        //StartCoroutine(LlamarEsbirros());
    }

    
    private void Update()
    {
        acumulador += Time.deltaTime;
        if (salud <= 100 && acumulador > tiempoEntreEsbirros)
        {
            StartCoroutine(LlamarEsbirros());
            acumulador = 0;
            //socorro = true;
            //estado = Estado.Angry;
        }
     }
     

    void FixedUpdate()
    {
        transform.LookAt(transformPlayer.position + new Vector3(0, 0.5f, 0));
        
        rb.position = new Vector3(
            rb.position.x + targetManeuver*0.5f, 
            Mathf.Clamp(rb.position.y, 27, 35),
            rb.position.z + targetManeuver);

        /* NO SE MOVÍA
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x + targetManeuver * 0.5f, 377, 433),
            Mathf.Clamp(rb.position.y, limit1.transform.position.y, limit2.transform.position.y),
            Mathf.Clamp(rb.position.z + targetManeuver, 363, 477));
            */
    }


    public void Morir()
    {
        Instantiate(prefabExplosion, spawnPoint.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void RecibirDamage(int receivedDamage)
    {
        salud = salud - receivedDamage;
        salud = Mathf.Max(salud, 0);
        tm.text = salud.ToString();
        if (salud == 0)
        {
            Morir();
        }
        else
        {
            //sonido de dolor
        }
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(4); //espera inicial
        while (true)
        {
            targetManeuver = Random.Range(0.7f, 1.1f) * -Mathf.Sign(transform.position.z - detectionArea.transform.position.z);
            //para que tienda a volver al centro del area, no a salirse.
            yield return new WaitForSeconds(Random.Range(0.5f, 1)); //tiempo maximo de desplazamiento
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(2, 4)); //tiempo máximo de espera entre desplz
        }
    }

    IEnumerator Disparar()
    {
        yield return new WaitForSeconds(Random.Range(3, 4)); //espera inicial
        while (true)
        {
            GameObject bala = Instantiate(prefabBalas, spawnPoint.position, spawnPoint.rotation);
            bala.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * fuerzaDisparo);
            yield return new WaitForSeconds(Random.Range(0.1f, 1)); //cadencia
        }
    }

    IEnumerator LlamarEsbirros()
    {
        //yield return new WaitForSeconds(20); //espera inicial
        
        
        Instantiate(prefabEsbirro, spawnPointEsbirro1.position, spawnPointEsbirro1.rotation);
        Instantiate(prefabAparicionEsbirro, spawnPointEsbirro1.position, spawnPointEsbirro1.rotation);
        Instantiate(prefabEsbirro, spawnPointEsbirro2.position, spawnPointEsbirro2.rotation);
        Instantiate(prefabAparicionEsbirro, spawnPointEsbirro2.position, spawnPointEsbirro2.rotation);
        //yield return new WaitForSeconds(20); //cadencia

        yield return null;
    }
}
