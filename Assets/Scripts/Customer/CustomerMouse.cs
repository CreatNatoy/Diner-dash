using UnityEngine;

[RequireComponent(typeof(CustomerState))]
public class CustomerMouse : MonoBehaviour
{
    private Vector2 _startPosition;
    private Camera _camera;
    private CustomerState _customerState;

    public CustomerState CustomerState => _customerState;

    private void OnEnable()
    {
        _startPosition = transform.position;
    }

    private void Start()
    {
        _camera = Camera.main;
        _customerState = GetComponent<CustomerState>();
    }

    private void OnMouseDrag()
    {
        if( ! _customerState.IsSitDown)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = _camera.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    private void OnMouseUp()
    {
        if( ! _customerState.IsTable)
            transform.position = _startPosition;
        else
        {
            _customerState.SitDownTable();
        }
    }
}
