using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerMove : PlayerBase
    {
        [SerializeField] private float speed;
        private float normalSpeed;
        [SerializeField] private DynamicJoystick _dynamicJoystick;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            normalSpeed = speed;
            thisTransform = transform;
            if (_dynamicJoystick == null)
                _dynamicJoystick = FindObjectOfType<DynamicJoystick>();
        }

        private void FixedUpdate()
        {
            if (UIManager.Instance.gameStarted)
            {
                Vector3 movement = new Vector3(_dynamicJoystick.Horizontal, 0, 1f);
                Move(movement, speed);
            }
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }

        public void SpeedDown()
        {
            speed /= 1.5f;
            StartCoroutine(TimerNormalSpeed());
        }

        public void SpeedUp()
        {
            speed *= 1.5f;
            StartCoroutine(TimerNormalSpeed());
        }

        private IEnumerator TimerNormalSpeed(float time = 3f)
        {
            yield return new WaitForSeconds(time);
            speed = normalSpeed;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Floor"))
                rb.AddForce(Vector3.up * 8, ForceMode.Impulse);
        }
    }
}