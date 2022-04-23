using UnityEngine;

public class TableColor 
{
    private SpriteRenderer _spriteRenderer; 

    public TableColor(SpriteRenderer _spriteRendere)
    {
        _spriteRenderer = _spriteRendere;
    }

    public void SetColor(ColorCustomer colorCustomer)
    {
        switch (colorCustomer)
        {
            case ColorCustomer.green:
                _spriteRenderer.color = Color.green;
                break;
            case ColorCustomer.blue:
                _spriteRenderer.color = Color.blue;
                break;
            case ColorCustomer.red:
                _spriteRenderer.color = Color.red;
                break;
        }
    }
}
