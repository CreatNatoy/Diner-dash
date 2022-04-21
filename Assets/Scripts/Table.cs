using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Table : MonoBehaviour
{
    private SpriteRenderer _render;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
    }

    public void SetColor(Customer customer)
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
    }
}
