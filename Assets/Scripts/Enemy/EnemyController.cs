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

        private float _timeColdawn;
        private Transform _target;

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
            _rb.velocity = (_target.position - transform.position).normalized * _moveSpeed;
            if (_rb.velocity.x <= 0)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }
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
    }
}