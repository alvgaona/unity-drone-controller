using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F450 {
  [RequireComponent(typeof(BoxCollider))]
  
  public class F450Engine : MonoBehaviour, IEngine {
    [Header("Engine Properties")]
  
    [SerializeField] private float _maxPower = 4f;
    [SerializeField] private float _lerpSpeed = 2f;

    [Header("Propeller properties")]
    [SerializeField] private Transform _propeller;
    [SerializeField] private float _propellerRotationSpeed = 20f;

    private float _finalEngineForce;

    public void InitEngine() {
      throw new System.NotImplementedException();
    }
  
    public void UpdateEngine(Rigidbody rigidbody, F450Inputs input) {
      /* Opposite force:
      *  You can add to engineForce a force opposite to the gravity;this makes flying the UAV a bit easier.
      *  F = -Fg = rigidbody.mass * Physics.gravity.magnitude
      */
      float engineForce = input.Throttle * _maxPower / 4f;

      _finalEngineForce = Mathf.Lerp(_finalEngineForce, engineForce, Time.deltaTime * _lerpSpeed);

      rigidbody.AddForce(transform.up * _finalEngineForce, ForceMode.Force);

      HandlePropeller();
    }

    public void HandlePropeller() {
      if(!_propeller) {
        return;
      }
      
      _propeller.Rotate(Vector3.up, _propellerRotationSpeed);
    }
  }
}

