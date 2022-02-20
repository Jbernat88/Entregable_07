using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPosition;
    public GameObject[] obstaclePrefab;
    private PlayerController playerControllerScript; //Variable para llamar al otro script
    private float yRangeMax = 10f;
    private float yRangeMin = 3f;
    private float randomY;
    private int randomIndex;
    public float startDelay;
    public float repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //Llama al otro script para reclamar la variable de GameOver

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);//Sale el primero y dependiendo del valor del repeat se espaunean luego los demas
    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.GameOver)
        {
            randomIndex = Random.Range(0, obstaclePrefab.Length);
            spawnPosition = RandomSpawnPosition();

            Instantiate(obstaclePrefab[randomIndex], spawnPosition, obstaclePrefab[randomIndex].transform.rotation); //Instancia los obstaculos
        }
    }

    public Vector3 RandomSpawnPosition()
    {
        randomY = Random.Range(yRangeMin, yRangeMax); //Random posición entre los limites marcados
        return new Vector3(20, randomY, 0);
    }
}
