﻿using droid.Runtime.Interfaces;
using UnityEngine;

namespace droid.Runtime.Prototyping.EnvironmentListener {
  /// <inheritdoc />
  /// <summary>
  /// </summary>
  public class ActionCounter : EnvironmentListener {
    [SerializeField] IAbstractPrototypingEnvironment _environment;

    /// <summary>
    /// </summary>
    public IAbstractPrototypingEnvironment ParentEnvironment {
      get { return this._environment; }
      set { this._environment = value; }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected override void Clear() { }

    /// <summary>
    /// </summary>
    void HandleStep() {
      var reaction = this._environment.LastReaction;
      var motions = reaction.Motions;
      //TODO: implement
    }

    /// <summary>
    ///
    /// </summary>
    public override void PrototypingReset() { }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public override void PreStep() { }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public override void Step() { this.HandleStep(); }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public override void PostStep() { }
  }
}
