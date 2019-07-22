﻿using System;
using droid.Runtime.Interfaces;
using droid.Runtime.Messaging.Messages;
using droid.Runtime.Structs.Space;
using droid.Runtime.Utilities;
using UnityEngine;
using NeodroidUtilities = droid.Runtime.Utilities.Extensions.NeodroidUtilities;

namespace droid.Runtime.Prototyping.Configurables {
  /// <inheritdoc cref="Configurable" />
  /// <summary>
  /// </summary>
  [AddComponentMenu(ConfigurableComponentMenuPath._ComponentMenuPath
                    + "Friction"
                    + ConfigurableComponentMenuPath._Postfix)]
  [RequireComponent(typeof(Rigidbody))]
  public class FrictionConfigurable : Configurable,
                                      IHasSingle {
    /// <summary>
    /// </summary>
    [SerializeField]
    float _velocity_space = 0;

    /// <summary>
    /// </summary>
    Space1 _angular_velocity = Space1.ZeroOne;

    /// <summary>
    /// </summary>
    string _vel_x;

    Rigidbody _rigidbody;

    /// <summary>
    /// </summary>
    public override string PrototypingTypeName { get { return "RigidbodyConfigurable"; } }

    /// <summary>
    /// </summary>
    public Space1 SingleSpace {
      get { return this._angular_velocity; }
      private set { this._angular_velocity = value; }
    }

    /// <summary>
    /// </summary>
    public float ObservationValue { get { return this._velocity_space; } }

    public override ISpace ConfigurableValueSpace { get; }

    /// <summary>
    /// </summary>
    public override void UpdateCurrentConfiguration() {
      //this.Velocity = this._rigidbody.velocity;
    }

    /// <summary>
    /// </summary>
    protected override void PreSetup() {
      this._rigidbody = this.GetComponent<Rigidbody>();
      this._vel_x = this.Identifier + "VelX";
    }

    /// <summary>
    /// </summary>
    protected override void RegisterComponent() {
      this.ParentEnvironment =
          NeodroidRegistrationUtilities.RegisterComponent(this.ParentEnvironment, (Configurable)this, this._vel_x);
    }

    /// <summary>
    /// </summary>
    protected override void UnRegisterComponent() {
      if (this.ParentEnvironment == null) {
        return;
      }

      this.ParentEnvironment.UnRegister(this, this._vel_x);
    }

    /// <summary>
    /// </summary>
    /// <param name="simulator_configuration"></param>
    public override void ApplyConfiguration(IConfigurableConfiguration simulator_configuration) {
      //var vel = this._rigidbody.velocity;

      var v = simulator_configuration.ConfigurableValue;
      if (this.SingleSpace.DecimalGranularity >= 0) {
        v = (int)Math.Round(v, this.SingleSpace.DecimalGranularity);
      }

      if (this.SingleSpace.MinValue.CompareTo(this.SingleSpace.MaxValue) != 0) {
        //TODO NOT IMPLEMENTED CORRECTLY VelocitySpace should not be index but should check all pairwise values, VelocitySpace.MinValues == VelocitySpace.MaxValues
        if (v < this.SingleSpace.MinValue || v > this.SingleSpace.MaxValue) {
          Debug.Log(string.Format("Configurable does not accept input{2}, outside allowed range {0} to {1}",
                                  this.SingleSpace.MinValue,
                                  this.SingleSpace.MaxValue,
                                  v));
          return; // Do nothing
        }
      }

      #if NEODROID_DEBUG
      if (this.Debugging) {
        Debug.Log("Applying " + v + " To " + this.Identifier);
      }
      #endif

      if (this.RelativeToExistingValue) {
        if (simulator_configuration.ConfigurableName == this._vel_x) {
          //vel.Set(v - vel.x, vel.y, vel.z);
        }
      } else {
        if (simulator_configuration.ConfigurableName == this._vel_x) {
          //vel.Set(v, vel.y, vel.z);
        }
      }

      //this._rigidbody.angularVelocity = ang;
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <returns></returns>
    /// <exception cref="T:System.NotImplementedException"></exception>
    public override Configuration[] SampleConfigurations() {
      return new[] {new Configuration(this._vel_x, this._angular_velocity.Sample())};
    }
  }
}
