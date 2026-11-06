using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> obsticles;

    private Dictionary<Transform, GameObject> spawnedObstacles = new Dictionary<Transform, GameObject>();

    

    public void SpawnObstacle(Transform tile)
    {
        // حذف مانع قبلی این تایل
        if (spawnedObstacles.ContainsKey(tile))
        {
            Destroy(spawnedObstacles[tile]);
            spawnedObstacles.Remove(tile);
        }

        if (obsticles.Count == 0)
            return;

        // انتخاب تصادفی نوع مانع
        int randomNumber = Random.Range(0, obsticles.Count);

        float width = tile.localScale.x;
        float partWidth = width / 3f;

        float center = tile.position.x;

        float[] positions =
        {
            center - partWidth,
            center,
            center + partWidth
        };

        // انتخاب تصادفی موقعیت
        int randomPosition = Random.Range(0, positions.Length);

        Vector3 spawnPosition = new Vector3(
            positions[randomPosition],
            0,
            tile.position.z
        );

        // ساخت مانع
        GameObject obstacle = Instantiate(
            obsticles[randomNumber],
            spawnPosition,
            Quaternion.identity,
            tile
        );

        spawnedObstacles.Add(tile, obstacle);
    }
}