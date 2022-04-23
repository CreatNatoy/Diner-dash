using UnityEngine;

[RequireComponent(typeof(Cook))]
public class CookOnTrigger : MonoBehaviour
{
    private Cook _cook;

    private void Start()
    {
        _cook = GetComponent<Cook>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHands playerHands))
        {      
            ApplyOrder(playerHands);
            _cook.GivePlayerFood(playerHands);
        }
    }

    private void ApplyOrder(PlayerHands playerHands)
    {
        for (int i = 0; i < playerHands.SizeHand; i++)
        {
            int index = playerHands.GiveOrderCook(i);
            if (index >= 0)
            {
                _cook.CookFood(index);
            }
        }
    }
}
