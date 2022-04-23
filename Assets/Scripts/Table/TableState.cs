using UnityEngine;

public class TableState : MonoBehaviour
{
    [SerializeField] private int _index = 1; 
    [SerializeField] private OrderSheet _orderSheet;
    [SerializeField] private float _timeOrder = 1f;
    [SerializeField] private float _timeEat = 1f; 

    private bool _isFreeTable = true;
    private bool _isOrderReady = false;
    private SpriteRenderer _render;
    private TableColor _tableColor;
    private CustomerState _customerState;

    public CustomerState CustomerState => _customerState;
    public OrderSheet OrderSheet => _orderSheet; 
    public bool IsFreeTable => _isFreeTable;
    public bool IsOrderReady => _isOrderReady;
    public int Index => _index;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
        _tableColor = new TableColor(_render); 
        _orderSheet.gameObject.SetActive(false); 
        _orderSheet.SetIndex(_index);
    }

    public void SetStateTable(bool state) => _isFreeTable = state;

    public void SitDownCustomer(CustomerState customerState)
    {
        SetStateTable(false);
        _customerState = customerState;
        _tableColor.SetColor(_customerState.ColorCustomer);
        Invoke("ActiveOrderSheet", _timeOrder);
    }

    private void ActiveOrderSheet()
    {
        _orderSheet.SetColor(Color.white);
        _orderSheet.gameObject.SetActive(true);
    }

    public void WaitOrderSheet()
    {
        _orderSheet.SetColor(Color.red); 
    }

    public void ApplyEat()
    {
        _orderSheet.SetColor(Color.blue);
        Invoke("EndEating", _timeEat); 
    }

    public void EndEating()
    {
        _orderSheet.SetColor(Color.black); 
    }
}
