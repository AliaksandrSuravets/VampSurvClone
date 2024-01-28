using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampSurv
{
    public class SpinWeapon : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Transform _holder;
        [SerializeField] private Transform _fireballToSpawn;

        [SerializeField] private float _timeBetweenSpawn;
        private float _spawnCounter;

        private void Start()
        {
            _spawnCounter = _timeBetweenSpawn;
        }

        private void Update()
        {
            _holder.rotation = Quaternion.Euler(0f, 0f, _holder.rotation.eulerAngles.z + (_rotateSpeed * Time.deltaTime));

            Spawn();
        }

        private void Spawn()
        {
            _spawnCounter -= Time.deltaTime;
            if (_spawnCounter <= 0)
            {
                _spawnCounter = _timeBetweenSpawn;

                Instantiate(_fireballToSpawn, _fireballToSpawn.position, Quaternion.identity, _holder).gameObject.SetActive(true);
            }
        }
    }
}
