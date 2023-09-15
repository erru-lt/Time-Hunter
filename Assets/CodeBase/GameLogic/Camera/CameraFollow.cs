using Assets.CodeBase.Hero;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.GameLogic.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _rotationX;
        [SerializeField] private float _distanceZ;
        [SerializeField] private float _offsetY;
        private HeroMove _target;

        [Inject]
        private void Construct(HeroMove target)
        {
            _target = target;
        }

        private void LateUpdate()
        {
            CameraPositionAndRotation();
        }

        private void CameraPositionAndRotation()
        {
            Quaternion cameraRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
            Vector3 cameraPosition = cameraRotation * new Vector3(0.0f, 0.0f, _distanceZ) + TargetPointPosition();

            transform.SetPositionAndRotation(cameraPosition, cameraRotation);
        }

        private Vector3 TargetPointPosition()
        {
            Vector3 targetPointPosition = _target.transform.position;
            targetPointPosition.y += _offsetY;
            
            return targetPointPosition;
        }
    }
}
