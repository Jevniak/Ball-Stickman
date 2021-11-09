using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerBase : MonoBehaviour
    {
        protected Transform thisTransform;
        protected Rigidbody rb;
        protected virtual void Move(Vector3 movement, float speed)
        {
            thisTransform.Translate(movement * speed *Time.deltaTime);
            var position = thisTransform.position;
            position = new Vector3(Mathf.Clamp(position.x, -1.8f, 1.8f), position.y, position.z);
            thisTransform.position = position;
        }

    }
}
