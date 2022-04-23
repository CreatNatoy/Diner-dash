using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private OrderSheet _orderSheet;

    private bool _isFreeHand = true;

    public bool IsFreeHand => _isFreeHand;
    public OrderSheet OrderSheet => _orderSheet;

    private void Start()
    {
        OnDisableOrderSheet();
    }

    public void OnActiveOrderSheet(int index = 1)
    {
        _orderSheet.gameObject.SetActive(true);
        _orderSheet.SetIndex(index);
        SetStateHand(true);
    }

    public void OnDisableOrderSheet()
    {
        _orderSheet.SetColor(Color.white);
        _orderSheet.gameObject.SetActive(false);
        SetStateHand(false);
    }

    private void SetStateHand(bool state)
    {
        if (state)
            _isFreeHand = false;
        else
            _isFreeHand = true;
    }
}
