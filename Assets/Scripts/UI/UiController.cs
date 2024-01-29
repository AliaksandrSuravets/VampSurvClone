using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampSurv
{
    public class UiController : MonoBehaviour
    {
        #region Variables

        public static UiController Instance;

        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _levelText;

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

        public void UpdateExp(int currentExp, int levelExp, int currentLvl)
        {
            _slider.maxValue = levelExp;
            _slider.value = currentExp;

            _levelText.text = $"Level: {currentLvl}";
        }

        #endregion
    }
}