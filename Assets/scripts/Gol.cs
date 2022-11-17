using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gol : MonoBehaviour
{
    public Text MarcadorIzquierdo;
    public int ScoreIzquierdo;
    public Text MarcadorDerecha;
    public int ScoreDerecho;

    private void Awake()
    {
        ScoreDerecho = 0;
        MarcadorDerecha.text = ScoreDerecho.ToString();
        ScoreIzquierdo = 0;
        MarcadorIzquierdo.text = ScoreIzquierdo.ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //lo puedo optimizar pero no me gusta hacer codigos que alguien nuevo no pueda entender.
        if(collision.gameObject.tag == "Bola" && gameObject.tag =="CanchaIzquierda") 
        {
            //Debug.Log("logrado izquierda");
            ScoreDerecho += 1;
            MarcadorDerecha.text = ScoreDerecho.ToString();
            GameManager.InstanciaCompartida.GolMarcado();
        }
        if (collision.gameObject.tag == "Bola" && gameObject.tag == "CanchaDerecha")
        {
            //Debug.Log("logrado derecha");
            ScoreIzquierdo += 1;
            MarcadorIzquierdo.text = ScoreIzquierdo.ToString();
            GameManager.InstanciaCompartida.GolMarcado();
        }
    }
    
}
