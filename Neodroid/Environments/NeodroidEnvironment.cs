﻿using System;
using System.Globalization;
using droid.Neodroid.Managers;
using droid.Neodroid.Utilities.EventRecipients.droid.Neodroid.Utilities.Unsorted;
using droid.Neodroid.Utilities.GameObjects;
using droid.Neodroid.Utilities.Messaging.Messages;
using droid.Neodroid.Utilities.Unsorted;
using UnityEngine;

namespace droid.Neodroid.Environments {
  /// <inheritdoc />
  ///  <summary>
  ///  </summary>
  public abstract class NeodroidEnvironment : PrototypingGameObject {
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public abstract override String PrototypingTypeName { get; }

    /// <summary>
    ///
    /// </summary>
    [Header("Environment", order = 100)]
    [SerializeField]
    protected NeodroidManager _Simulation_Manager;

    /// <summary>
    ///
    /// </summary>
    [SerializeField]
    int _episode_length = 1000;
    
    /// <summary>
    ///
    /// </summary>
    protected float _Lastest_Reset_Time;


    /// <summary>
    ///
    /// </summary>
    public bool Terminated { get { return this._Terminated; } }

    /// <summary>
    ///
    /// </summary>
    protected float _Energy_Spent;

    /// <summary>
    ///
    /// </summary>
    protected bool _Terminated;

    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public void IdentifierString(DataPoller recipient) {
      recipient.PollData(this.Identifier);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public void EnergyString(DataPoller recipient) {
      recipient.PollData(this._Energy_Spent.ToString(CultureInfo.InvariantCulture));
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public void FrameString(DataPoller recipient) {
      recipient.PollData($"{this.CurrentFrameNumber}/{this.EpisodeLength}");
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public void TerminatedBoolean(DataPoller recipient) {
      if (this._Terminated) {
        recipient.PollData(true);
      }

      recipient.PollData(false);
    }
    
    /// <summary>
    ///
    /// </summary>
    protected bool _Terminable = true;
    /// <summary>
    ///
    /// </summary>
    protected string _Termination_Reason = "None";

    /// <summary>
    ///
    /// </summary>
    protected bool _Configure;

    /// <summary>
    ///
    /// </summary>
    protected bool _Describe;

    /// <summary>
    ///
    /// </summary>
    public int CurrentFrameNumber { get; protected set; }

    /// <summary>
    ///
    /// </summary>
    public int EpisodeLength { get { return this._episode_length; } set { this._episode_length = value; } }

    /// <summary>
    ///
    /// </summary>
    protected bool _Resetting = false;

    /// <summary>
    ///
    /// </summary>
    public bool IsResetting { get { return this._Resetting; } }

    /// <summary>
    ///
    /// </summary>
    public String TerminationReason {
      get { return this._Termination_Reason; }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected override void Setup() {
      this.PreSetup();
      if (!this._Simulation_Manager) {
        this._Simulation_Manager = FindObjectOfType<NeodroidManager>();
      }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected override void RegisterComponent() {
      if (this._Simulation_Manager) {
        this._Simulation_Manager = NeodroidUtilities.MaybeRegisterComponent(this._Simulation_Manager, this);
      }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    protected override void UnRegisterComponent() {
      if (this._Simulation_Manager) {
        this._Simulation_Manager.UnRegister(this);
      }
    }

    /// <summary>
    ///
    /// </summary>
    protected virtual void PreSetup() { }

    /// <summary>
    ///
    /// </summary>
    public abstract void PostStep();

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public abstract Reaction SampleReaction();

    /// <summary>
    ///
    /// </summary>
    /// <param name="reaction"></param>
    /// <returns></returns>
    public abstract EnvironmentState ReactAndCollectState(
        Reaction reaction);

    /// <summary>
    ///
    /// </summary>
    /// <param name="reaction"></param>
    /// <returns></returns>
    public abstract void React(Reaction reaction);

    /// <summary>
    ///
    /// </summary>
    public abstract void Tick();

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public abstract EnvironmentState CollectState();
  }
}
