﻿using droid.Runtime.Interfaces;
using UnityEngine;

namespace droid.Runtime.Prototyping.Actuators.WheelColliderActuator {
  /// <inheritdoc />
  /// <summary>
  /// </summary>
  [AddComponentMenu(menuName : ActuatorComponentMenuPath._ComponentMenuPath
                               + "WheelCollider/Steering"
                               + ActuatorComponentMenuPath._Postfix)]
  [RequireComponent(requiredComponent : typeof(WheelCollider))]
  public class SteeringActuator : Actuator {
    /// <summary>
    /// </summary>
    [SerializeField]
    WheelCollider _wheel_collider;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public override void Setup() { this._wheel_collider = this.GetComponent<WheelCollider>(); }

    /// <summary>
    /// </summary>
    void FixedUpdate() { ApplyLocalPositionToVisuals(col : this._wheel_collider); }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="motion"></param>
    protected override void InnerApplyMotion(IMotion motion) {
      this._wheel_collider.steerAngle = motion.Strength;
    }

    public override string[] InnerMotionNames => new[] {"steerAngle"};

    /// <summary>
    /// </summary>
    /// <param name="col"></param>
    static void ApplyLocalPositionToVisuals(WheelCollider col) {
      if (col.transform.childCount == 0) {
        return;
      }

      var visual_wheel = col.transform.GetChild(0);

      col.GetWorldPose(pos : out var position, quat : out var rotation);

      visual_wheel.transform.position = position;
      visual_wheel.transform.rotation = rotation;
    }
  }
}
