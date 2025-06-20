using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float yOffset = 0.5f;
    public float smoothSpeed = 5f;
    public float minY = 0f;

    void LateUpdate()
    {
        if (target == null) return;

        float targetY = Mathf.Max(target.position.y + yOffset, minY);
        Vector3 targetPos = new Vector3(transform.position.x, targetY, transform.position.z);

        float step = smoothSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
    }
}
