using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampSurv
{
    public class EnemyDamager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _damageAmount;
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _growSpeed = 5f;
        private Vector3 targetSize;

        [SerializeField] private bool _shoudKnockBack;
        [SerializeField] private bool _destroyParent;
        

        #endregion

        #region Unity lifecycle

        // Start is called before the first frame update
        private void Start()
        {
            targetSize = transform.localScale;
            transform.localScale = Vector3.zero;
        }

        // Update is called once per frame
        private void Update()
        {
            _lifeTime -= Time.deltaTime;
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, _growSpeed * Time.deltaTime);
            if (_lifeTime <= 0)
            {
                targetSize = Vector3.zero;
                
                if (transform.localScale.x == 0f)
                {
                    Destroy(gameObject);

                    if (_destroyParent)
                    {
                        Destroy(transform.parent.gameObject);
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out EnemyController enemy))
            {
                enemy.TakeDamage(_damageAmount, _shoudKnockBack);
            }
        }

        #endregion
    }
}