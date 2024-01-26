using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampSurv
{
    public class SpawnService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private List<GameObject> _enemyToSpawn;
        [SerializeField] private float _timeToSpawn;

        [SerializeField] private Transform _minPos;
        [SerializeField] private Transform _maxPos;

        [SerializeField] private Transform _target;
        [SerializeField] private int _checkPerFrame;
        private readonly List<GameObject> _enemies = new List<GameObject>();

        private float _despawnDistance;
        private int _enemyToCheck;

        private float _spawnCounter;

        #endregion

        #region Unity lifecycle

        // Start is called before the first frame update
        private void Start()
        {
            _spawnCounter = _timeToSpawn;

            _despawnDistance = Vector3.Distance(transform.position, _maxPos.position) + 4f;
        }

        // Update is called once per frame
        private void Update()
        {
            _spawnCounter -= Time.deltaTime;

            Spawn();

            transform.position = _target.position;

            Despawn();
        }

        #endregion

        #region Private methods

        private void Despawn()
        {
            int checkTarget = _enemyToCheck + _checkPerFrame;

            while (_enemyToCheck < checkTarget)
            {
                if (_enemyToCheck < _enemies.Count)
                {
                    if (_enemies[_enemyToCheck] != null)
                    {
                        if (Vector3.Distance(transform.position, _enemies[_enemyToCheck].transform.position) >
                            _despawnDistance)
                        {
                            Destroy(_enemies[_enemyToCheck]);
                            _enemies.RemoveAt(_enemyToCheck);
                            checkTarget--;
                        }
                        else
                        {
                            _enemyToCheck++;
                        }
                    }
                    else
                    {
                        _enemies.RemoveAt(_enemyToCheck);
                        checkTarget--;
                    }
                }
                else
                {
                    _enemyToCheck = 0;
                    checkTarget = 0;
                }
            }
        }

        private Vector3 SelectSpawnPoint()
        {
            Vector3 spawnPoint = Vector3.zero;
            bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;

            if (spawnVerticalEdge)
            {
                spawnPoint.y = Random.Range(_minPos.position.y, _maxPos.position.y);
                spawnPoint.x = Random.Range(0f, 1f) > .5f ? _maxPos.position.x : _minPos.position.x;
            }
            else
            {
                spawnPoint.x = Random.Range(_minPos.position.x, _maxPos.position.x);
                spawnPoint.y = Random.Range(0f, 1f) > .5f ? _maxPos.position.y : _minPos.position.y;
            }

            return spawnPoint;
        }

        private void Spawn()
        {
            if (_spawnCounter <= 0)
            {
                _spawnCounter = _timeToSpawn;

                GameObject newEnemy = Instantiate(_enemyToSpawn[Random.Range(0, _enemyToSpawn.Count)],
                    SelectSpawnPoint(),
                    Quaternion.identity);
                _enemies.Add(newEnemy);
            }
        }

        #endregion
    }
}