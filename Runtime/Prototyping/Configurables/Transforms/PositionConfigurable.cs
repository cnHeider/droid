﻿using droid.Runtime.Interfaces;
using droid.Runtime.Messaging.Messages;
using droid.Runtime.Structs.Space;
using droid.Runtime.Structs.Space.Sample;
using droid.Runtime.Utilities;
using UnityEngine;

namespace droid.Runtime.Prototyping.Configurables.Transforms {
  /// <inheritdoc cref="Configurable" />
  /// <summary>
  /// </summary>
  [AddComponentMenu(ConfigurableComponentMenuPath._ComponentMenuPath
                    + "Position"
                    + ConfigurableComponentMenuPath._Postfix)]
  public class PositionConfigurable : SpatialConfigurable,
                                      IHasTriple {
    #region Fields

    [SerializeField] Vector3 _position = Vector3.zero;
    [SerializeField] bool normalised_overwrite_space_if_env_bounds = true;
    [SerializeField] bool _use_environments_space = false;
    [SerializeField] SampleSpace3 _space = new SampleSpace3 {Space = Space3.ZeroOne};

    #endregion

    /// <summary>
    /// </summary>
    string _x;

    /// <summary>
    /// </summary>
    string _y;

    /// <summary>
    /// </summary>
    string _z;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public Vector3 ObservationValue { get { return this._position; } }

    public Space3 TripleSpace { get { return this._space._space; } }

    /// <summary>
    ///
    /// </summary>
    protected override void PreSetup() {
      if (this.normalised_overwrite_space_if_env_bounds) {
        var dec_gran = 4;
        if (this._space.Space != null && this.ParentEnvironment?.PlayableArea) {
          dec_gran = this._space.Space.DecimalGranularity;
        }

        this._space.Space = Space3.FromCenterExtents(this.ParentEnvironment.PlayableArea.Bounds.extents,
                                                     decimal_granularity : dec_gran);
      }

      this._x = this.Identifier + "X_";
      this._y = this.Identifier + "Y_";
      this._z = this.Identifier + "Z_";
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected override void RegisterComponent() {
      this.ParentEnvironment =
          NeodroidRegistrationUtilities.RegisterComponent(this.ParentEnvironment,
                                                          (Configurable)this,
                                                          this._x);
      this.ParentEnvironment =
          NeodroidRegistrationUtilities.RegisterComponent(this.ParentEnvironment,
                                                          (Configurable)this,
                                                          this._y);
      this.ParentEnvironment =
          NeodroidRegistrationUtilities.RegisterComponent(this.ParentEnvironment,
                                                          (Configurable)this,
                                                          this._z);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void UnRegisterComponent() {
      if (this.ParentEnvironment == null) {
        return;
      }

      this.ParentEnvironment.UnRegister(this, this._x);
      this.ParentEnvironment.UnRegister(this, this._y);
      this.ParentEnvironment.UnRegister(this, this._z);
    }

    /// <summary>
    ///
    /// </summary>
    public override ISamplable ConfigurableValueSpace { get { return this._space; } }

    /// <summary>
    ///
    /// </summary>
    public override void UpdateCurrentConfiguration() {
      if (this._use_environments_space) {
        this._position = this.ParentEnvironment.TransformPoint(this.transform.position);
      } else {
        this._position = this.transform.position;
      }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="simulator_configuration"></param>
    public override void ApplyConfiguration(IConfigurableConfiguration simulator_configuration) {
      var pos = this.transform.position;
      if (this._use_environments_space) {
        pos = this.ParentEnvironment.TransformPoint(this.transform.position);
      }

      float v;
      if (this._space._space.normalised) {
        if (simulator_configuration.ConfigurableName == this._x) {
          v = this._space._space.Xspace.ClipRoundDenormaliseClip(simulator_configuration.ConfigurableValue);
        } else if (simulator_configuration.ConfigurableName == this._y) {
          v = this._space._space.Yspace.ClipRoundDenormaliseClip(simulator_configuration.ConfigurableValue);
        } else {
          v = this._space._space.Zspace.ClipRoundDenormaliseClip(simulator_configuration.ConfigurableValue);
        }
      } else {
        v = simulator_configuration.ConfigurableValue;
      }

      #if NEODROID_DEBUG
      if (this.Debugging) {
        Debug.Log($"Applying {v} to {simulator_configuration.ConfigurableName} configurable");
      }
      #endif

      if (this.RelativeToExistingValue) {
        if (simulator_configuration.ConfigurableName == this._x) {
          pos.Set(v + pos.x, pos.y, pos.z);
        } else if (simulator_configuration.ConfigurableName == this._y) {
          pos.Set(pos.x, v + pos.y, pos.z);
        } else if (simulator_configuration.ConfigurableName == this._z) {
          pos.Set(pos.x, pos.y, v + pos.z);
        }
      } else {
        if (simulator_configuration.ConfigurableName == this._x) {
          pos.Set(v, pos.y, pos.z);
        } else if (simulator_configuration.ConfigurableName == this._y) {
          pos.Set(pos.x, v, pos.z);
        } else if (simulator_configuration.ConfigurableName == this._z) {
          pos.Set(pos.x, pos.y, v);
        }
      }

      var inv_pos = pos;
      if (this._use_environments_space) {
        inv_pos = this.ParentEnvironment.InverseTransformPoint(inv_pos);
      }

      #if NEODROID_DEBUG
      if (this.Debugging) {
        Debug.Log($"Setting pos of {this} to {inv_pos}, from {pos} and r {simulator_configuration.ConfigurableValue}");
      }
      #endif

      this.transform.position = inv_pos;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public override Configuration[] SampleConfigurations() {
      var sample = this._space.Sample();
      return new[] {
                       new Configuration(this._x, sample.x),
                       new Configuration(this._y, sample.y),
                       new Configuration(this._z, sample.z)
                   };
    }
  }
}