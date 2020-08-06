﻿using System;
using System.Collections.Generic;
using droid.Runtime.Interfaces;
using droid.Runtime.Structs.Space;
using UnityEngine;

namespace droid.Runtime.Prototyping.Sensors.Spatial.Rigidbody {
  /// <inheritdoc cref="Sensor" />
  /// <summary>
  /// </summary>
  [RequireComponent(requiredComponent : typeof(UnityEngine.Rigidbody))]
  public class VelocitySensor : Sensor,
                                IHasTriple {
    [SerializeField] UnityEngine.Rigidbody _rigidbody;
    [SerializeField] Vector3 _velocity;
    [SerializeField] Space3 _velocity_space = Space3.ZeroOne;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public Vector3 ObservationValue {
      get { return this._velocity; }
      set { this._velocity = this._velocity_space.Project(v : value); }
    }

    /// <inheritdoc />
    ///  <summary>
    ///  </summary>
    public Space3 TripleSpace { get { return this._velocity_space; } }

    /// <inheritdoc />
    ///  <summary>
    ///  </summary>
    public override IEnumerable<float> FloatEnumerable {
      get {
        yield return this.ObservationValue.x;
        yield return this.ObservationValue.y;
        yield return this.ObservationValue.z;
      }
    }
    
    void OnDrawGizmosSelected() {
      var rb_pos = this._rigidbody.position;
      Debug.DrawLine(start : rb_pos, end : rb_pos + this._rigidbody.velocity);
    }

    /// <summary>
    /// </summary>
    public override void UpdateObservation() { this.ObservationValue = this._rigidbody.velocity; }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public override void PreSetup() { this._rigidbody = this.GetComponent<UnityEngine.Rigidbody>(); }
  }
}
