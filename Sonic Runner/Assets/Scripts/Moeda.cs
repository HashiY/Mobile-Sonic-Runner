using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    AudioSource audioS; // ????

    void Start()
    {
        audioS = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) // o sonic nao tem colisor, mas sim a moeda,se colidir com trigger
    {
        if (other.CompareTag("Player")) // verifica com oq colide
        {
            ///audioS.Play();
            ///if (!audioS.isPlaying)
            ///{
                
                
            ///}
            gameObject.SetActive(false); // desativa o obj
            LevelManager.levelManager.SetMoedas(); // chama setmoedas
        }
    }
}
