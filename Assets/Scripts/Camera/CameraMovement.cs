using Player;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform thisTransform;
    [SerializeField] private Transform target;

    public float offset = 100f;
    public float offsetPositionZ = 6;

    private void Awake()
    {
        thisTransform = transform;
        target = FindObjectOfType<PlayerBase>().transform;
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        if (target)
        {
            var targetPosition = target.position;
            transform.position = Vector3.Lerp(position,
                new Vector3(position.x, position.y,
                    targetPosition.z - offsetPositionZ), offset * Time.fixedDeltaTime);
        }
    }
}
