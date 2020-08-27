using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    [SerializeField] float spawnRate = 5f;
    [SerializeField] int columnPoolSize = 5;
    [SerializeField] float yMin = -5f;
    [SerializeField] float yMax = 5f;

    private float timeSinceLastSpawn;
    private float xSpawnPosition = 10f;
    private int currentColumn = 0;

    [SerializeField] GameObject columnPrefab;
    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, 25f);
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i<columns.Length; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float ySpawnPosition = Random.Range(yMin, yMax);
            columns[currentColumn].transform.position = new Vector2(xSpawnPosition, ySpawnPosition);
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }

    }
}
