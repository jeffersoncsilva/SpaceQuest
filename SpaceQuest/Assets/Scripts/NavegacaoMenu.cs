using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NavegacaoMenu : MonoBehaviour
{
    public GameObject cliqueArui;
    public GameObject botoes;
    public GameObject escolhaPersonagem;

    private bool clickHere = true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && clickHere)
        {
            cliqueArui.SetActive(false);
            botoes.SetActive(true);
            clickHere = false;
        }
    }

    public void Jogar()
    {
        botoes.SetActive(false);
        escolhaPersonagem.SetActive(true);
    }

    public void Rank()
    {
        Debug.Log("em breve o rank do jogo.");
    }

    public void Loja()
    {
        Debug.Log("em breve a loja");
    }

    public void Mapa()
    {
        Debug.Log("em breve a busca no mapa.");
    }

}