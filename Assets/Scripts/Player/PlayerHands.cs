using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    [SerializeField] private Hand[] _hands;

    public int SizeHand => _hands.Length;

    public Hand FreeHand()
    {
        for (int i = 0; i < _hands.Length; i++)
        {
            if (_hands[i].IsFreeHand)
                return _hands[i];
        }
        return null;
    }

    public int GiveOrderCook(int index)
    {
        if (_hands[index].OrderSheet.gameObject.activeSelf && 
            _hands[index].OrderSheet.GetColor() == Color.white)
        {
            _hands[index].OnDisableOrderSheet(); 
            return _hands[index].OrderSheet.Index;
        }
        else
        {
            return -1;
        }
    }

    public void GiveOrderTable(TableState tableState)
    {
        for (int i = 0; i < _hands.Length; i++)
        {
            if (_hands[i].OrderSheet.GetColor() == Color.green &&
                _hands[i].OrderSheet.Index == tableState.Index)
            {
                _hands[i].OnDisableOrderSheet(); 
                tableState.ApplyEat();
            }
        }
    }

    public void GiveOrderWish()
    {
        for (int i = 0; i < _hands.Length; i++)
        {
            if(_hands[i].OrderSheet.GetColor() == Color.black)
            {
                _hands[i].OnDisableOrderSheet(); 
            }
        }
    }

}