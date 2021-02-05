using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CarregarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void CarregarFase(int fase) // clicar para abrir a fase 5 mas atual esta na 2 , nao abre
    {
        if (fase <= LevelClear.levelClear.GetFaseAtual())
        {
            SceneManager.LoadScene(fase);
        }
        else
        {
            return;
        }
    }
}
