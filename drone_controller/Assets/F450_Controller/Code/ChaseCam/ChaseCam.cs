using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F450 {
  public class ChaseCam : MonoBehaviour {
    [Header("Chase camera properties")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSeed = 0.125f;
    [SerializeField] private Vector3 offset = new Vector3(-0.78f, 0.54f, -0.12f);

    void FixedUpdate() {
      Vector3 desiredPosition = _target.position + offset;
      Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSeed);
      transform.position = smoothedPosition;
      transform.LookAt(_target);
    }
  }
}

