using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Src.Player.Input
{
    public class MovementInput : MonoBehaviour
    {
        [SerializeField] private Movement.Movement _movement;
        
        private PlayerInput _input;
        private Vector3 _direction;

        private void Awake()
        {
            _input = PlayerInput.GetInstance();
            
            _input.Controls.Player.Movement.started += OnMove;
            _input.Controls.Player.Movement.performed += OnMove;
            _input.Controls.Player.Movement.canceled += OnMove;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            _direction = -context.ReadValue<Vector3>();
        }

        private void FixedUpdate()
        {
            _movement.Move(_direction);
            _movement.Rotate(_direction);
        }
    }
}