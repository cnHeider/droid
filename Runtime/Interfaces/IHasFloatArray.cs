﻿using droid.Runtime.Utilities.Structs;
using UnityEngine;

namespace droid.Runtime.Interfaces {
  /// <summary>
  /// </summary>
  public interface IHasFloatArray {
    /// <summary>
    /// </summary>
    float[] ObservationArray { get; }

    Space1[] ObservationSpace { get; }
  }
}