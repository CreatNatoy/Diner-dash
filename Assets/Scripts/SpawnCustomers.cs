using UnityEngine;

[RequireComponent(typeof(Pool))]
public class SpawnCustomers : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float _timeSpawn = 1f;
    [Range(0.5f, 1f)]
    [SerializeField] private float _reductionTime = 0.98f;
    [Space(10)]
    [SerializeField] private int _sizeCustomers = 20;

    private int _counterCustomers = 0; 
    private Pool _pool;
    private float _time; 

    private void Start()
    {
        _pool = GetComponent<Pool>();
    }

    private void Update()
    {
        Timer(); 
    }

    private void Timer()
    {
        _time += Time.deltaTime;
        if(_time >= _timeSpawn)
        {
            SpawnCustomer();
            _time = 0f;
            _timeSpawn *= _reductionTime;
        }
    }

    private void SpawnCustomer()
    {
       Customer customer = _pool.GetPooledCustomers();
        if (customer != null)
        {
            customer.gameObject.SetActive(true);
            customer.gameObject.transform.position = GetRandomPosition();
            _counterCustomers++;
            if (_counterCustomers == _sizeCustomers)
                StopSpawn();
        }
    }

    private Vector2 GetRandomPosition()
    {
        float randX = Random.Range(-1f, 1f); 
        float randY = Random.Range(-2f, 2f);
        Vector2 position = new Vector2(transform.position.x + randX, transform.position.y + randY);
        return position;
    }

    private void StopSpawn()
    {
        this.enabled = false; 
    }

}
