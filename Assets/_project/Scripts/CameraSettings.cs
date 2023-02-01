using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    void Update()
    {
        _camera.transform.position += Vector3.up * (0.25f * Time.deltaTime);
    }
}
