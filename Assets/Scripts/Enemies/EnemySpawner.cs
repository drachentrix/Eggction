using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] groundUnits;
    [SerializeField] private GameObject[] airUnits;

    [SerializeField] private float spawnTime = 3f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("SpawnUnit", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnUnit()
    {
        GameObject unit;

        if (Random.value > 0.5f)
        {
            unit = airUnits[0];
        }
        else
        {
            unit = groundUnits[0];
        }

        GameObject clone = Instantiate(unit);

        clone.SetActive(true);
    }
}
