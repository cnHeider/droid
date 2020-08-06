﻿using System;
using System.Collections.Generic;
using droid.Runtime.Interfaces;
using droid.Runtime.Structs.Space;
using UnityEngine;

namespace droid.Runtime.Prototyping.Sensors.Spatial.Rigidbody {
  /// <inheritdoc cref="Sensor" />
  /// <summary>
  /// </summary>
  public class SingleVelocitySensor : Sensor,
                                      IHasSingle {
    [SerializeField] UnityEngine.Rigidbody _rigidbody;
    [SerializeField] Space1 _single_space = Space1.MinusOneOne * 10;
    [SerializeField] float _observation_value;

    /// <summary>
    ///
    /// </summary>
    enum VelocityAxisEnum {
      X_vel_,
      Y_vel_,
      Z_vel_,
      X_ang_vel_,
      Y_ang_vel_,
      Z_ang_vel_
    }

    [SerializeField] VelocityAxisEnum _velocity_axis = VelocityAxisEnum.X_vel_;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public override string PrototypingTypeName {
      get { return base.PrototypingTypeName + this._velocity_axis; }
    }

    public Space1 SingleSpace { get { return this._single_space; } }

    /// <inheritdoc />
    ///  <summary>
    ///  </summary>
    public override void PreSetup() { this._rigidbody = this.GetComponent<UnityEngine.Rigidbody>(); }

    void OnDrawGizmosSelected() {
      var rb_pos = this._rigidbody.position;
      switch (this._velocity_axis) {
        case VelocityAxisEnum.X_vel_:
          Debug.DrawLine(start : rb_pos, end : rb_pos + Vector3.right * this._rigidbody.velocity.x);
          break;
        case VelocityAxisEnum.Y_vel_:
          Debug.DrawLine(start : rb_pos, end : rb_pos + Vector3.up * this._rigidbody.velocity.y);
          break;
        case VelocityAxisEnum.Z_vel_:
          Debug.DrawLine(start : rb_pos, end : rb_pos + Vector3.forward * this._rigidbody.velocity.z);
          break;
        case VelocityAxisEnum.X_ang_vel_:
          Debug.DrawLine(start : rb_pos, end : rb_pos + Vector3.up * this._rigidbody.angularVelocity.x);
          break;
        case VelocityAxisEnum.Y_ang_vel_:
          Debug.DrawLine(start : rb_pos, end : rb_pos + Vector3.right * this._rigidbody.angularVelocity.y);
          break;
        case VelocityAxisEnum.Z_ang_vel_:
          Debug.DrawLine(start : rb_pos, end : rb_pos + Vector3.forward * this._rigidbody.angularVelocity.z);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

    }
    
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public override IEnumerable<float> FloatEnumerable { get { yield return this._observation_value; } }

    /// <inheritdoc />
    ///  <summary>
    ///  </summary>
    public override void UpdateObservation() {
      float val;
      switch (this._velocity_axis) {
        case VelocityAxisEnum.X_vel_:
          val = this._rigidbody.velocity.x;
          break;
        case VelocityAxisEnum.Y_vel_:
          val = this._rigidbody.velocity.y;
          break;
        case VelocityAxisEnum.Z_vel_:
          val = this._rigidbody.velocity.z;
          break;
        case VelocityAxisEnum.X_ang_vel_:
          val = this._rigidbody.angularVelocity.x;
          break;
        case VelocityAxisEnum.Y_ang_vel_:
          val = this._rigidbody.angularVelocity.y;
          break;
        case VelocityAxisEnum.Z_ang_vel_:
          val = this._rigidbody.angularVelocity.z;
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      this._observation_value = this._single_space.Project(v : val);
    }

    float IHasSingle.ObservationValue { get { return this._observation_value; } }
  }
}