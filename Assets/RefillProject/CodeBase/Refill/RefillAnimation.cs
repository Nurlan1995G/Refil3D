using Assets.RefillProject.CodeBase.Logic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.RefillProject.CodeBase.Refill
{
    [RequireComponent(typeof(Animator))]
    public class RefillAnimation : MonoBehaviour, IAnimationStateReader
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController CharacterController;

        private static readonly int MoveHash = Animator.StringToHash("Walking");

        private static readonly int MoveHashState = Animator.StringToHash("Moving");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private readonly int _idleStateHash = Animator.StringToHash("IdleHero");
        //private readonly int _walkingStateHash = Animator.StringToHash("WalkingRefill");
        //private readonly int _runingStateHash = Animator.StringToHash("RuningRefill");


        public AnimatorState State { get; private set; }

        public event UnityAction<AnimatorState> StateEntered;
        public event UnityAction<AnimatorState> StateExited;

        public void ResetToIdle() => _animator.Play(_idleStateHash, -1);

        private void Start() =>
            _animator = GetComponent<Animator>();

        private void Update() => 
            _animator.SetFloat(MoveHash, CharacterController.velocity.magnitude, 0.1f, Time.deltaTime);

        public void EnteredState(int stateHash)
        {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int stateHash) =>
            StateExited?.Invoke(StateFor(stateHash));

        public void Move(float speed)
        {
            _animator.SetBool(IsMoving, true);
            _animator.SetFloat(MoveHash, speed);
        }

        public void StopMove() => 
            _animator.SetBool(IsMoving, false);

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;

            if (stateHash == _idleStateHash)
                state = AnimatorState.Idle;
            else if (stateHash == MoveHashState)
                state = AnimatorState.Walking;
            else
                state = AnimatorState.Unknow;

            return state;
        }
    }
}
