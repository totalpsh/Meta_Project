using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    public float backgroundPosX = 20f;
    public float groundPosX = 20.2f;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();

        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for(int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Background"))
        {
            Vector3 pos = collision.transform.position;
            pos.x += backgroundPosX * numBgCount;
            collision.transform.position = pos;
            return;
        }
        if (collision.CompareTag("Ground"))
        {
            Vector3 pos = collision.transform.position;
            pos.x += groundPosX * numBgCount;
            collision.transform.position = pos;
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision = GetComponent<BoxCollider2D>();

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
