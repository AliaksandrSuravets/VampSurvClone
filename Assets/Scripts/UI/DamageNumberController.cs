using System;
using System.Collections.Generic;
using UnityEngine;

namespace VampSurv
{
    public class DamageNumberController : MonoBehaviour
    {
        #region Variables

        public static DamageNumberController Instance;

        [SerializeField] private DamageNumber _numberToSpawn;
        [SerializeField] private Transform _numberCanvas;

        private List<DamageNumber> _numberPool = new List<DamageNumber>();
        
        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            Instance = this;
        }

        // Start is called before the first frame update
        private void Start() { }

        // Update is called once per frame
        private void Update() { }

        #endregion

        #region Public methods

        public void SpawnDamage(float damageAmount, Vector3 location)
        {
            int rounded = Mathf.RoundToInt(damageAmount);

            DamageNumber newDamage = GetFromPool();
                
            newDamage.Setup(rounded);
            newDamage.gameObject.SetActive(true);
            newDamage.transform.position = location;
        }

        private DamageNumber GetFromPool()
        {
            DamageNumber numberToOutput = null;

            if (_numberPool.Count == 0)
            {
                numberToOutput = Instantiate(_numberToSpawn, _numberCanvas);
            }
            else
            {
                numberToOutput = _numberPool[0];
                _numberPool.RemoveAt(0);
            }
            
            return numberToOutput;
        }

        public void PlaceInPool(DamageNumber numberToPlace)
        {
            numberToPlace.gameObject.SetActive(false);
            _numberPool.Add(numberToPlace);
        }

        #endregion
    }
}