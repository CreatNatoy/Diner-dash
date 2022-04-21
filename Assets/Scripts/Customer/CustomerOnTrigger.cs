using UnityEngine;

[RequireComponent(typeof(CustomerMouse))]
public class CustomerOnTrigger : MonoBehaviour
{
    private CustomerMouse _customerMouse; 

    private void Start()
    {
        _customerMouse = GetComponent<CustomerMouse>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Table table))
        {
            _customerMouse.IsTable(true);
            _customerMouse.SetPositionTable(table.gameObject.transform.position, table); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Table table))
        {
            _customerMouse.IsTable(false);
        }
    }
}
