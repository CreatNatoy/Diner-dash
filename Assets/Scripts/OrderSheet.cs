using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OrderSheet : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    private SpriteRenderer _spriteRender;
    private int _index;

    public int Index => _index;

    private void Awake()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    public void SetIndex(int index)
    {
        _spriteRender.sprite = _sprites[index-1];
        _index = index;
    }

    public void SetColor(Color color)
    {
        _spriteRender.color = color;
    }

    public Color GetColor()
    {
        return _spriteRender.color;
    }
}
