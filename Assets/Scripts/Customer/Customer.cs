using UnityEngine;

public enum ColorCustomer { blue, green, red };

public class Customer : MonoBehaviour
{
    [SerializeField] private ColorCustomer _colorCustomer;

    public ColorCustomer ColorCustomer => _colorCustomer;
}
