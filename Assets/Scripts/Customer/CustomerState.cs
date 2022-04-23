using UnityEngine;

public enum ColorCustomer { blue, green, red };

public class CustomerState : MonoBehaviour
{
    [SerializeField] private ColorCustomer _colorCustomer;

    private bool _isTable = false;
    private bool _isSitDown = false;
    private Vector2 _positionTable;
    private TableState _table;

    public ColorCustomer ColorCustomer => _colorCustomer;
    public bool IsTable => _isTable;
    public bool IsSitDown => _isSitDown;

    public void SetIsTable(bool state) => _isTable = state;
    public void SetIsSitDown(bool state) => _isSitDown = state;

    private void OnEnable()
    {
        _isTable = false;
        _isSitDown = false;
    }

    public void SitDownTable()
    {
        SetIsSitDown(true);
        transform.position = _positionTable;
        _table.SitDownCustomer(this);
    }

    public void SetStateTable(TableState table)
    {
        _table = table;
        _positionTable = _table.gameObject.transform.position;
    }
}
