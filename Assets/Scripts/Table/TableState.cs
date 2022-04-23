using UnityEngine;

public class TableState : MonoBehaviour
{
    [SerializeField] private int _index = 1; 
    [SerializeField] private OrderSheet _orderSheet;
    [SerializeField] private float _timeOrder = 1f; 

    private bool _isFreeTable = true;
    private bool _isOrderReady = false;
    private SpriteRenderer _render;
    private TableColor _tableColor;

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
        _tableColor.SetColor(customerState.ColorCustomer);
        Invoke("ActiveOrderSheet", _timeOrder);
    }

    private void ActiveOrderSheet()
    {
        _isOrderReady = true; 
        _orderSheet.gameObject.SetActive(true);
    }

    public void WaitOrderSheet()
    {
        _isOrderReady = false;
        _orderSheet.SetColor(Color.red); 
    }
}
