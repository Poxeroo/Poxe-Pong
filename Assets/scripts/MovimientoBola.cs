using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBola : MonoBehaviour
{
    public AudioClip Choque;
    private AudioSource Efectos;

    public float velocidad = 10;
    private bool SeMovio = false;
    // este se esta ejecutando desde antes de iniciar el juego, se utiliza para configuraciones comunmente 
    private void Awake()
    {

    }

    // Todo lo que este aqui inicia con el videojuego
    void Start()
    {
        Efectos = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (GameManager.InstanciaCompartida.Iniciado == true && SeMovio == false) {
            MoverBola();
            SeMovio = true;
        }
    }

    // solo digo que al iniciar el juego se inicie un movimiento de bala a la derecha
    public void MoverBola()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right*velocidad;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RaquetaIzquierda") {
            float x = Raquetaso(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            Vector2 direccion = new Vector2(1, x).normalized;

            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            Efectos.clip = Choque;
            Efectos.Play();
        }

        if (collision.gameObject.name == "RaquetaDerecha")
        {
            float x = Raquetaso(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            Vector2 direccion = new Vector2(-1, x).normalized;

            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            Efectos.clip = Choque;
            Efectos.Play();
        }

    }

    float Raquetaso(Vector2 PosicionBola, Vector2 PosicionRaqueta, float TamañoRaqueta)
    {
        return (PosicionBola.y - PosicionRaqueta.y) / TamañoRaqueta;
    }

}
