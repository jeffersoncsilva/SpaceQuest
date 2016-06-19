using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReiniciaJogo : MonoBehaviour {

    public void MenuInicioJogo()
    {
        SceneManager.LoadScene("menu");
    }

    public void ReiniciarJogo()
    {
        Player.GameOver = false;
       
        SceneManager.LoadScene("jogo");
    }

}
