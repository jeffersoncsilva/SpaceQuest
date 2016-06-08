using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EscolhaPersonagem : MonoBehaviour
{
    public GameObject paiDeTodos;
    public int[] posicaoPaiDeTodos;

    private int telaAtual;
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;

    private bool irLef = true;
    private bool irRight = false;

    // Use this for initialization
    void Start()
    {  
        telaAtual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("X: " + paiDeTodos.transform.position.x);
        Debug.Log("Y: " + paiDeTodos.transform.position.y);
        Debug.Log("Z: " + paiDeTodos.transform.position.z);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveParaEsquerda();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveParaDireita();

        //Swipe();

    }

    private void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    MoveParaEsquerda();
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    MoveParaDireita();
                }
            }
        }
    }

    private void MoveParaEsquerda()
    {
        if (irLef)
        {
            irRight = true;
            telaAtual++;

            paiDeTodos.transform.position = new Vector3(posicaoPaiDeTodos[telaAtual], 139, 0);
            
            if (telaAtual >= 4)
                irLef = false;

           
        }
    }

    private void MoveParaDireita()
    {
        if(irRight)
        {
            irLef = true;
            telaAtual--;

            paiDeTodos.transform.position = new Vector3(posicaoPaiDeTodos[telaAtual], 139, 0); ;


            if (telaAtual <= 0)
                irRight = false;
        }
    }
}
