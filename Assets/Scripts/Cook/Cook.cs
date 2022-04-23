using System.Collections;
using UnityEngine;

public class Cook : MonoBehaviour
{
    [SerializeField] private OrderSheet[] _orderSheets;
    [SerializeField] private float _timeCookFood = 2f;

    public void CookFood(int index)
    {
        for (int i = 0; i < _orderSheets.Length; i++)
        {
            if (!_orderSheets[i].gameObject.activeSelf)
            {
                _orderSheets[i].gameObject.SetActive(true);
                _orderSheets[i].SetIndex(index);
                _orderSheets[i].SetColor(Color.yellow);
                StartCoroutine(WaitCookFood(i));
                return;
            }
        }
    }

    IEnumerator WaitCookFood(int index)
    {
        yield return new WaitForSeconds(_timeCookFood);
        _orderSheets[index].SetColor(Color.green);
    }

    public void GivePlayerFood(PlayerHands playerHands)
    {
        for (int i = 0; i < _orderSheets.Length; i++)
        {
            if (_orderSheets[i].gameObject.activeSelf)
                if (_orderSheets[i].GetColor() == Color.green)
                {
                    Hand hand = playerHands.FreeHand();
                    if (hand == null)
                        return;
                    hand.OnActiveOrderSheet(_orderSheets[i].Index);
                    hand.OrderSheet.SetColor(Color.green);
                    _orderSheets[i].gameObject.SetActive(false);

                }
        }
    }
}
