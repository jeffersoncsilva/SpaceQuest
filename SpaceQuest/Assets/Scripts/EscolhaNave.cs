using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EscolhaNave : MonoBehaviour {

    public Button nave1;
    public Button nave2;
    public Button nave3;
    public Button nave4;

    public Text txt_DescNave;


	// Use this for initialization
	void Start () {
	    
	}
	
    public void SelecionaNave1()
    {
        nave1.image.color = ColorFull(nave1.image.color);
        nave2.image.color = CorTransparente(nave2.image.color);
        nave3.image.color = CorTransparente(nave3.image.color);
        nave4.image.color = CorTransparente(nave4.image.color);
        txt_DescNave.text = "Nave 1";
    }

    public void SelecionaNave2()
    {
        nave2.image.color = ColorFull(nave2.image.color);
        nave1.image.color = CorTransparente(nave1.image.color);
        nave3.image.color = CorTransparente(nave3.image.color);
        nave4.image.color = CorTransparente(nave4.image.color);

        txt_DescNave.text = "Nave 2";
    }

    public void SelecionaNave3()
    {
        nave3.image.color = ColorFull(nave3.image.color);
        nave2.image.color = CorTransparente(nave2.image.color);
        nave1.image.color = CorTransparente(nave1.image.color);
        nave4.image.color = CorTransparente(nave4.image.color);

        txt_DescNave.text = "Nave 3";
    }

    public void SelecionaNave4()
    {
        nave4.image.color = ColorFull(nave4.image.color);
        nave2.image.color = CorTransparente(nave2.image.color);
        nave3.image.color = CorTransparente(nave3.image.color);
        nave1.image.color = CorTransparente(nave1.image.color);

        txt_DescNave.text = "Nave 4";
    }

    public void IniciaJogo()
    {
        Debug.Log("O jogo ira inicar em breve.");
    }

    private Color ColorFull(Color cor)
    {
        cor.a = 1;
        return cor;
    }

    private Color CorTransparente(Color cor)
    {
        cor.a = 0.2f;
        return cor;
    }
}
