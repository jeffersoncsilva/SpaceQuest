using UnityEngine;
using System.Collections;

public class AtiraInimigo : MonoBehaviour
{

    public GameObject tiroInimigo;
    public GameObject targetTiro;
    public float timeRespawnTiro = 1.5f;
    public int velocidadeTiro;

    public Sprite spr_estrela;

    private float lastRespawn;
    private Animator anim;
    private bool morto = false;
    private Rigidbody2D rigid;
    private AudioSource audio;

    private int vida = 100;

    void Start()
    {
        CriaBala();
        anim = GetComponent<Animator>();
        this.rigid = GetComponent<Rigidbody2D>();
        this.audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!Player.GameOver)
        {
            if (Time.fixedTime >= lastRespawn + timeRespawnTiro && !morto)
            {
                CriaBala();
            }
        }
    }

    private void CriaBala()
    {
        lastRespawn = Time.fixedTime;
        GameObject tempPrefab = Instantiate(tiroInimigo, targetTiro.transform.position, targetTiro.transform.rotation) as GameObject;
        tempPrefab.GetComponent<Rigidbody2D>().velocity = transform.up * velocidadeTiro;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("TiroVermelho") && !morto)
            AplicaDano(50, coll);

        else if (coll.transform.CompareTag("TiroAzul") && !morto)
            AplicaDano(100, coll);

        else if (coll.transform.CompareTag("TiroVerde") && !morto)
            AplicaDano(40, coll);

    }

    public void MudaSprite()
    {
        GetComponent<SpriteRenderer>().sprite = spr_estrela;
            this.transform.tag = "Estrela";
            Debug.Log("TAG: " + transform.tag);
    }

    private void ReduzVelocidade()
    {
        this.rigid.velocity = Vector3.zero;
        this.rigid.angularVelocity = 0;

        this.rigid.velocity = transform.up * 1;
    }

    private void AplicaDano(int dano, Collider2D coll)
    {
        this.vida -= dano;
        Destroy(coll.gameObject);
        VerificaMorteJogador();
    }

    private void VerificaMorteJogador()
    {
        if(this.vida <= 0)
        {
            this.audio.Play();
            this.anim.SetBool("explosao", true);
            this.morto = true;
            CriaInimigos.InimigosMortos++;
            ReduzVelocidade();
        }
    }

}
