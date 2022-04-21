using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private NavMeshAgent _agent; 
    private Transform _target;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false; 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           CheckTarget();
        }


    }

    private void CheckTarget()
    {
        RaycastHit2D hit = new RaycastHit2D();
        hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out MoveToPoint moveToPoint))
        {
            _target = moveToPoint.Point;
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        _agent.SetDestination(_target.position);
    }
}
