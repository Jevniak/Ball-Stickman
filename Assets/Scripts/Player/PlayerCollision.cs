using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UI;
using UnityEngine;

public class PlayerCollision : PlayerBase
{
    [SerializeField] private PlayerMove _playerMove;

    private void Awake()
    {
        if (_playerMove == null)
            _playerMove = FindObjectOfType<PlayerMove>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Wall":
                UIManager.Instance.LoseGame();
                break;
            case "Finish":
                UIManager.Instance.WinGame();
                break;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        switch (coll.tag)
        {
            case "SpeedDown":
                _playerMove.SpeedDown();
                coll.gameObject.SetActive(false);
                break;
            case "SpeedUp":
                _playerMove.SpeedUp();
                coll.gameObject.SetActive(false);
                break;
        }
    }
}
