using System.Collections;
using UnityEngine;

public class PlayerTouchMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _parentTrans;

    [SerializeField] private float _speedOfTouch;
    [SerializeField] private OnTouchListener _onTouchListener;
    private bool _isSwipeEnded = true;

    private WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _parentTrans = GetComponentInParent<Transform>();

        _onTouchListener.OnBeginSwipe += OnBeginSwipeHandle;
        _onTouchListener.OnEndSwipe += OnEndSwipeHandle;
    }

    private void OnBeginSwipeHandle(Touch touch)
    {
        _isSwipeEnded = false;
        StartCoroutine(ControlVelocitySwipe(touch));
    }

    private void OnEndSwipeHandle()
    {
        _isSwipeEnded = true; 
    }

    IEnumerator ControlVelocitySwipe(Touch touch)
    {
        Touch touchPast = touch;
        while (!_isSwipeEnded)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    if (touch.position.x - touchPast.position.x > 0)
                    {
                        if (_parentTrans.rotation.y % 180 == 0)
                            _rigidbody.velocity = Vector3.right * _speedOfTouch;
                        else
                            _rigidbody.velocity = -Vector3.forward * _speedOfTouch;
                    }
                    else if (touch.position.x - touchPast.position.x < 0)
                    {
                        if (_parentTrans.rotation.y % 180 == 0)
                            _rigidbody.velocity = Vector3.left * _speedOfTouch;
                        else
                            _rigidbody.velocity = Vector3.forward * _speedOfTouch;
                    }
                    touchPast = touch;
                    break;

                case TouchPhase.Stationary:
                    _rigidbody.velocity = Vector3.zero;
                    break;
            }
            touch = Input.GetTouch(0);
            yield return _waitForFixedUpdate;
        }
        _rigidbody.velocity = Vector3.zero;
    }
}
