using UnityEngine;

[RequireComponent(typeof(TableState))]
public class TableOnTrigger : MonoBehaviour
{
    private TableState _tableState;
    private bool _isCleanTable = false; 

    private void Start()
    {
        _tableState = GetComponent<TableState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHands playerHands))
        {
            playerHands.GiveOrderTable(_tableState);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CustomerState customerState))
        {
            if (_tableState.IsFreeTable)
            {
                customerState.SetIsTable(true);
                customerState.SetStateTable(_tableState);
            }
        }

        if (collision.gameObject.TryGetComponent(out PlayerHands playerHands))
        {
            Hand playerHand = playerHands.FreeHand();
            if (playerHand != null)
            {
                if (_tableState.IsOrderReady)
                {
                    playerHand.OnActiveOrderSheet(_tableState.Index);
                    _tableState.WaitOrderSheet();
                    _isCleanTable = false; 
                }
                else if(_tableState.OrderSheet.GetColor() == Color.black && ! _isCleanTable)
                {
                    _tableState.CustomerState.gameObject.SetActive(false);
                    _tableState.OrderSheet.gameObject.SetActive(false); 
                    playerHand.OnActiveOrderSheet(_tableState.Index);
                    playerHand.OrderSheet.SetColor(Color.black);
                    _isCleanTable = true; 
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CustomerState customerState))
        {
            customerState.SetIsTable(false);
        }
    }
}
