using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> groundPrefabs;
    [SerializeField] float groundMaxNumber = 10f;

    List<GameObject> grounds;

    void Start()
    {
        
    }
    void Update()
    {
        int randomeNumber = Random.Range(0, groundPrefabs.Count);
    
        print(randomeNumber);
    }
}
