using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool jump = false;
    private int direction = 0; // ???


    public float moveForce = 20;// 走り始めに加える力
    public float maxSpeed = 10;
    public float jumpForce = 400;// ジャンプ時に加える力
    public Transform groundCheck;// 地面と接地しているか管理するフラグ
    Vector3 velocity;//???

    private bool grounded = false;
    private float hForce = 1; // o player esta indo sempre para a direita
    private bool spinDash = false;
    private Rigidbody2D rb2d;
    private bool estaVivo = true;

    private Animator anim;

    public Rigidbody2D moedasPrefab;
    public Transform moedasSpawner;
    public bool tomouDano = false;

    public GameObject shield;

    public AudioClip spinSounds;
    private AudioSource audioS;
    public AudioClip deathSounds;
    public AudioClip jumpSounds;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); // se esta no chao
        //linecast se colidir com o chao verifica se e verdadeiro ou falso
        anim.SetBool("OnGround", grounded);// se o valor de g for verdadeiro ativa o palametro ONG

        if (grounded) //se verdadiro
        {
            anim.SetBool("Jump", false); //para quando ele chegra no chao e parar a animaçao
        }
        anim.SetBool("SpinDash", spinDash); // igual v e fpara anim

        if (spinDash && !tomouDano)
        {
            hForce -= 0.01f; // diminui a cada flam ,para o sonic dimuir aos poucos
            if(rb2d.velocity.x <= 1) // para
            {
                spinDash = false;
                hForce = 1;
            }
        }
    }
 
    
    private void FixedUpdate() //corre, fisica do jogo
    {     
        if (estaVivo) // se estiver vivo
        {
            anim.SetFloat("Speed", rb2d.velocity.x);

            rb2d.AddForce(Vector2.right * hForce * moveForce); // move atraves da força 

            if (rb2d.velocity.x > maxSpeed) // limita a velocidade
            {
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);// deixa a velo = 1 e multi por maxS, para limitar a velo

            }
            if (jump && !tomouDano)
            {
                anim.SetBool("Jump", true);
                rb2d.AddForce(new Vector2(0, jumpForce)); // força q ele consegue pular
                jump = false; // para nao pular de novo
            }
        }
        


        /*direction = -1;
        if (estaVivo)
        {
            anim.SetFloat("Speed", rb2d.velocity.x);
            rb2d.AddForce(Vector2.left * hForce * moveForce);

            if (rb2d.velocity.x > maxSpeed)
            {
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

            }


        }*/









    }

    public void Jump() // pular
    {
        if (grounded)
        {
            ///audioS.clip = jumpSounds;
            ///audioS.Play();
            rb2d.AddForce(Vector2.up * jumpForce);
            jump = true;
        }
        
    }

    public void SpinDash()
    {
       if (grounded) // se tiver no chao
       {
            ///audioS.clip = spinSounds;
            ///audioS.Play();
            spinDash = true;
       }
    }
    public void TerminouDano()
    {
        tomouDano = false;
        hForce = 1;
    }
    public void TomouDano()
    {
        if (tomouDano) // tem intervalo para nao se mexer e nao tomar dano
        {
            return;
        }
        else if(estaVivo && !tomouDano)
        {
            ///audioS.clip = deathSounds;
            ///audioS.Play();
            if (LevelManager.levelManager.GetMoedas() > 0) // isso pode ser modificado em vidas
            {
                tomouDano = true;
                spinDash = false;
                jump = false;
                anim.SetBool("Jump", false);
                rb2d.velocity = Vector2.zero; // para
                anim.SetTrigger("Dano"); 
                rb2d.AddForce(new Vector2(-10, 10), ForceMode2D.Impulse);//e jogado para tras quand receb dano
                hForce = 0;

                int totalDeMoedas = LevelManager.levelManager.GetMoedas(); // para nao declarar toda hora
                if (totalDeMoedas >= 10)
                {
                    totalDeMoedas = 10;
                }
                LevelManager.levelManager.ResetMoedas();
                for (int i = 0; i < totalDeMoedas; i++)
                {
                    Rigidbody2D tempMoeda = Instantiate(moedasPrefab, moedasSpawner.position, Quaternion.identity) as Rigidbody2D;
                    int randomForceX = Random.Range(-20, 5);// pega um valor do 1 a ultimo menos 1 = -20 a 4 
                    int randomForceY = Random.Range(1, 10);
                    tempMoeda.AddForce(new Vector2(randomForceX, randomForceY), ForceMode2D.Impulse);
                }

            }
            else
            {
                Morreu();
            }
        }
    }
    public void Morreu() 
    {
        if (estaVivo)
        {
            ///audioS.clip = deathSounds;
            ///audioS.Play();
            estaVivo = false;
            spinDash = false;
            jump = false;
            anim.SetBool("Jump", false);
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            anim.SetBool("Morreu", true);
            Invoke("GameOver", 2f);
        }
    }
    public void GameOver()
    {
        LevelManager.levelManager.GameOver(); // depois de um tempo q morre aparece
    }
   /* public void Correr()
    {
        if (estaVivo) // se estiver vivo
        {
            anim.SetFloat("Speed", rb2d.velocity.x);

            rb2d.AddForce(Vector2.right * hForce * moveForce); // move atraves da força 

            if (rb2d.velocity.x > maxSpeed) // limita a velocidade
            {
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);// deixa a velo = 1 e multi por maxS, para limitar a velo

            }
        }
    }*/
}
