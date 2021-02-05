using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // para recarregar a cena

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager; // referencia a class

    private int moedasAtual = 0;
    private bool gamerOver = false;

    private float segundos;
    private int segundosToInt; // transformar o float para int, para o deltaTime
    private int minutos;

    public Text minutosText;
    public Text segundosText;
    public Text moedasText;

    public GameObject gameOverText;

    private bool passouDeFase = false;
    public GameObject passouDeFaseText;
    public int faseALiberar; // cada fase  libera uma outra fase



    // Start is called before the first frame update
    void Awake() // antes do start
    {
        if (levelManager == null) // se for nulo transforma neste obg
        {
            levelManager = this;
        }
        else if (levelManager != this) // se nao for igaul a este objeto, destroi
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamerOver && !passouDeFase) // se n e GO
        {
            segundos += Time.deltaTime; //nao faz se for int , conta os segundos

            if(segundos >= 60) // for maior 
            {
                segundos = 0; 
                minutos++;
                minutosText.text = minutos.ToString();
            }
            segundosToInt = (int)segundos;// esta passando o valor
            segundosText.text = segundosToInt.ToString();
        }
        if (gamerOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// recarrega a cena
        }
        if (passouDeFase && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Menu");
        }
        
    }
    public void SetMoedas() // se o jogador pegar moedas
    {
        moedasAtual++;
        moedasText.text = moedasAtual.ToString();
    }
    public int GetMoedas() // retorna um valor de moedas atual
    {
        return moedasAtual;
    }
    public void ResetMoedas() //se receber dano zera a quantidade de moedas
    {
        moedasAtual = 0;
        moedasText.text = moedasAtual.ToString();
    }
    public void GameOver()
    {
        if (!passouDeFase)
        {
            gamerOver = true;
            gameOverText.SetActive(true);
        }
        
    }
    public void PassouDeFase()
    {
        passouDeFase = true;
        LevelClear.levelClear.LiberarFase(faseALiberar); // para coseguir liberar a proxima faze
        passouDeFaseText.SetActive(true);
        
    }

}
