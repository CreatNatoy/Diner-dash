using UnityEngine;
using UnityEngine.UI;

public class PrintText : MonoBehaviour
{
    [SerializeField] private Text _textMoney;
    [SerializeField] private TableState _tableState;
    [SerializeField] private int _moneyForTable = 5; 
    private int _counterMoney; 

    public void OnMoneyUpdate(int bonus)
    {
        _counterMoney += _moneyForTable * bonus;
        _textMoney.text ="Money: " + _counterMoney.ToString();
    }
}
