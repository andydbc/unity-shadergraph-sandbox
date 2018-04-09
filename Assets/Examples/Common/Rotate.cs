using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    Transform _target;
    [SerializeField]
    Vector3 _offset = Vector3.zero;
    [SerializeField]
    float _speed = 1.0f;

    void LateUpdate ()
    {
        if (_target == null)
            return;

        transform.LookAt(_target.position + _offset);
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }
}
