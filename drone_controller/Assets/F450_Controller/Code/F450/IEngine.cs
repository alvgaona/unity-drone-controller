using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace F450 {
  public interface IEngine {
    void InitEngine();

    void UpdateEngine(Rigidbody rigidbody, F450Inputs input);
  }
}
