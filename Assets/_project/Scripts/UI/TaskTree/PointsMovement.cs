using System;
using UnityEngine;

public class PointsMovement : MonoBehaviour
{
    [SerializeField] float _speed;

    [SerializeField] RectTransform _pointsTransform;

    [SerializeField] float _minPositionY;
    [SerializeField] float _maxPositionY;


    private void Update()
    {
        float axis = Input.GetAxis("Mouse ScrollWheel");

        if (axis != 0)
        {
            _pointsTransform.localPosition += (Vector3)Vector2.up * _speed * -axis * Time.deltaTime;
            float yPosition = Math.Max(_minPositionY, Math.Min(_pointsTransform.anchoredPosition.y, _maxPositionY));

            if (yPosition != _pointsTransform.anchoredPosition.y)
                _pointsTransform.anchoredPosition = new Vector2(0, yPosition);
        }

    }

}
