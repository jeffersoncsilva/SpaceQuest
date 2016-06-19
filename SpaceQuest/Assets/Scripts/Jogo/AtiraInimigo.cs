using UnityEngine;
using System.Collections;

public class AtiraInimigo : MonoBehaviour
{

    public GameObject tiroInimigo;
    public GameObject targetTiro;
    public float timeRespawn;
    public int speed;

    public Sprite spr_estrela;

    private float lastRespawn;
    private Animator anim;
    private bool morto = false;

    void Start()
    {
        lastRespawn = Time.fixedTime;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!Player.GameOver)
        {
            if (Time.fixedTime >= lastRespawn + timeRespawn && !morto)
            {
                CriaBala();
            }
        }
    }

    private void CriaBala()
    {
        lastRespawn = Time.fixedTime;
        GameObject tempPrefab = Instantiate(tiroInimigo, targetTiro.transform.position, targetTiro.transform.rotation) as GameObject;
        tempPrefab.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("TiroJogador"))
        {
            Destroy(coll.gameObject);
            this.anim.SetBool("explosao", true);
            morto = true;
            CriaInimigos.InimigosMortos++;
        }
    }

    public void MudaSprite()
    {
        GetComponent<SpriteRenderer>().sprite = spr_estrela;
            this.transform.tag = "Estrela";
            Debug.Log("TAG: " + transform.tag);
    }
}
