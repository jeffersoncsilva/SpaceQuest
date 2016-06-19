using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public const string DINHEIRO = "Dinheiro";
    

    public static bool GameOver = false;

    public int speedTiro;
    public Transform targetTiro;
    public GameObject tiro;
    public int velocidadeJogador = 10;
    private bool isRigth;
    private bool isLeft;

    private GameObject gameOverScreen;
    private AudioSource audio;

    private int dinheiro;

    void Start()
    {
        this.gameOverScreen = GameObject.Find("GameOverScreen");
        this.gameOverScreen.SetActive(false);
        isRigth = true;
        isLeft = true;
        GameOver = false;
        dinheiro = 0;
        this.audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!GameOver)
        {
            MovimentaPersonagem();
            VerificaTiro();
        }
    }

    private void VerificaTiro()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject tempPrefab = Instantiate(tiro, targetTiro.position, targetTiro.rotation) as GameObject;
            tempPrefab.GetComponent<Rigidbody2D>().velocity = transform.up * 25;
            this.audio.Play();
        }
    }

    private void MovimentaPersonagem()
    {
        //input pelo teclado

        if (Input.GetKey(KeyCode.LeftArrow) && isLeft)
        {
            transform.Translate(Vector2.left * velocidadeJogador * Time.deltaTime);
            isRigth = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) && isRigth)
        {
            transform.Translate(Vector2.right * velocidadeJogador * Time.deltaTime);
            isLeft = true;
        }


        //input pelo acelerometro
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        if (dir.x < 0 && isLeft)
        {
            transform.Translate(dir * velocidadeJogador);
            isRigth = true;
        }
        else if (dir.x > 0 && isRigth)
        {
            transform.Translate(dir * velocidadeJogador);
            isLeft = true;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("Esquerda"))
        {
            isRigth = true;
            isLeft = false;
        }
        else if (coll.transform.CompareTag("Direita"))
        {
            isRigth = false;
            isLeft = true;
        }
        else if(coll.transform.CompareTag("TiroInimigo") || coll.transform.CompareTag("Inimigo"))
        {
            GameOver = true;
            GravaDinheiro(this.dinheiro);
            this.gameOverScreen.SetActive(true);
            Text txt_dinheiro = GameObject.Find("Txt_GameOver").GetComponent<Text>();
            txt_dinheiro.text = string.Format(""+this.dinheiro);
        }
        else if (coll.transform.CompareTag("Estrela"))
        {
            this.dinheiro += 1;
            Destroy(coll.gameObject);
        }
    }

    private int GetDinheiroSalvo()
    {
        return PlayerPrefs.GetInt(DINHEIRO);
    }

    private void GravaDinheiro(int dinheiro)
    {
        int d = GetDinheiroSalvo();
        PlayerPrefs.SetInt(DINHEIRO, Soma(d, dinheiro));
    }

    private int Soma(int a, int b)
    {
        return a + b;
    }
}