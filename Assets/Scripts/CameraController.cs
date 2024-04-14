using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _player;
    [SerializeField]
    private float _smoothTime;
    [SerializeField]
    private Vector3 _offset;
    private Vector3 _velocity;
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        _player = playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = _player.position + _offset;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
        transform.position = smoothPosition;
    }

}
