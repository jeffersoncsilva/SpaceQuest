using UnityEngine;
using System.Collections;

public class EscolhaPersonagem : MonoBehaviour
{
    private int telaAtual = 1;
    private Animator anim;


    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;

    private bool irLef = true;
    private bool irRight = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveEsquerda();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveDireita();
        }

        Swipe();
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
                    MoveDireita();
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    MoveEsquerda();
                }
            }
        }
    }

    private void MoveDireita()
    {
        if (telaAtual + 1 <= 3)
        {
            string trigguer = "Tela" + telaAtual;
            anim.SetTrigger(trigguer);
            telaAtual++;
        }
    }

    private void MoveEsquerda()
    {
        if (telaAtual - 1 >= 1)
        {
            telaAtual--;
            string trigguer = "Volta" + telaAtual;
            anim.SetTrigger(trigguer);
        }
    }

}
