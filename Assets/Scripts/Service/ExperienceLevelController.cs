using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampSurv.Exp;

namespace VampSurv.Service
{
    public class ExperienceLevelController : MonoBehaviour
    {
        #region Variables

        public static ExperienceLevelController Instance;
        [SerializeField] private ExpPickUp _expPickUp;
        [SerializeField] private List<int> _expLevels;
        [SerializeField] private int _currentLevel = 1;
        [SerializeField] private int _levelCount = 15;
        
        #endregion

        #region Properties

        public int CurrentExperience { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            Instance = this;
        }

        // Start is called before the first frame update
        private void Start()
        {
            while (_expLevels.Count < _levelCount)
            {
                _expLevels.Add(2000);
            }
        }

        // Update is called once per frame
        private void Update() { }

        #endregion

        #region Public methods

        public void GetExp(int amountToGet)
        {
            CurrentExperience += amountToGet;
            if (CurrentExperience >= _expLevels[_currentLevel])
            {
                LevelUp();
            }
            
            UiController.Instance.UpdateExp(CurrentExperience, _expLevels[_currentLevel], _currentLevel);
        }

        public void SpawmExp(Vector3 position)
        {
            Instantiate(_expPickUp, position, quaternion.identity);
        }

        public void LevelUp()
        {
            CurrentExperience -= _expLevels[_currentLevel];
            _currentLevel++;

            if (_currentLevel >= _expLevels.Count)
            {
                _currentLevel = _expLevels.Count - 1;
            }
        }
        
        #endregion
    }
}