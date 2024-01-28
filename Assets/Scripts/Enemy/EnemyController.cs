using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampSurv.Player;

namespace VampSurv
{
    public class EnemyController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _damage;
        [SerializeField] private float _coldawn;

        [SerializeField] private float _health = 5f;

        [SerializeField] private float _knockBackTime = .5f;
        private float _knockBackCounter;
        private Transform _target;

        private float _timeColdawn;

        #endregion

        #region Unity lifecycle

        // Start is called before the first frame update
        private void Start()
        {
            _target = FindObjectOfType<PlayerController>().transform;
        }

        // Update is called once per frame
        private void Update()
        {
            _timeColdawn -= Time.deltaTime;

            Move();
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out PlayerHealth player))
            {
                if (_timeColdawn < 0)
                {
                    player.TakeDamage(_damage);
                    _timeColdawn = _coldawn;
                }
            }
        }

        #endregion

        #region Public methods

        public void TakeDamage(float damageToTake)
        {
            _health -= damageToTake;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void TakeDamage(float damageToTake, bool shoudKnockback)
        {
            TakeDamage(damageToTake);

            if (shoudKnockback)
            {
                _knockBackCounter = _knockBackTime;
            }
        }

        #endregion

        #region Private methods

        private void Move()
        {
            if (_knockBackCounter > 0)
            {
                _knockBackCounter -= Time.deltaTime;

                if (_moveSpeed > 0)
                {
                    _moveSpeed = -_moveSpeed * 2f;
                }

                if (_knockBackCounter <= 0)
                {
                    _moveSpeed = Math.Abs(_moveSpeed * .5f);
                }
            }

            _rb.velocity = (_target.position - transform.position).normalized * _moveSpeed;

            if (_moveSpeed > 0)
            {
                _spriteRenderer.flipX = !(_rb.velocity.x <= 0);
            }
            else
            {
                _spriteRenderer.flipX = _rb.velocity.x <= 0;
            }
        }

        #endregion
    }
}