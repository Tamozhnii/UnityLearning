using System;
using UnityEngine;

public class WalkThereAndBack : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _target;
    private bool _isGoBack = false;
    private float _speed = 1f;

    void Update()
    {
        if (Math.Round(transform.position.y, 1) != Math.Round(_target.position.y, 1) && _isGoBack == false)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
        }
        else if (Math.Round(transform.position.y, 1) == Math.Round(_target.position.y, 1) && _isGoBack == false)
        {
            _isGoBack = true;
        }
        else if (Math.Round(transform.position.y, 1) != Math.Round(_startPosition.position.y, 1) && _isGoBack)
        {
            transform.position = Vector3.Lerp(transform.position, _startPosition.position, _speed * Time.deltaTime);
        }
    }
}
