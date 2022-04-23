using UnityEngine;

[RequireComponent(typeof(CustomerState))]
public class CustomerMouse : MonoBehaviour
{
    private Vector2 _startPosition;
    private bool _isTable = false;
    private bool _isSitDown = false; 
    private Camera _camera;
    private Vector2 _positionTable;
    private TableState _table; 
    private CustomerState _customerState;

    public bool IsSitDown => _isSitDown;

    private void OnEnable()
    {
        _startPosition = transform.position;
        _isTable = false;
        _isSitDown = false; 
    }

    private void Start()
    {
        _camera = Camera.main;
        _customerState = GetComponent<CustomerState>();
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
            SitDownTable();
        }
    }

    private void SitDownTable()
    {
        _isSitDown = true;
        transform.position = _positionTable;
        _table.SitDownCustomer(_customerState);
    }

    public void SetIsTable(bool state)
    {
        _isTable = state; 
    }

    public void SetStateTable(TableState table)
    {
        _table = table;
        _positionTable = _table.gameObject.transform.position;
    }
}
