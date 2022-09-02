using Gameplay.RotationLogic;
using UnityEngine;

namespace Gameplay.PlayerArea
{
    public class Rotation : MonoBehaviour
    {
        private bool _isRotating = false;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Rotate");
            if (!other.CompareTag(Tags.ColliderRotate)) return;
            other.gameObject.SetActive(false);
            
            if (_isRotating) return;
            _isRotating = true;

            Direction rotationDirection = other.gameObject.GetComponent<RotationTrigger>().Direction;
            
            Rotate(rotationDirection);
        }

        private void Rotate(Direction direction)
        {
            Direction newDirection = direction;
            Direction oldDirection = gameObject.GetComponent<Movement>().Direction;

            float angle = RotationsMap.GetValue(oldDirection, newDirection);
            
            for (int i = 0; i < 30; i++)
            {
                transform.Rotate(Vector3.up, angle * Time.deltaTime);
            }
            _isRotating = false;
            gameObject.GetComponent<Movement>().Direction = newDirection;
        }
    }
}