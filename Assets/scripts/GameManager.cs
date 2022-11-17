using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR 
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{

    public static GameManager InstanciaCompartida = null;
    public bool Iniciado = false;
    public Button boton;
    public Text Titulo;
    GameObject Bola;
    Vector2 UltimaDireccion;

    public Text VictoriaPlayer1;
    public Text VictoriaPlayer2;

    private void Update()
    {
        TerminarJuego();
    }
    private void Awake()
    {
        if (InstanciaCompartida == null)
        {
            InstanciaCompartida = this;
        }
    }

    public void IniciarJuego()
    {
        Iniciado = true;
        boton.gameObject.SetActive(false);
        Titulo.gameObject.SetActive(false);
        Bola = GameObject.FindGameObjectWithTag("Bola");
    }

    public void GolMarcado()
    { 
        Bola.transform.position = Vector2.zero;
        UltimaDireccion = new Vector2(-Bola.GetComponent<Rigidbody2D>().velocity.x, 0);
        Bola.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Invoke("NuevaRonda", 2f);
    }

    public void NuevaRonda()
    {

        //por medio del mismo script MovimientoBola lo exporto
        MovimientoBola ScriptBola = Bola.GetComponent<MovimientoBola>();
        Bola.GetComponent<Rigidbody2D>().velocity = UltimaDireccion.normalized * ScriptBola.velocidad;

    }
    
    public void TerminarJuego()
    {

        GameObject CanchaDerecha = GameObject.FindGameObjectWithTag("CanchaDerecha");
        Gol ScriptGol = CanchaDerecha.GetComponent<Gol>();
        GameObject CanchaIzquierda = GameObject.FindGameObjectWithTag("CanchaIzquierda");
        Gol ScriptGol2 = CanchaIzquierda.GetComponent<Gol>();
        
        if ( ScriptGol.ScoreIzquierdo >= 5 )
        {
            VictoriaPlayer2.gameObject.SetActive(true);
            Invoke("ReiniciarJuego", 2f);
        }

        else if (ScriptGol2.ScoreDerecho >= 5)
        {
            VictoriaPlayer1.gameObject.SetActive(true);
            Invoke("ReiniciarJuego", 2f);
        }
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
