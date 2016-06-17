using UnityEngine;
using System.Collections;

public class CriaJogador : MonoBehaviour {
    public GameObject nave_1;
    public GameObject nave_2;
    public GameObject nave_3;
    public GameObject target;

	void Start () {
        int jogador = PlayerPrefs.GetInt("nave");
        switch (jogador)
        {
            case 1:
                Instantiate(nave_1, target.transform.position, target.transform.rotation);
                break;
            case 2:
                Instantiate(nave_2, target.transform.position, target.transform.rotation);
                break;
            case 3:
                Instantiate(nave_3, target.transform.position, target.transform.rotation);
                break;
            default:
                Instantiate(nave_1, target.transform.position, target.transform.rotation);
                break;
        }
	}
}
