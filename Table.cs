using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Table : MonoBehaviour
{
    [SerializeField] private int _index = 1; 
    [SerializeField] private OrderSheet _orderSheet;
    [SerializeField] private float _timeOrder = 1f; 

    private SpriteRenderer _render;

    public int Index => _index;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
        _orderSheet.SetIndex(_index);
        _orderSheet.gameObject.SetActive(false); 
    }

    public void SitDownCustomer(CustomerState customer)
    {
        switch(customer.ColorCustomer)
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

        Invoke("ReadyToOrder", _timeOrder); 
    }

    private void ReadyToOrder()
    {
        _orderSheet.gameObject.SetActive(true);
    }
}
