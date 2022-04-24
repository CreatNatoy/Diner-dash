using UnityEngine;

public class TableColor
{
    private SpriteRenderer _spriteRenderer;
    private int _counterColor;
    private Color _oldColor;

    public int CounterColor => _counterColor;

    public TableColor(SpriteRenderer _spriteRendere)
    {
        _spriteRenderer = _spriteRendere;
        _oldColor = _spriteRenderer.color;
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

        CounterColorTable();
    }

    private void CounterColorTable()
    {
        if (_spriteRenderer.color == _oldColor)
            _counterColor++;
        else
        {
            _counterColor = 1;
            _oldColor = _spriteRenderer.color; 
        }
    }
}
