using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public static bool GameOver = false;

    public int speed;

    private bool isRigth;
    private bool isLeft;


    void Start()
    {
        isRigth = true;
        isLeft = true;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            MovimentaPersonagem();
        }
    }

    private void MovimentaPersonagem()
    {
        //input pelo teclado
        /*
        if (Input.GetKey(KeyCode.LeftArrow) && isLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            isRigth = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) && isRigth)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            isLeft = true;
        }
        */
        //input pelo acelerometro
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;
        transform.Translate(dir * speed);
        
    }

    void OnCollisionEnter2D(Collision2D coll)
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
    }


}