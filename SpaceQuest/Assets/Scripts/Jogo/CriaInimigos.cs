using UnityEngine;
using System.Collections;

public class CriaInimigos : MonoBehaviour {

    public GameObject[] inimigos;
    public float timeRespawn;
    public int speed;
    private float lastRespawn;

    void Start()
    {
        lastRespawn = Time.fixedTime;
    }

    void Update()
    {
        if (!Player.GameOver)
        {
            if (Time.fixedTime >= lastRespawn + timeRespawn)
            {
                CriaInimigo();
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
