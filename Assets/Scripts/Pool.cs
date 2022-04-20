using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Customer[] _customers;
    [SerializeField] private int _amountToPool; 
    
    private List<Customer> _customersList = new List<Customer>();

    private void Start()
    {
        CreateCustomers();
    }

    private void CreateCustomers()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            int rand = Random.Range(0, _customers.Length);
            Customer customer = Instantiate(_customers[rand], transform);
            customer.gameObject.SetActive(false);
            _customersList.Add(customer);
        }
    }

    public Customer GetPooledCustomers()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if(!_customersList[i].gameObject.activeInHierarchy)
            {
                return _customersList[i]; 
            }
        }

        return null; 
    }
}
