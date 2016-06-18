using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NavegacaoMenu : MonoBehaviour
{
    public GameObject cliqueAqui;
    public GameObject menuInicio;
    public GameObject escolhaPersonagem;
    public GameObject telaProcuraItens;
    public GameObject elementoMapa;
    public GameObject detalhes;
    private bool clickHere = true;

    //variaveis referente a busca da imagem do mapa.
    string url = string.Empty;
   
    private float lat = -16.669830f;
    private float lon = -49.235616f;
    //private LocationInfo li;
    private int zoom = 14;
    private int mapWidth = 800;
    private int mapHeigh = 600;
    private int scale = 1;

    public enum mapType { roadmap, satellite, hybrid, terrain };
    public mapType mapSelected;

    void Start()
    {
        DesativaTelas();
        menuInicio.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && clickHere)
        {
            cliqueAqui.SetActive(false);
            menuInicio.SetActive(true);
            clickHere = false;
        }
    }

    public void Jogar()
    {
        menuInicio.SetActive(false);
        escolhaPersonagem.SetActive(true);
    }

    public void Voltar()
    {
        DesativaTelas();
        this.menuInicio.SetActive(true);
        this.detalhes.SetActive(true);
    }

    public void Loja()
    {
        Debug.Log("em breve a loja");
    }

    public void ProcuraItens()
    {
        Debug.Log("em breve a busca no mapa.");
        DesativaTelas();
        telaProcuraItens.SetActive(true);
        StartCoroutine("MostraImagemMapa");
        detalhes.SetActive(false);
    }

    private void DesativaTelas()
    {
        cliqueAqui.SetActive(false);
        menuInicio.SetActive(false);
        escolhaPersonagem.SetActive(false);
        telaProcuraItens.SetActive(false);
    }

    private IEnumerator MostraImagemMapa()
    {
        string key = "&key=AIzaSyDzGBAGoGV7og3qzlQuDHdVmGO0IwkYWuw";
        string exampleUrl = string.Format("https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon + "&zoom=14&size=400x400&" + key);
        WWW www = new WWW(exampleUrl);
        yield return www;
        elementoMapa.GetComponent<Renderer>().material.mainTexture = www.texture;

    }
}