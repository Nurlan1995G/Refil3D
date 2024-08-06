using Assets.RefillProject.CodeBase.Data;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.Person
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveToPetrol : MonoBehaviour
    {
        [SerializeField] private float _minDistance = 2f;
        [SerializeField] private NavMeshAgent _agent;

        private Transform _petrol;

        public void Cunstruct(Transform petrol) =>
            _petrol = petrol;

        public void Update()
        {
            if (_petrol && IsPetrolNotReached())
                _agent.destination = _petrol.position;
        }

        private bool IsPetrolNotReached() => 
            _agent.transform.position.SqrMagnitudeTo(_petrol.position) >= _minDistance;
    }
}
