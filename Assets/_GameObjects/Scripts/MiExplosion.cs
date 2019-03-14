using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiExplosion : MonoBehaviour
{

    [SerializeField] AudioSource explosionSound;
    public const float TIME_TO_DESTROY = 3;

    // Start is called before the first frame update
    void Start()
    {
        explosionSound.Play();
        Destroy(this.gameObject, TIME_TO_DESTROY);
    }
}
