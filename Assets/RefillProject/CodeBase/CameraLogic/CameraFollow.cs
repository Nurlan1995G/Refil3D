using UnityEngine;

namespace Assets.RefillProject.CodeBase.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _rotateAngleX;
        [SerializeField] private float _distance;
        [SerializeField] private float _offsetY;

        private Transform _following;

        private void LateUpdate()
        {
            if (_following == null)
                return;

            Quaternion rotation = Quaternion.Euler(_rotateAngleX, 0, 0);

            Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(GameObject followind) =>
            _following = followind.transform;

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition.y += _offsetY;

            return followingPosition;
        }

        private void Load()
        {
            Debug.Log("");
        }
    }
}
