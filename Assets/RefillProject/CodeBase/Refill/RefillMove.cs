using Assets.RefillProject.CodeBase.Services.Input.Jostick;
using UnityEngine.SceneManagement;
using UnityEngine;
using Assets.RefillProject.CodeBase.Services;
using Assets.RefillProject.CodeBase.Services.PersistentProgress;
using Assets.RefillProject.CodeBase.Data;

namespace Assets.RefillProject.CodeBase.Refill
{
    public class RefillMove : MonoBehaviour, ISavedProgress
    {
        private const float Epsilon = 0.001f;

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private RefillAnimation _refillAnimation;

        [SerializeField] private float _movementSpeed;

        private IInputService _inputService;

        private void Awake() => 
            _inputService = AllService.Container.Single<IInputService>();

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Epsilon)
            {
                movementVector = Camera.main.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;

                _refillAnimation.Move(_movementSpeed);
            }

            movementVector += Physics.gravity;

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);

            _refillAnimation.StopMove();
        }

        public void UpdateProgress(PlayerProgress progress) => 
            progress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());

        public void LoadProgress(PlayerProgress progress)
        {
            if (CurrentLevel() == progress.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savedProgress = progress.WorldData.PositionOnLevel.Position;

                if (savedProgress != null)
                    Warp(to: savedProgress);
            }
        }

        private void Warp(Vector3Data to)   //Деформировать
        {
            _characterController.enabled = false;
            transform.position = to.AsUnityVector().AddY(_characterController.height);
            _characterController.enabled = true;
        }

        private static string CurrentLevel() =>
            SceneManager.GetActiveScene().name;
    }
}
