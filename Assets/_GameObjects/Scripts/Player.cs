using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject linterna;

    public int salud = 100; //salud inicial
    public int saludMax = 100; //salud máxima (constante)
    private bool esInmune; //si queremos que sea inmune en algun momento
    private bool estaVivo;
    [SerializeField] Text txtVida;
    [SerializeField] Arma[] armas; //arrastrar el arma desde el Inspector. Cogerá su Script "Arma".
    public int armaActiva = 0;

    [SerializeField] GameObject prefabCuchillo;
    [SerializeField] Transform spawnPointCuchillo;
    [SerializeField] float forceCuchillo;

    private bool autoMode = false;

    public GameObject canvasDeadPanel;

    private void Start() {
        txtVida.text = salud.ToString();    //hacemos que se muestre en el Text del Canvas (Asociarlo en el inspector)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {  //Tecla L
            linterna.SetActive(!linterna.activeSelf);   //si está a False, lo cambia a True, y viceversa (!bool lo invierte)
        }
        else if (!autoMode && Input.GetButtonDown("Fire1")) //solo una pulsación
        {  //click mouse izq
            Disparar();
        }
        else if (autoMode && Input.GetButton("Fire1")) //todo el rato que esté pulsado
        {  //click mouse izq
            Disparar();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {  //click mouse izq
            armas[armaActiva].Reload();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambiarArma(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambiarArma(1);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            LanzarCuchillo();
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            autoMode = !autoMode;
        }

        if (salud == 0)
        {
            canvasDeadPanel.SetActive(true);
        }
        else
        {
            canvasDeadPanel.SetActive(false);
        }
    }

    private void CambiarArma(int armaAActivar)
    {
        for(int i = 0; i < armas.Length; i++)
        {
            armas[i].gameObject.SetActive(false); //las desactivamos todas
        }
        armas[armaAActivar].gameObject.SetActive(true); //activamos la que corresponde
        //activo el gameObject (el propio arma) que contiene el script Arma
        armaActiva = armaAActivar;
    }

    public int ModificarSalud(int incremento) { //devuelve la salud (int) tras modificarse. Incremento puede ser negativo
        salud = salud + incremento; //o bien: salud += incremento
        salud = Mathf.Min(salud, saludMax); //cogemos el min entre ambas, para que nunca sea mayor que 100
        salud = Mathf.Max(salud, 0); //cogemos el max entre ambas, para que nunca sea menor que 0
        //llamar a morir si es 0
        txtVida.text = salud.ToString(); //actualizamos el marcador de vida
        return salud;
    }

    /*
    private void RecibirDaño(int damage) { //no haría falta según lo he hecho todo en ModificarSalud
        salud = salud - damage;
        txtVida.text = salud.ToString();
        salud = Mathf.Max(salud, 0);
    }
    */

    private void Morir() {

    }

    private void Disparar() {
        armas[armaActiva].ApretarGatillo(); //llamo al ApretarGatillo del arma
    }

    private void LanzarCuchillo()
    {
        GameObject cuchillo = Instantiate(prefabCuchillo, spawnPointCuchillo.position, spawnPointCuchillo.rotation);
        cuchillo.GetComponent<Rigidbody>().AddForce(spawnPointCuchillo.transform.forward * forceCuchillo);
        //audioSource.PlayOneShot(acDisparo);
        //municionCargador--;
    }
}
