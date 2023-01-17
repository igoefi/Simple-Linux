using UnityEngine;

public class TransformFollow : MonoBehaviour
{
    [SerializeField] Transform _target;

    private void LateUpdate() =>
        transform.position = _target.position;

}
