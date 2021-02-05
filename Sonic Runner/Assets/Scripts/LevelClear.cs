using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClear : MonoBehaviour
{
    public static LevelClear levelClear;

    private int faseAtual = 1;

    // Start is called before the first frame update
    void Awake()
    {
        if (levelClear == null) // se for nulo
        {
            levelClear = this; // transforma o objeto em level clear
        }
        else if(levelClear != this) // se nao for esse ogj
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);//garante q so tenha um LC em jogo e nao destroi quando carregar outras cenas
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LiberarFase(int faseALiberar) // a fase 1 libera a 2 , se jogar de novo a fase 1 nao libera denovo a 2
    {
        if(faseALiberar > faseAtual)
        {
            faseAtual = faseALiberar;
        }
    }
    public int GetFaseAtual() //para retornar o valor de fase atual
    {
        return faseAtual;
    }
        
}
