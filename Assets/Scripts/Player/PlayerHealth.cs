using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VampSurv
{
    public class PlayerHealth : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _currentHealth;
        [SerializeField] private float _maxHealth;

        #endregion

        #region Events

        public event Action OnChangeHealth;

        #endregion

        #region Unity lifecycle

        // Start is called before the first frame update
        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        // Update is called once per frame
        private void Update() { }

        #endregion

        #region Public methods

        public float GetCurrentHealth()
        {
            return _currentHealth;
        }

        public float GetMaxHealth()
        {
            return _maxHealth;
        }

        public void TakeDamage(float damageToTake)
        {
            _currentHealth -= damageToTake;

            OnChangeHealth?.Invoke();
            if (_currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        #endregion
    }
}