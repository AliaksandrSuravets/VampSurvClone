using System;
using UnityEngine;
using VampSurv.Player;
using VampSurv.Service;

namespace VampSurv.Exp
{
    public class ExpPickUp : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _expValue;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _timeBetweenChecks = .2f;
        private float _checkCounter;
        private PlayerController _target;

        private bool _movingToPlayer;
        
        #endregion

        #region Unity lifecycle

        // Start is called before the first frame update
        private void Start()
        {
            _target = FindObjectOfType<PlayerController>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_movingToPlayer)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _moveSpeed * Time.deltaTime);
            }
            else
            {
                _checkCounter -= Time.deltaTime;
                if (_checkCounter <= 0)
                {
                    _checkCounter = _timeBetweenChecks;
                    if (Vector3.Distance(transform.position, _target.transform.position) < _target.GetPickUpRange())
                    {
                        _movingToPlayer = true;
                        _moveSpeed += _target.GetMoveSpeed();
                    }
                }
            }
        }

        #endregion

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ExperienceLevelController.Instance.GetExp(_expValue);
                Destroy(gameObject);
            }
        }
    }
}