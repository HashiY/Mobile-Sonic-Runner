using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progetil : MonoBehaviour
{
    public float DestroyTimer = 3;// para destruir os cocos

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTimer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.GetComponentInParent<PlayerControl>().shield.activeInHierarchy)
            {
                other.GetComponentInParent<PlayerControl>().shield.SetActive(false);
            }
            else
            {
                other.GetComponent<PlayerControl>().TomouDano();// memso q o pl estiver em ataque toma dano
            }
            Destroy(gameObject);
        }
    }
}
