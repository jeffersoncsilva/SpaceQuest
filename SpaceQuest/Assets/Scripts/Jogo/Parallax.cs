using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
    public GameObject fundo_1;
    public GameObject fundo_2;

    public float velocidadeScroll;
    public Vector3 origemTopo;

    public float posicaoY = 11;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (SaiuTela(fundo_1))
        {
            fundo_1.transform.position = origemTopo;
        }
        if (SaiuTela(fundo_2))
            fundo_2.transform.position = origemTopo;

        

        
        fundo_1.transform.Translate(transform.up * -velocidadeScroll * Time.deltaTime);
        fundo_2.transform.Translate(transform.up * -velocidadeScroll * Time.deltaTime);
    }

    private bool SaiuTela(GameObject f)
    {
        return f.transform.position.y <= this.posicaoY;
    }

    void OnBecameInvisible()
    {
        transform.position = this.origemTopo;
        Debug.Log("saiu da tela. voltando para cima.");
    }
}
