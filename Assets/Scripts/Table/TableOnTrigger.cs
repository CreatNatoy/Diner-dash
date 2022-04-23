using UnityEngine;

[RequireComponent(typeof(TableState))]
public class TableOnTrigger : MonoBehaviour
{
    private TableState _tableState;

    private void Start()
    {
        _tableState = GetComponent<TableState>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out CustomerState customerState))
        {
            if(_tableState.IsFreeTable)
            {
                customerState.SetIsTable(true); 
                customerState.SetStateTable(_tableState); 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out CustomerState customerState))
        {
           customerState.SetIsTable(false);
        }
    }
}
