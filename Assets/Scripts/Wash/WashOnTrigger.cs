using UnityEngine;

public class WashOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerHands playerHands))
        {
            playerHands.GiveOrderWish(); 
        }
    }
}
