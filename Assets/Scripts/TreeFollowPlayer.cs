using UnityEngine;

public class TreeFollowPlayer : MonoBehaviour
{
    public float speed = 2f;
    public float resetPositionY = 8f;   // Quand l’arbre sort en bas
    public float startPositionY = -16f;    // Il revient juste au-dessus
    public GameObject[] objectPrefabs;    // Liste des objets à faire apparaître (bananes, pièges...)

    void Update()
    {
        // Fait défiler l'arbre vers le bas
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Lorsqu'il sort de l'écran
        if (transform.position.y <= resetPositionY)
        {
            // Le replacer en haut
            Vector3 newPos = transform.position;
            newPos.y = startPositionY;
            transform.position = newPos;

            // Générer un objet aléatoire avec 50% de chance
            if (objectPrefabs.Length > 0 && Random.value > 0.5f)
            {
                int index = Random.Range(0, objectPrefabs.Length);
                GameObject prefab = objectPrefabs[index];

                // Le placer au-dessus du segment d’arbre
                float xOffset = Random.Range(-2f, 2f); // léger décalage horizontal
                Vector3 spawnPos = new Vector3(transform.position.x + xOffset, transform.position.y + 1f, 0f);
                Instantiate(prefab, spawnPos, Quaternion.identity);
            }
        }
    }
}
