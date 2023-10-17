using Assets.CodeBase.Services.Input;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Hero
{
    //[RequireComponent(typeof(CharacterController))]
    public class HeroMove : MonoBehaviour
    {
        public float MoveSpeed
        {
            get => _moveSpeed;
            set => _moveSpeed = value;
        }
        [SerializeField] private float _moveSpeed;
        [SerializeField] private CharacterController _characterController;
        private IInputService _inputService;
        private Camera _camera;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector3 movementVector = Vector3.zero;
            
            if (_inputService.Axis.sqrMagnitude > 0.001f)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            _characterController.Move(_moveSpeed * Time.deltaTime * movementVector);
        }

        public class Factory : PlaceholderFactory<HeroMove>
        {

        }
    }
}