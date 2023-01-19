using UnityEngine;

[System.Serializable]
public class LavitoPosition
{
    [SerializeField] string _name;
    [SerializeField] string _description;

    [SerializeField] Sprite _image;

    [SerializeField] int _price;

    public bool IsBuy { get; private set; } = false;

    public void GetParametrs(out string name, out string description, out Sprite sprite, out int price, out bool isBuy)
    {
        name = _name;
        description = _description;
        sprite = _image;
        price = _price;
        isBuy = IsBuy;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetIsBuyTrue()
    {
        IsBuy = true;
        LavitoPositionsFile.SaveEvent.Invoke();
    }

    public Sprite GetSprite()
    {
        return _image;
    }

    public bool Compare(string name) 
    {
        return name == _name;
    }
}
