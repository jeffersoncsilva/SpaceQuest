using UnityEngine;
using System.Collections;

public class CriaInimigos : MonoBehaviour {
    private const int QTD_MAXIMA = 5;//para saber quantos inimigos tem que morrer para aumentar a frequencia deles.
    public static int InimigosMortos;

    public GameObject[] inimigos;
    public float timeRespawn;
    public float speed;

    private int qtdInimigosMortos;//para saber quantos ja foram mortos.
    private float lastRespawn;

    void Start()
    {
        InimigosMortos = 0;
        this.lastRespawn = Time.fixedTime;
    }

    void Update()
    {
        if (!Player.GameOver)
        {
            if (Time.fixedTime >= this.lastRespawn + this.timeRespawn)
            {
                CriaInimigo();
            }
            if(InimigosMortos >= this.qtdInimigosMortos + QTD_MAXIMA)
            {
                if (this.timeRespawn > 0.3f)
                    this.timeRespawn -= 0.1f;

                this.speed += 0.2f;
                this.qtdInimigosMortos = InimigosMortos;
            }

        }

    }

    private void CriaInimigo()
    {
        lastRespawn = Time.fixedTime;
        Vector3 pos = SorteiaPosicao();
        GameObject tempPrefab = Instantiate(inimigos[Random.Range(0,3)], pos, transform.rotation) as GameObject;
        tempPrefab.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    private Vector3 SorteiaPosicao()
    {
        return new Vector3(Random.Range(-2.60f, 2.60f), 5.7f, 0);
    }

}
