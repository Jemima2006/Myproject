using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    public GameObject[] rewardPrefabs;
    public Transform monkeyTransform;
    public float spawnYMin = 6f;
    public float spawnYMax = 10f;
    public float spawnInterval = 1f;       // 1 seconde interval between objects to be spawned
    public float xOffsetRange = 2f;

    void Start()
    {
        InvokeRepeating("SpawnReward", 1f, spawnInterval);
    }

    void SpawnReward()
    {
        if (monkeyTransform == null) return;

        int index = Random.Range(0, rewardPrefabs.Length);
        float spawnY = Random.Range(spawnYMin, spawnYMax);
        float spawnX = monkeyTransform.position.x + Random.Range(-xOffsetRange, xOffsetRange);
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);

        GameObject reward = Instantiate(rewardPrefabs[index], spawnPos, Quaternion.identity);
        reward.tag = "Piece"; // make objects appear at the defined index
    }
}
