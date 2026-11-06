
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundManager : MonoBehaviour
{
    [SerializeField] ObsticleSpawner obstacleSpawner;
    [Header("Settings")]
    [SerializeField] GameObject obsticle;
    [SerializeField] public List<GameObject> tilePrefabs;
    public int tileCount = 5;
    public float tileLength = 20f;
    public float moveSpeed = 10f;
    [HideInInspector]
    public float width;
    public float partWidth;
    public float left;
    public float middle;
    public float right;
    public float randomX;

    private readonly List<Transform> tiles = new List<Transform>();

    public static GroundManager instance;

    void Awake()
    {
        instance = this;

        if (obstacleSpawner == null)
            obstacleSpawner = GetComponent<ObsticleSpawner>();
    }

    void Start()
    {
        for (int i = 0; i < tileCount; i++)
        {
            int randomeNumber = Random.Range(0, tilePrefabs.Count);
            Vector3 spawnPosition = transform.position
                + Vector3.forward * (i * tileLength);

            GameObject tile = Instantiate(
                tilePrefabs[randomeNumber],
                spawnPosition,
                Quaternion.identity
            );

            width = tile.transform.localScale.x;
            partWidth = width / 3f;

            left = tile.transform.localScale.x - partWidth;
            middle = tile.transform.position.x;
            right = tile.transform.localScale.x + partWidth;

            int randomNumber = Random.Range(0, 4);

            randomX = 0;
            print(randomNumber);
            switch (randomNumber)
            {
                case 0:
                    randomX = left;
                    break;

                case 1:
                    randomX = middle;
                    break;

                case 2:
                    randomX = right;
                    break;
            }


            obstacleSpawner.SpawnObstacle(tile.transform);
            tiles.Add(tile.transform);
        }
    }

    void Update()
    {
        // حرکت همه پنل‌ها به سمت عقب
        foreach (Transform tile in tiles)
        {
            tile.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        // بررسی پنل انتهایی
        Transform firstTile = tiles[0];

        if (firstTile.position.z < -tileLength)
        {
            Transform lastTile = tiles[tiles.Count - 1];

            // انتقال پنل قدیمی به جلوی آخرین پنل
            firstTile.position = lastTile.position
                + Vector3.forward * tileLength;

            // انتقال پنل به انتهای لیست
            tiles.RemoveAt(0);
            tiles.Add(firstTile);

            firstTile.position = lastTile.position
        + Vector3.forward * tileLength;

            // ساخت مجدد مانع با موقعیت و نوع تصادفی
            obstacleSpawner.SpawnObstacle(firstTile);

            // انتقال پنل به انتهای لیست
            tiles.RemoveAt(0);
            tiles.Add(firstTile);
        }
    }
}
