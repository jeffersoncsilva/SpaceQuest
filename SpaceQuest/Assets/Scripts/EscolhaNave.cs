using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolhaNave : MonoBehaviour {

    //public Button nave1;
    //public Button nave2;
    //public Button nave3;
    //public Button nave4;

    //public Text txt_DescNave;

    public void IniciaJogo(int nave)
    {
        Debug.Log("Iniciando jogo com a Nave: " + nave);
        PlayerPrefs.SetInt("nave", nave);
        SceneManager.LoadScene("jogo");

    }

    //private void SetaTransparenciaBotoes()
    //{
    //    nave4.image.color = CorTransparente(nave2.image.color);
    //    nave2.image.color = CorTransparente(nave2.image.color);
    //    nave3.image.color = CorTransparente(nave3.image.color);
    //    nave1.image.color = CorTransparente(nave1.image.color);
    //}

    //private Color ColorFull(Color cor)
    //{
    //    cor.a = 1;
    //    return cor;
    //}

    //private Color CorTransparente(Color cor)
    //{
    //    cor.a = 0.2f;
    //    return cor;
    //}
}
