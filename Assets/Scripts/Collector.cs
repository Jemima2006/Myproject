using UnityEngine;

public class Collector : MonoBehaviour
{
    public AudioClip winSound;
    public AudioClip loseSound;
    private AudioSource audioSource;
    public int score = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // win pièce
        foreach (GameObject piece in GameObject.FindGameObjectsWithTag("Piece"))
        {
            if (IsClose(piece))
            {
                Destroy(piece);
                score++;
                Debug.Log("🎉 Pièce ! Score: " + score);
                audioSource.PlayOneShot(winSound);
            }
        }

        // hit obstacle
        foreach (GameObject obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            if (IsClose(obstacle))
            {
                Debug.Log("💥 Obstacle touché !");
                audioSource.PlayOneShot(loseSound);
            }
        }
    }

    bool IsClose(GameObject obj)
    {
        return Mathf.Abs(obj.transform.position.x - transform.position.x) < 0.5f &&
               Mathf.Abs(obj.transform.position.y - transform.position.y) < 0.5f;
    }
}
