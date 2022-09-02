using System;
using System.Collections;
using Gameplay.RotationLogic;
using PlayerAreaMovement = Gameplay.PlayerArea.Movement;
using UnityEngine;

namespace Gameplay.PlayerWithCubes
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] 
        private float _speed;
        [SerializeField] 
        private OnTouchListener _onTouchListener;
        private bool _isTouchEnded = true;
        
        private Rigidbody _rigidbody;
        private PlayerAreaMovement _parentMovement;
        
        private WaitForFixedUpdate _waitForFixedUpdate = new();

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _parentMovement = GetComponentInParent<PlayerAreaMovement>();
        
            _onTouchListener.BeganDrag += StartControlMovement;
            _onTouchListener.EndedDrag += EndControlMovement;
        }

        private void StartControlMovement(Touch touch)
        {
            _isTouchEnded = false;
            StartCoroutine(ControlMovement(touch));
        }

        private void EndControlMovement()
        {
            _isTouchEnded = true; 
        }
        
        private IEnumerator ControlMovement(Touch touch)
        {
            Touch currentTouch = touch;
            Touch previousTouch = touch;
            
            while (!_isTouchEnded)
            {
                touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        _rigidbody.velocity = CalculateVelocity(currentTouch, previousTouch);
                        previousTouch = currentTouch;
                        break;

                    case TouchPhase.Stationary:
                        _rigidbody.velocity = Vector3.zero;
                        break;
                }
                
                currentTouch = Input.GetTouch(0);
                yield return _waitForFixedUpdate;
            }
            _rigidbody.velocity = Vector3.zero;
        }

        private Vector3 CalculateVelocity(Touch currentTouch, Touch previousTouch)
        {
            Vector3 direction = Vector3.zero;
            
            if (TouchDirectsRight(currentTouch, previousTouch))
            {
                switch (_parentMovement.Direction)
                {
                    case Direction.Forward:
                        direction = Vector3.right;
                        break;
                    case Direction.Backward:
                        direction = Vector3.left;
                        break;
                    case Direction.Left:
                        direction = Vector3.forward;
                        break;
                    case Direction.Right:
                        direction = Vector3.back;
                        break;
                }
            }
            else if (TouchDirectsLeft(currentTouch, previousTouch))
            {
                switch (_parentMovement.Direction)
                {
                    case Direction.Forward:
                        direction = Vector3.left;
                        break;
                    case Direction.Backward:
                        direction = Vector3.right;
                        break;
                    case Direction.Left:
                        direction = Vector3.back;
                        break;
                    case Direction.Right:
                        direction = Vector3.forward;
                        break;
                }
            }

            return direction * (_speed * Time.deltaTime);
        }

        private bool TouchDirectsRight(Touch currentTouch, Touch previousTouch)
        {
            return currentTouch.position.x - previousTouch.position.x > 0;
        }
        
        private bool TouchDirectsLeft(Touch currentTouch, Touch previousTouch)
        {
            return currentTouch.position.x - previousTouch.position.x < 0;
        }
    }
}
