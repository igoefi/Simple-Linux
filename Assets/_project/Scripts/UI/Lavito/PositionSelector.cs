using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PositionSelector : MonoBehaviour
{
    public static UnityEvent BuyUpdate { get; private set; } = new();

    private int _maxPositions;

    [SerializeField] Position[] _positions;

    [SerializeField] TMP_Text _listNumText;

    private int numList = 1;
    public bool IsInterier { get; private set; } = true;

    private void Start()
    {
        _maxPositions = _positions.Length;
        BuyUpdate.AddListener(ResetPositions);
    }

    public void SetPositions(LavitoPosition[] lavitoPositions, int numListing)
    {
        if (_maxPositions == 0) Start();

        if (numListing == 0) numList = 1;

        if (lavitoPositions.Length + _maxPositions - 1 < _maxPositions * (numList + numListing)) return;

        PlusListNum(numListing);

        Queue<LavitoPosition> positions = new();

        for (int i = _maxPositions * (numList - 1); i < _maxPositions * numList && i < lavitoPositions.Length; i++)
        {
            positions.Enqueue(lavitoPositions[i]);
        }

        foreach (Position position in _positions)
        {
            positions.TryDequeue(out LavitoPosition lavito);

            if (lavito == null)
            {
                position.gameObject.SetActive(false);
            }
            else
            {
                position.gameObject.SetActive(true);
                position.SetPosition(lavito);
            }

        }
    }

    public void ResetPositions()
    {
        foreach (var position in _positions)
            position.BuyUpdate();
    }

    private void PlusListNum(int num)
    {
        if (numList + num < 1) return;

        numList += num;
        _listNumText.text = numList.ToString();
    }

    public void ResetListNum()
    {
        numList = 1;
        _listNumText.text = numList.ToString();
    }

    public void SelectCharter() =>
        IsInterier = !IsInterier;
}
