using UnityEngine;

namespace VampSurv.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables

        private static readonly int ISMOVING = Animator.StringToHash("isMoving");

        [SerializeField] private float _moveSpeed;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Animator _animator;

        #endregion

        #region Unity lifecycle

        // Start is called before the first frame update
        private void Start() { }

        // Update is called once per frame
        private void Update()
        {
            Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f)
                .normalized;

            transform.position += moveInput * (_moveSpeed * Time.deltaTime);
            _animator.SetBool(ISMOVING, moveInput != Vector3.zero);

            //_rb.velocity = moveInput * _moveSpeed;
        }

        #endregion
    }
}