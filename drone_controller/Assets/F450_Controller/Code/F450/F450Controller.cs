using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace F450 {
  
  [RequireComponent(typeof(F450Inputs))]
  
  public class F450Controller : BaseRigidBody {
    [Header("Control Properties")] 
    
    [SerializeField] private float _minMaxPitch = 30f;

    [SerializeField] private float _minMaxRoll = 30f;

    [SerializeField] private float _yawPower = 4f;

    [SerializeField] private float _lerpSpeed = 2f;

    private F450Inputs _input;

    private List<IEngine> _engines = new List<IEngine>();

    private float _yaw;
    private float _finalPitch;
    private float _finalRoll;
    private float _finalYaw;
    
    void Start() {
      _input = GetComponent<F450Inputs>();
      _engines = GetComponentsInChildren<IEngine>().ToList<IEngine>();
    }
    
    protected override void HandlePhysics() {
      HandleEngines();
      HandleControls();
    }
    
    protected virtual void HandleEngines() {
      foreach(IEngine engine in _engines) {
        engine.UpdateEngine(_rigidBody, _input);
      }
    }
    
    protected virtual void HandleControls() {
      float pitch = -_input.Cyclic.x * _minMaxPitch;
      float roll = -_input.Cyclic.y * _minMaxRoll;
      _yaw += _input.Pedals * _yawPower;

      _finalPitch = Mathf.Lerp(_finalPitch, pitch, Time.deltaTime * _lerpSpeed);
      _finalRoll = Mathf.Lerp(_finalRoll, roll, Time.deltaTime * _lerpSpeed);
      _finalYaw = Mathf.Lerp(_finalYaw, _yaw, Time.deltaTime * _lerpSpeed);

      Quaternion orientation = Quaternion.Euler(_finalPitch, _finalYaw, _finalRoll);
      _rigidBody.MoveRotation(orientation);
    }
  }
}

