using UnityEngine;
using System.Collections;

public class AtiraInimigo : MonoBehaviour
{

    public GameObject tiroInimigo;
    public GameObject targetTiro;
    public float timeRespawn;
    public int speed;
    private float lastRespawn;


    void Start()
    {
        lastRespawn = Time.fixedTime;
    }

    void Update()
    {
        if (Time.fixedTime >= lastRespawn + timeRespawn)
        {
            CriaBala();
        }
    }

    private void CriaBala()
    {
        lastRespawn = Time.fixedTime;
        GameObject tempPrefab = Instantiate(tiroInimigo, targetTiro.transform.position, targetTiro.transform.rotation) as GameObject;
        tempPrefab.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
