using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OrderSheet : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    private SpriteRenderer _spriteRender;

    private void Awake()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    public void SetIndex(int index)
    {
        _spriteRender.sprite = _sprites[index-1];
    }
}
