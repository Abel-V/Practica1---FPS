using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingWater : MonoBehaviour
{
    public int damage = 5;
    private GameObject player;
    public GameObject canvasPanel;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            InvokeRepeating("Ahogar", 0, 3);
            canvasPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CancelInvoke();
            canvasPanel.SetActive(false);
        }
    }

    private void Ahogar()
    {
        player.GetComponent<Player>().ModificarSalud(-damage);
    }
}
