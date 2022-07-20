using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _spawn;

    private void Start()
    {
        _player.transform.position = _spawn.position;
    }
}
