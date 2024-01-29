using UnityEngine;
using UnityEngine.UI;
using VampSurv.Player;

namespace VampSurv.UI
{
    public class PlayerHealthBar : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerHealth _player;
        [SerializeField] private Slider _healthSlider;

        #endregion

        #region Unity lifecycle

        // Start is called before the first frame update
        private void Start()
        {
            _healthSlider.maxValue = _player.GetMaxHealth();
            _healthSlider.value = _player.GetMaxHealth();
        }

        private void OnEnable()
        {
            _player.OnChangeHealth += OnChangeHealth;
        }

        private void OnDisable()
        {
            _player.OnChangeHealth -= OnChangeHealth;
        }

        #endregion

        #region Private methods

        private void OnChangeHealth()
        {
            _healthSlider.value = _player.GetCurrentHealth();
        }

        #endregion
    }
}