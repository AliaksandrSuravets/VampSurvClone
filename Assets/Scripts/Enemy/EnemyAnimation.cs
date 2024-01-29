using UnityEngine;

namespace VampSurv.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _sprite;
        [SerializeField] private float _speed;
        [SerializeField] private float _minSize;
        [SerializeField] private float _maxSize;

        private float _activeSize;

        #endregion

        #region Unity lifecycle

        // Start is called before the first frame update
        private void Start()
        {
            _activeSize = _maxSize;
            _speed *= Random.Range(0.75f, 1.25f);
        }

        // Update is called once per frame
        private void Update()
        {
            _sprite.localScale =
                Vector3.MoveTowards(_sprite.localScale, Vector3.one * _activeSize, _speed * Time.deltaTime);
            if (_sprite.localScale.x.Equals(_activeSize))
            {
                _activeSize = _activeSize.Equals(_maxSize) ? _minSize : _maxSize;
            }
        }

        #endregion
    }
}