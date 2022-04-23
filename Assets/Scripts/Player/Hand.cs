using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private OrderSheet _orderSheet;

    private bool _isFreeHand = true; 

    public bool IsFreeHand => _isFreeHand;

    private void Start()
    {
        OnActiveOrderSheet(false); 
    }

    public void OnActiveOrderSheet(bool state, int index = 0)
    {
        _orderSheet.gameObject.SetActive(state);
        _orderSheet.SetIndex(index);
        SetStateHand(state);
    }

    private void SetStateHand(bool state)
    {
        if (state)
            _isFreeHand = false;
        else
            _isFreeHand = true;
    }
}
