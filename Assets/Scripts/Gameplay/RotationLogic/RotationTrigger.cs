using UnityEngine;

namespace Gameplay.RotationLogic
{
    public class RotationTrigger : MonoBehaviour
    {
        [SerializeField]
        private Direction _direction;

        public Direction Direction => _direction;
    }
}