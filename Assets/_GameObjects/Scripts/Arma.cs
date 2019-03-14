using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{
    public enum Estado { Disponible, Descargada, Recargando, Disparando, DescargadaSilencio};
    public Estado estado = Estado.Disponible;

    [SerializeField] GameObject prefabProyectil;
    [SerializeField] GameObject prefabFogonazo;
    [SerializeField] Transform spawnPoint;
    private AudioSource audioSource;
    [SerializeField] float force = 1000;

    [SerializeField] float cadencia; //tiempo entre disparo
    [SerializeField] int capacidadCargador;
    [SerializeField] int numeroCargadores;
    [SerializeField] int maxNumCargadores;
    [SerializeField] float tiempoRecarga;
    [SerializeField] int municionCargador; //disponible en el cargador
    [SerializeField] AudioClip acDisparo;
    [SerializeField] AudioClip acGatillazo;
    [SerializeField] AudioClip acRecarga;
    [SerializeField] AudioClip acCambioArma;

    public Camera secondCamera;

    [SerializeField] Text txtMunicion;
    [SerializeField] Text txtCargadores;



    private void Start() {
        audioSource = GetComponent<AudioSource>();
        //busca dentro de los componentres del arma el AudioSource, en el cual estarán los distintos audios

        secondCamera.enabled = false;

        //txtMunicion.text = municionCargador.ToString();
        //txtCargadores.text = numeroCargadores.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            secondCamera.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            secondCamera.enabled = false;
        } 
        //txtMunicion.text = "Munición: " + municionCargador.ToString();
        //txtCargadores.text = "Cargadores: " + numeroCargadores.ToString();
        txtMunicion.text = municionCargador.ToString();
        txtCargadores.text = numeroCargadores.ToString();
    }


    public void ApretarGatillo() {
        if(estado == Estado.Disponible) {
            Disparar();
        } else if (estado == Estado.Descargada) {
            audioSource.PlayOneShot(acGatillazo);
            estado = Estado.DescargadaSilencio;
            Invoke("NuevoGatillazo", cadencia);
        }
    }

    public void Disparar() {
        if (estado == Estado.Disponible) {
            GameObject proyectil = Instantiate(prefabProyectil, spawnPoint.position, spawnPoint.rotation);
            proyectil.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * force);
            audioSource.PlayOneShot(acDisparo);
            municionCargador--;
            Instantiate(prefabFogonazo, spawnPoint.position, spawnPoint.rotation);
            if (municionCargador == 0) {
                estado = Estado.Descargada;
            } else {
                estado = Estado.Disparando;
                Invoke("ActivarArma", cadencia); //puede volver a disparar una vez se ha pasado el tiempo de cadencia
            }
        }
    }

    public void Reload() {
        if (estado != Estado.Recargando && numeroCargadores > 0 && municionCargador < capacidadCargador) {
            estado = Estado.Recargando;
            numeroCargadores--;
            municionCargador = capacidadCargador;
            audioSource.PlayOneShot(acRecarga);
            Invoke("ActivarArma", tiempoRecarga);
        }
    }

    private void ActivarArma() {
        this.estado = Estado.Disponible;
    }

    public bool AñadirCargador() {
        bool ok = false;
        if (numeroCargadores < maxNumCargadores) {
            numeroCargadores++;
            ok = true;
        }
        return ok;
    }
    
    private void NuevoGatillazo()
    {
        estado = Estado.Descargada;
    }
    
}
