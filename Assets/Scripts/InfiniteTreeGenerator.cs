using UnityEngine;

public class InfiniteTreeGenerator : MonoBehaviour
{
    public Transform player;
    public GameObject treeSegmentPrefab;
    public GameObject[] objectPrefabs; // Banane, plateforme, ennemi...
    public float segmentHeight = 5f;
    public int segmentsAhead = 5;

    private float highestY;

    void Start()
    {
        highestY = transform.position.y;
    }

    void Update()
    {
        if (player == null || treeSegmentPrefab == null) return;

        // Si le joueur approche du haut, ajouter un segment
        while (player.position.y + segmentsAhead * segmentHeight > highestY)
        {
            GenerateSegment(highestY);
            highestY += segmentHeight;
        }
    }

    void GenerateSegment(float y)
    {
        // Crée un segment d’arbre
        Instantiate(treeSegmentPrefab, new Vector3(0, y, 0), Quaternion.identity);

        // Génère un objet aléatoire (50% de chance)
        if (Random.value > 0.5f && objectPrefabs.Length > 0)
        {
            GameObject prefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
            float xOffset = Random.Range(-2f, 2f);
            Instantiate(prefab, new Vector3(xOffset, y + 1f, 0), Quaternion.identity);
        }
    }
}
