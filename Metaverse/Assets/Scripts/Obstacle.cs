using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float highPosY = 1f;
    private float lowPosY = -1f;

    private float holeSizeMin = 10f;
    private float holeSizeMax = 12f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);

        float halfHoleSize = holeSize / 2f;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);

        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerFlappyController player = collision.GetComponent<PlayerFlappyController>();
        if (player != null)
        {
            GameManager.Instance.AddScore(1);
        }
    }
}
