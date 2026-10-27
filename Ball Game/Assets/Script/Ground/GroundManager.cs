
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject obsticle;
    [SerializeField] public List<GameObject> tilePrefabs;
    public int tileCount = 5;
    public float tileLength = 20f;
    public float moveSpeed = 10f;

    private readonly List<Transform> tiles = new List<Transform>();

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

            float width = tile.transform.localScale.x;
            float partWidth = width / 3f;

            float left = tile.transform.localScale.x - partWidth;
            float middle = tile.transform.position.x;
            float right = tile.transform.localScale.x + partWidth;

            int rndome = Random.Range(0, 3);
            print(rndome);
            switch (rndome)
            {
                case 0:
                    Instantiate(obsticle, new Vector3(left, 0, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(obsticle, new Vector3(middle, 0, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(obsticle, new Vector3(right, 0, 0), Quaternion.identity);
                    break;
            }

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
        }
    }
}
