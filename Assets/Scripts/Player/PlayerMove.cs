using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed = 7f;

    private Transform _target;
    private bool _isMoving = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isMoving = CheckTarget();
        }

        if (_isMoving)
            MoveToTarget();
    }

    private bool CheckTarget()
    {
        RaycastHit2D hit = new RaycastHit2D();
        hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out MoveToPoint moveToPoint))
        {
            _target = moveToPoint.Point;
            return true;
        }
        return false;
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
            _isMoving = false;
    }
}
