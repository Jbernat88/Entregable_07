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
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //El player salta con el espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
           playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
       
        
        if (transform.position.y >= yRange)
        {
            playerRigidbody.AddForce(Vector3.down * impulse, ForceMode.Impulse);
        }

        
        


    }

}
