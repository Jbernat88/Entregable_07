using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerControllerScript; //Variable para llamar al otro script
    public float speed = 8f;
    private float leftLim = -20f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //Llama al otro script para reclamar la variable de GameOver

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.GameOver) //Llamamos a la funcion Game Object creada en el script de PlayerController
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); //Movimiento de los obstaculos.
        }
        if(transform.position.x<leftLim) //Si ela posicion es menor que el limite se instancia la función
        {
            Destroy(gameObject);
        }

    }
}
