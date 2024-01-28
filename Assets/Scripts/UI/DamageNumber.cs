using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace VampSurv
{
    public class DamageNumber : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _damageText;

        [SerializeField] private float _lifeTime;
        private float lifeCounter;

        #endregion

        #region Unity lifecycle
 
        // Update is called once per frame
        private void Update()
        {
            if (lifeCounter > 0)
            {
                lifeCounter -= Time.deltaTime;

                if (lifeCounter <= 0)
                {
                     DamageNumberController.Instance.PlaceInPool(this);
                }
            }
            
            transform.position += Vector3.up * (1f * Time.deltaTime);
        }

        #endregion

        #region Public methods

        public void Setup(int damageDisplay)
        {
            lifeCounter = _lifeTime;

            _damageText.text = $"{damageDisplay}";
        }

        #endregion
    }
}