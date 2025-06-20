using UnityEngine;

public class MonkeyClimb: MonoBehaviour
{
    public GameObject rightMonkeyObject; // Reference to the player GameObject
    public GameObject leftMonkeyObject;  // Reference to the player GameObject

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rightMonkeyObject.SetActive(true);
            leftMonkeyObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightMonkeyObject.SetActive(false);
            leftMonkeyObject.SetActive(true);
        }
    }
}