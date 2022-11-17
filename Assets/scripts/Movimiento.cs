using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public float velocidad = 10;
    public string axis = "Vertical";

    // este se esta ejecutando desde antes de iniciar el juego, se utiliza para configuraciones comunmente 
    private void Awake()
    {

    }

    // Todo lo que este aqui inicia con el videojuego
    void Start()
    {

    }

    // esto se actualiza cierta cantidad de veces(60 fps = 60 veces) por segundo.
    void Update()
    {

    }

    // se llama automaticamente a intervalos de tiempo fijo, aqui comunmente van los calculos de fisica
    private void FixedUpdate()
    {
        if (GameManager.InstanciaCompartida.Iniciado == true) {
            mover();
        }
    }

    public void mover(){
        float x = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidad* x);
    }

}
