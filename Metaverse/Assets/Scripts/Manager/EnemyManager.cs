using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] List<Rect> SpawnAreas;
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, 0.3f);

    private List<EnemyController> activeEnemies = new List<EnemyController>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        if (SpawnAreas == null) return;
        
        Gizmos.color = gizmoColor;
        foreach(Rect area in SpawnAreas)
        {
            Vector3 center = new Vector3(area.x + area.width / 2, area.y + area.height / 2);
            Vector3 size = new Vector3(area.width, area.height);
            Gizmos.DrawCube(center, size);
        }
    }
}
