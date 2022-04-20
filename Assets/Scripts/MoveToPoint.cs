using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    [SerializeField] private Transform _point;

    public Transform Point => _point; 
}
