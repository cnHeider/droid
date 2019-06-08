﻿using droid.Runtime.Interfaces;
using droid.Runtime.Messaging.Messages;
using droid.Runtime.Utilities.Misc;
using droid.Runtime.Utilities.Sampling;
using droid.Runtime.Utilities.Structs;
using UnityEngine;

namespace droid.Runtime.Prototyping.Configurables {
  /// <inheritdoc />
  /// <summary>
  /// </summary>
  [AddComponentMenu(ConfigurableComponentMenuPath._ComponentMenuPath
                    + "Light"
                    + ConfigurableComponentMenuPath._Postfix)]
  [RequireComponent(typeof(Light))]
  public class LightConfigurable : Configurable {
    string _color_r;
    string _color_g;
    string _color_b;
    string _shadow_strength;
    string _intensity;
    string _indirect_multiplier;

    Light _light;

    [SerializeField]
    Space3 _color_space = new Space3 {
                                         _decimal_granularity = 2,
                                         _Min_Values = Vector3.one * 0.7f,
                                         _Max_Values = Vector3.one * 1f
                                     };

    [SerializeField]
    Space3 _int_ind_sha_space = new Space3 {
                                               _decimal_granularity = 2,
                                               _Min_Values = Vector3.one * 0.0f,
                                               _Max_Values = Vector3.one * 1f,
                                               DistributionSampler =
                                                   new DistributionSampler(DistributionEnum.Linear_) {
                                                                                                         _factor
                                                                                                             = -1
                                                                                                     }
                                           };

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected override void PreSetup() {
      this._shadow_strength = this.Identifier + "ShadowStrength";
      this._color_r = this.Identifier + "ColorR";
      this._color_g = this.Identifier + "ColorG";
      this._color_b = this.Identifier + "ColorB";
      this._intensity = this.Identifier + "Intensity";
      this._indirect_multiplier = this.Identifier + "IndirectMultiplier";

      this._light = this.GetComponent<Light>();
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected override void RegisterComponent() {
      this.ParentEnvironment =
          NeodroidUtilities.RegisterComponent(this.ParentEnvironment,
                                              (Configurable)this,
                                              this._shadow_strength);
      this.ParentEnvironment =
          NeodroidUtilities.RegisterComponent(this.ParentEnvironment, (Configurable)this, this._color_r);
      this.ParentEnvironment =
          NeodroidUtilities.RegisterComponent(this.ParentEnvironment, (Configurable)this, this._color_b);
      this.ParentEnvironment =
          NeodroidUtilities.RegisterComponent(this.ParentEnvironment, (Configurable)this, this._color_g);
      this.ParentEnvironment =
          NeodroidUtilities.RegisterComponent(this.ParentEnvironment, (Configurable)this, this._intensity);
      this.ParentEnvironment =
          NeodroidUtilities.RegisterComponent(this.ParentEnvironment,
                                              (Configurable)this,
                                              this._indirect_multiplier);
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected override void UnRegisterComponent() {
      if (this.ParentEnvironment == null) {
        return;
      }

      this.ParentEnvironment.UnRegister(this, this._shadow_strength);
      this.ParentEnvironment.UnRegister(this, this._color_r);
      this.ParentEnvironment.UnRegister(this, this._color_g);
      this.ParentEnvironment.UnRegister(this, this._color_b);
      this.ParentEnvironment.UnRegister(this, this._intensity);
      this.ParentEnvironment.UnRegister(this, this._indirect_multiplier);
    }

    /// <summary>
    /// </summary>
    /// <param name="configuration"></param>
    public override void ApplyConfiguration(IConfigurableConfiguration configuration) {
      #if NEODROID_DEBUG
      if (this.Debugging) {
        DebugPrinting.ApplyPrint(this.Debugging, configuration, this.Identifier);
      }
      #endif

      if (configuration.ConfigurableName == this._shadow_strength) {
        this._light.shadowStrength = configuration.ConfigurableValue;
      } else if (configuration.ConfigurableName == this._color_r) {
        var c = this._light.color;
        c.r = configuration.ConfigurableValue;
        this._light.color = c;
      } else if (configuration.ConfigurableName == this._color_g) {
        var c = this._light.color;
        c.g = configuration.ConfigurableValue;
        this._light.color = c;
      } else if (configuration.ConfigurableName == this._color_b) {
        var c = this._light.color;
        c.b = configuration.ConfigurableValue;
        this._light.color = c;
      } else if (configuration.ConfigurableName == this._intensity) {
        this._light.intensity = configuration.ConfigurableValue;
      } else if (configuration.ConfigurableName == this._indirect_multiplier) {
        this._light.bounceIntensity = configuration.ConfigurableValue;
      }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override Configuration[] SampleConfigurations() {
      var o = this._int_ind_sha_space.Sample();
      var v = this._color_space.Sample();

      return new[] {
                       new Configuration(this._color_r, v.x),
                       new Configuration(this._color_g, v.y),
                       new Configuration(this._color_b, v.z),
                       new Configuration(this._intensity, o.x),
                       new Configuration(this._indirect_multiplier, o.y),
                       new Configuration(this._shadow_strength, o.z)
                   };
    }
  }
}
