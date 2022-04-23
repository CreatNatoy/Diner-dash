using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    [SerializeField] private Hand[] _hands; 

    public Hand FreeHand()
    {
        for (int i = 0; i < _hands.Length; i++)
        {
            if(_hands[i].IsFreeHand)
                return _hands[i];
        }

        return null;
    }
}
