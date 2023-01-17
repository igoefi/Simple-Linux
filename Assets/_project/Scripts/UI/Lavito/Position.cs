using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Position : MonoBehaviour
{
    [SerializeField] TMP_Text _name;
    [SerializeField] TMP_Text _description;
    [SerializeField] TMP_Text _price;
    [SerializeField] Image _image;

    private LavitoPosition _position;

    public void SetPosition(LavitoPosition position)
    {
        position.GetParametrs(out string name, out string description, out Sprite sprite, out int price, out bool isBuy);
        _position = position;
        _name.text = name;
        _description.text = description;
        _image.sprite = sprite;

        _price.text = !isBuy ? price.ToString() : "Куплено за ";
    }

    public void SetBuyIsTrue()
    {
        _price.text = "Куплено за ";
        _position.SetIsBuyTrue();
    }

    public void BuyUpdate()
    {
        if (_position.IsBuy)
            _price.text = "Куплено за ";
    }
}
