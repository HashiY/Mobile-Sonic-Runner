using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyEnemy : Enemy
{
    public Rigidbody2D projetilPrefab;
    public float ImpulseForce = 5;

    public void JogarCoco()
    {
        Rigidbody2D tempoCoco = Instantiate(projetilPrefab, transform.position, transform.rotation) as Rigidbody2D;//posiçao no obj e rotaçao tb
        tempoCoco.AddForce(Vector2.left * ImpulseForce, ForceMode2D.Impulse);//aplica uma força para a esquerda
    }
}
