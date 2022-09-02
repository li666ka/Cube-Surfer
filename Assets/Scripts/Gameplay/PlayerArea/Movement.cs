using Gameplay.RotationLogic;
using UnityEngine;

namespace Gameplay.PlayerArea
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] 
        private Transform _startPosition;
        [SerializeField] 
        private float _speedOfMovement;
        
        public Direction Direction { get; set; } = Direction.Forward;
        
        private void Start()
        {
            GetComponent<Transform>().position = _startPosition.position;
        }
        
        private void Update()
        {
            transform.Translate(Vector3.forward * (_speedOfMovement * Time.deltaTime));
        }
    }
}