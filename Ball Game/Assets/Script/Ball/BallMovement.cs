using Unity.Mathematics;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float clampForMovement = 10f;

    void Update()
    {
        float movement = Mathf.Clamp(Input.Instance.input.x / 200f, -1f, 1f);

        Vector3 pos = transform.position;

        pos.x += movement * movementSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -clampForMovement, clampForMovement);

        transform.position = pos;
    }
}
