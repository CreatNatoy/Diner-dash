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

        if(collision.gameObject.TryGetComponent(out PlayerHands playerHands))
        {
            Hand playerHand = playerHands.FreeHand();
            if (_tableState.IsOrderReady && playerHand != null)
            {
                playerHand.OnActiveOrderSheet(true, _tableState.Index);
                _tableState.WaitOrderSheet(); 
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
