using UnityEngine;

[RequireComponent(typeof(Customer))]
public class CustomerMouse : MonoBehaviour
{
    private Vector2 _startPosition;
    private bool _isTable = false;
    private bool _isSitDown = false; 
    private Camera _camera;
    private Vector2 _positionTable;
    private Table _table; 
    private Customer _customer;


    private void OnEnable()
    {
        _startPosition = transform.position;
        _isTable = false;
        _isSitDown = false; 
    }

    private void Start()
    {
        _camera = Camera.main;
        _customer = GetComponent<Customer>();
    }

    private void OnMouseDrag()
    {
        if ( !_isSitDown)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = _camera.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    private void OnMouseUp()
    {
        if (!_isTable)
            transform.position = _startPosition;
        else
        {
            _isSitDown = true;
            transform.position = _positionTable;
            _table.SetColor(_customer);
        }
    }

    public void IsTable(bool state)
    {
        _isTable = state; 
    }

    public void SetPositionTable(Vector3 position, Table table)
    {
        _positionTable = position;
        _table = table;
    }
}
