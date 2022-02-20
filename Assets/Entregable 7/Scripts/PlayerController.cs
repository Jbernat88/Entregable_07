using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8f;
    private Rigidbody playerRigidbody;
    private float yRange = 13.8f;
    private float lowerlim = 0f;
    private float impulse = 1f;
    public bool GameOver;
    public ParticleSystem explosionParticleSystem; //Particulas de la bomba
    public ParticleSystem fireWorkParticleSystem; //Particulas de la moneda
    private int monedasRecolectables = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //El player salta con el espacio.
        if (Input.GetKeyDown(KeyCode.Space))
        {
           playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
       
        //Si toca el techo te impulsa hacia abajo.
        if (transform.position.y >= yRange)
        {
            playerRigidbody.AddForce(Vector3.down * impulse, ForceMode.Impulse);
        }

    }
    private void OnCollisionEnter(Collision otherCollider)
    {

        if (!GameOver)
        {
            //etiquetas para diferenciar colisiones
            if (otherCollider.gameObject.CompareTag("Ground")) //Suelo
            {
                GameOver = true;
            }


            if (otherCollider.gameObject.CompareTag("Bomb")) //Bomba
            {
                Destroy(otherCollider.gameObject); //Si el player colisiona con la bomba la bomba se destruye.

                explosionParticleSystem.Play(); //Se instancian particulas cuando se destruye el objeto

                Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);

                GameOver = true;
            }

            if (otherCollider.gameObject.CompareTag("Money")) //Moneda
            {
                Destroy(otherCollider.gameObject);

                monedasRecolectables++; //Cada vez que cogemos una moneda sumamos 1 en el marcador

                Debug.Log(monedasRecolectables);

                fireWorkParticleSystem.Play(); //Particualas

                Instantiate(fireWorkParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
            }

        }

    }


}
