using UnityEngine;

public class TableState : MonoBehaviour
{
    [SerializeField] private int _index = 1; 
    [SerializeField] private OrderSheet _orderSheet;

    private bool _isFreeTable = true;
    private SpriteRenderer _render;

    public bool IsFreeTable => _isFreeTable;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
        _orderSheet.gameObject.SetActive(false); 
        _orderSheet.SetIndex(_index);
    }

    public void SetStateTable(bool state) => _isFreeTable = state;

    public void SitDownCustomer(CustomerState customerState)
    {
        SetStateTable(false); 
        SetColor(customerState.ColorCustomer);
        _orderSheet.gameObject.SetActive(true);
    }

    private void SetColor(ColorCustomer colorCustomer)
    {
        switch (colorCustomer)
        {
            case ColorCustomer.green:
                _render.color = Color.green;
                break;
            case ColorCustomer.blue:
                _render.color = Color.blue;
                break;
            case ColorCustomer.red:
                _render.color = Color.red;
                break;
        }
    }

}
