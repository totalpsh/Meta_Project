using UnityEngine;

public enum GameMode
{
    Lobby,
    Flappy,
    Shooting
}

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public GameMode mode;

    public Vector2 minBounds;
    public Vector2 maxBounds;
    public float smoothSpeed = 5f;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        offset.z = -10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(mode == GameMode.Flappy)
        {
            Vector3 pos = transform.position;
            pos.x = target.position.x + offset.x;
            pos.z = -10f;
            transform.position = pos;
        }

    }

    private void LateUpdate()
    {
        if(mode == GameMode.Lobby)
        {
            Vector3 desiredPosition = transform.position + offset;
            desiredPosition.z = transform.position.z;

            minBounds = target.position;
            maxBounds = target.position;

            // 위치 제한 적용
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
            }
    }
}
