using UnityEngine;

[RequireComponent(typeof(TableState))]
public class TableOnTrigger : MonoBehaviour
{
    private TableState _tableState;

    private void Start()
    {
        _tableState = GetComponent<TableState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out CustomerMouse customerMouse))
        {
            if(_tableState.IsFreeTable)
            {
                customerMouse.SetIsTable(true);
                customerMouse.SetStateTable(_tableState); 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out CustomerMouse customerMouse))
        {
            customerMouse.SetIsTable(false);
        }
    }
}
