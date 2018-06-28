﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using droid.Neodroid.Environments;
using droid.Neodroid.Utilities.Interfaces;
using droid.Neodroid.Utilities.Messaging;
using droid.Neodroid.Utilities.Messaging.Messages;
using droid.Neodroid.Utilities.ScriptableObjects;
using UnityEditor;
using UnityEngine;
using Object = System.Object;
using SimulatorConfiguration = droid.Neodroid.Utilities.ScriptableObjects.SimulatorConfiguration;

#if UNITY_EDITOR

#endif

namespace droid.Neodroid.Managers {
  /// <inheritdoc cref="UnityEngine.MonoBehaviour" />
  /// <summary>
  /// </summary>
  [AddComponentMenu("Neodroid/Managers/VanillaManager")]
  public abstract class NeodroidManager : MonoBehaviour,
                                          IHasRegister<NeodroidEnvironment> {
    #region PrivateFields

    /// <summary>
    ///
    /// </summary>
    [Header("Development", order = 110)]
    [SerializeField]
    bool _debugging;

    /// <summary>
    ///
    /// </summary>
    Object _send_lock = new Object();

    /// <summary>
    ///
    /// </summary>
    [SerializeField]
    bool _testing_motors;

    #if UNITY_EDITOR
    /// <summary>
    ///
    /// </summary>
    const int _script_execution_order = -1000;
    #endif

    /// <summary>
    ///
    /// </summary>
    [Header("Simulation", order = 80)]
    [SerializeField]
    SimulatorConfiguration _configuration;

    /// <summary>
    ///
    /// </summary>
    [SerializeField] int _skip_frame_i;

    /// <summary>
    ///
    /// </summary>
    [SerializeField] bool _syncing_environments;

    /// <summary>
    ///
    /// </summary>
    [SerializeField] bool _awaiting_reply;

    [SerializeField] bool _step;

    WaitForEndOfFrame _wait_for_end_of_frame = new WaitForEndOfFrame();
    WaitForFixedUpdate _wait_for_fixed_update = new WaitForFixedUpdate();
    List<Reaction> _sample_reactions = new List<Reaction>();

    #endregion

    /// <summary>
    ///
    /// </summary>
    public static NeodroidManager Instance { get; private set; }

    /// <summary>
    ///
    /// </summary>
    public SimulatorConfiguration Configuration {
      get {
        if (this._configuration == null) {
          this._configuration = ScriptableObject.CreateInstance<SimulatorConfiguration>();
        }

        return this._configuration;
      }
      set { this._configuration = value; }
    }

    /// <summary>
    /// Can be subscribed to for pre fixed update events (Will be called before any FixedUpdate on any script)
    /// </summary>
    public event Action EarlyFixedUpdateEvent;

    /// <summary>
    ///
    /// </summary>
    public event Action FixedUpdateEvent;

    /// <summary>
    ///
    /// </summary>
    public event Action LateFixedUpdateEvent;

    /// <summary>
    /// Can be subscribed to for pre update events (Will be called before any Update on any script)
    /// </summary>
    public event Action EarlyUpdateEvent;

    /// <summary>
    ///
    /// </summary>
    public event Action UpdateEvent;

    /// <summary>
    ///
    /// </summary>
    public event Action LateUpdateEvent;

    /// <summary>
    ///
    /// </summary>
    public event Action OnPostRenderEvent;

    /// <summary>
    ///
    /// </summary>
    public event Action OnRenderImageEvent;

    /// <summary>
    ///
    /// </summary>
    public event Action OnEndOfFrameEvent;

    /// <summary>
    ///
    /// </summary>
    public event Action OnReceiveEvent;

    /// <summary>
    ///
    /// </summary>
    void FetchCommmandLineArguments() {
      var arguments = Environment.GetCommandLineArgs();

      for (var i = 0; i < arguments.Length; i++) {
        if (arguments[i] == "-ip") {
          this.Configuration.IpAddress = arguments[i + 1];
        }

        if (arguments[i] == "-port") {
          this.Configuration.Port = int.Parse(arguments[i + 1]);
        }
      }
    }

    /// <summary>
    ///
    /// </summary>
    void CreateMessagingServer() {
      try {
        if (this.Configuration.IpAddress != "" || this.Configuration.Port != 0) {
          this._Message_Server = new MessageServer(
              this.Configuration.IpAddress,
              this.Configuration.Port,
              false,
              this.Debugging);
        } else {
          this._Message_Server = new MessageServer(this.Debugging);
        }
      } catch (Exception exception) {
        Debug.Log(exception);
        throw;

        //TODO: close application is port is already in use.
      }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="threaded"></param>
    void StartMessagingServer(bool threaded = false) {
      /*if (threaded) {
        this._Message_Server.ListenForClientToConnect(this.OnConnectCallback, this.OnDebugCallback);
        #if NEODROID_DEBUG

        if (this.Debugging) {
          Debug.Log("Started Messaging Server in a new thread");
        }
        #endif
      } else {*/

      this._Message_Server.ListenForClientToConnect(this.OnDebugCallback);
      #if NEODROID_DEBUG
      if (this.Debugging) {
        Debug.Log("Started Messaging Server");
      }
      #endif

      if (threaded) {
        this.OnListeningCallback();
      }

      //}
    }

    #region Getter And Setters

    /// <summary>
    ///
    /// </summary>
    public Reaction[] CurrentReactions {
      get {
        lock (this._send_lock) {
          return this._Current_Reactions;
        }
      }
      set {
        lock (this._send_lock) {
          this._Current_Reactions = value;
        }
      }
    }

    /// <summary>
    ///
    /// </summary>
    public float SimulationTime {
      get { return Time.timeScale; }
      set {
        Time.timeScale = value;
        if (this.Configuration.UpdateFixedTimeScale) {
          Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool HasStepped { get { return this._has_stepped; } set { this._has_stepped = value; } }

    /// <summary>
    ///
    /// </summary>
    public bool TestMotors { get { return this._testing_motors; } set { this._testing_motors = value; } }

    /// <summary>
    ///
    /// </summary>
    public bool Debugging { get { return this._debugging; } set { this._debugging = value; } }

    /// <summary>
    ///
    /// </summary>
    public bool AwaitingReply {
      get {
        lock (this._send_lock) {
          return this._awaiting_reply;
        }
      }
      set {
        lock (this._send_lock) {
          this._awaiting_reply = value;
        }
      }
    }

    /// <summary>
    ///
    /// </summary>
    public bool IsSyncingEnvironments {
      get { return this._syncing_environments; }
      set { this._syncing_environments = value; }
    }

    public bool Stepping { get { return this._step; } }

    #endregion

    #region PrivateMembers

    /// <summary>
    ///
    /// </summary>
    protected Dictionary<string, NeodroidEnvironment> _Environments =
        new Dictionary<string, NeodroidEnvironment>();

    /// <summary>
    ///
    /// </summary>
    public void Clear() { this._Environments.Clear(); }

    /// <summary>
    ///
    /// </summary>
    protected MessageServer _Message_Server;

    /// <summary>
    ///
    /// </summary>
    protected Reaction[] _Current_Reactions = new Reaction[] { };
    
    [SerializeField] bool _has_stepped;

#endregion

    #region UnityCallbacks

    /// <summary>
    ///
    /// </summary>
    protected void Awake() {
      if (Instance == null) {
        Instance = this;
      } else if (Instance == this) {
        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log("Using " + Instance);
        }
        #endif
      } else {
        Debug.LogWarning(
            "WARNING! There are multiple SimulationManagers in the scene! Only using " + Instance);
      }

      #if UNITY_EDITOR
      if (!Application.isPlaying) {
        var manager_script = MonoScript.FromMonoBehaviour(this);
        if (MonoImporter.GetExecutionOrder(manager_script) != _script_execution_order) {
          MonoImporter.SetExecutionOrder(
              manager_script,
              _script_execution_order); // Ensures that PreStep is called first, before all other scripts.
          Debug.LogWarning(
              "Execution Order changed, you will need to press play again to make everything function correctly!");
          EditorApplication.isPlaying = false;
          //TODO: UnityEngine.Experimental.LowLevel.PlayerLoop.SetPlayerLoop(new UnityEngine.Experimental.LowLevel.PlayerLoopSystem());
        }
      }
      #endif
    }

    /// <summary>
    ///
    /// </summary>
    protected void Start() {
      this.FetchCommmandLineArguments();

      if (this.Configuration == null) {
        this.Configuration = ScriptableObject.CreateInstance<SimulatorConfiguration>();
      }

      this.ApplyConfigurationToUnity(this.Configuration);

      if (this.Configuration.SimulationType == SimulationType.Physics_dependent_) {
        this.EarlyFixedUpdateEvent += this.OnPreTick;
        this.FixedUpdateEvent += this.OnTick;
        this.FixedUpdateEvent += this.Tick;
        this.LateFixedUpdateEvent += this.OnPostTick;
        this.StartCoroutine(this.LateFixedUpdateEventGenerator());
      } else {
        this.EarlyUpdateEvent += this.OnPreTick;
        this.UpdateEvent += this.OnTick;
        this.UpdateEvent += this.Tick;
        switch (this.Configuration.FrameFinishes) {
          case FrameFinishes.Late_update_:
            this.LateUpdateEvent += this.OnPostTick;
            break;
          case FrameFinishes.On_post_render_:
            this.OnPostRenderEvent += this.OnPostTick;
            break;
          case FrameFinishes.On_render_image_:
            this.OnRenderImageEvent += this.OnPostTick;
            break;
          case FrameFinishes.End_of_frame_:
            this.StartCoroutine(this.EndOfFrameEventGenerator());
            this.OnEndOfFrameEvent += this.OnPostTick;
            break;
          default: throw new ArgumentOutOfRangeException();
        }
      }

      this.CreateMessagingServer();
      if (this.Configuration.SimulationType == SimulationType.Physics_dependent_) {
        this.StartMessagingServer(); // Remember to manually bind receive to an event in a derivation
      } else {
        this.StartMessagingServer(threaded : true);
      }
    }

    /// <summary>
    ///
    /// </summary>
    public void ApplyConfigurationToUnity(SimulatorConfiguration configuration) {
      QualitySettings.SetQualityLevel(configuration.QualityLevel, true);
      this.SimulationTime = configuration.TimeScale;
      Application.targetFrameRate = configuration.TargetFrameRate;
      QualitySettings.vSyncCount = 0;


      #if !UNITY_EDITOR
      if(      configuration.ApplyResolutionSettings){
      Screen.SetResolution(
          width : configuration.Width,
          height : configuration.Height,
          fullscreen : configuration.FullScreen);
        }
      #endif
    }

    /// <summary>
    ///
    /// </summary>
    void OnPostRender() { this.OnPostRenderEvent?.Invoke(); }

    /// <summary>
    ///
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dest"></param>
    void OnRenderImage(RenderTexture src, RenderTexture dest) {
      this.OnRenderImageEvent?.Invoke(); //TODO: May not work
    }

    /// <summary>
    ///
    /// </summary>
    protected void FixedUpdate() {
      this.EarlyFixedUpdateEvent?.Invoke();
      this.FixedUpdateEvent?.Invoke();
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    IEnumerator LateFixedUpdateEventGenerator() {
      while (true) {
        yield return this._wait_for_fixed_update;
        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log("LateFixedUpdate");
        }
        #endif
        this.LateFixedUpdateEvent?.Invoke();
      }

      // ReSharper disable once IteratorNeverReturns
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    protected IEnumerator EndOfFrameEventGenerator() {
      while (true) {
        yield return this._wait_for_end_of_frame;
        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log("EndOfFrameEvent");
        }
        #endif
        this.OnEndOfFrameEvent?.Invoke();
      }

      // ReSharper disable once IteratorNeverReturns
    }

    /// <summary>
    ///
    /// </summary>
    protected void Update() {
      this.EarlyUpdateEvent?.Invoke();
      this.UpdateEvent?.Invoke();
    }

    /// <summary>
    ///
    /// </summary>
    protected void LateUpdate() { this.LateUpdateEvent?.Invoke(); }

    #endregion

    #region PrivateMethods

    /// <summary>
    ///
    /// </summary>
    protected void OnPreTick() {
      if (this.Configuration.StepExecutionPhase == ExecutionPhase.Before_) {
        this.ExecuteStep();
      }
    }

    /// <summary>
    ///
    /// </summary>
    protected void OnTick() {
      if (this.Configuration.StepExecutionPhase == ExecutionPhase.Middle_) {
        this.ExecuteStep();
      }
    }

    /// <summary>
    ///
    /// </summary>
    protected void OnPostTick() {
      foreach (var environment in this._Environments.Values) {
        environment.PostStep();
      }

      if (this.Configuration.StepExecutionPhase == ExecutionPhase.After_) {
        this.ExecuteStep();
      }
      
      this.ClearCurrentReactions();
    }
    
    /// <summary>
    ///
    /// </summary>
    void ExecuteStep() {
      if (!this._syncing_environments) {
        this.React(this.CurrentReactions);
      }

      if (this.AwaitingReply) {
        var states = this.CollectStates();
        this.PostReact(states);
      }
    }
    
    /// <summary>
    ///
    /// </summary>
    protected void Tick() {
      if (this.TestMotors) {
        this.React(this.SampleRandomReactions());
        this.CollectStates();
      }

      foreach (var environment in this._Environments.Values) {
        environment.Tick();
      }

      #if NEODROID_DEBUG
      if (this.Debugging) {
        Debug.Log("Tick");
      }
      #endif
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="states"></param>
    protected void PostReact(EnvironmentState[] states) {
      lock (this._send_lock) {
        foreach (var env in this._Environments.Values) {
          if (env.IsResetting) {
            #if NEODROID_DEBUG
            if (this.Debugging) {
              Debug.Log($"Environment {env} is resetting");
            }
            #endif

            this._syncing_environments = true;
            return;
          }
        }

        this._syncing_environments = false;
        if (this._skip_frame_i >= this.Configuration.FrameSkips) {
          this.Reply(states);
          this.AwaitingReply = false;
          this._skip_frame_i = 0;
        } else {
          this._skip_frame_i += 1;
          #if NEODROID_DEBUG
          if (this.Debugging) {
            Debug.Log($"Skipping frame, {this._skip_frame_i}/{this.Configuration.FrameSkips}");
          }
          #endif
          if (this.Configuration.ReplayReactionInSkips) {
            return;
          }
        }


      }
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    protected Reaction[] SampleRandomReactions() {
      this._sample_reactions.Clear();
      foreach (var environment in this._Environments.Values) {
        this._sample_reactions.Add(environment.SampleReaction());
      }

      return this._sample_reactions.ToArray();
    }

    //TODO: EnvironmentState[][] states for aggregation of states
    /// <summary>
    ///
    /// </summary>
    /// <param name="states"></param>
    void Reply(EnvironmentState[] states) {
      lock (this._send_lock) {
        var configuration_message = new SimulatorConfigurationMessage(this.Configuration);
        this._Message_Server.SendStates(
            states,
            simulator_configuration_message : configuration_message,
            do_serialise_unobservables : this.Configuration.AlwaysSerialiseUnobservables,
            serialise_indidual_observables : this.Configuration.AlwaysSerialiseIndidualObservables);
        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log("Replying");
        }

        #endif
      }
    }

    /// <summary>
    ///
    /// </summary>
    void ClearCurrentReactions() {
      this._step = false;
      this.CurrentReactions = new Reaction[] { };
    }

    #endregion

    #region PublicMethods

    /// <summary>
    ///
    /// </summary>
    /// <param name="reaction"></param>
    /// <returns></returns>
    public EnvironmentState[] ReactAndCollectStates(Reaction reaction) {
      this.SetStepping(reaction);
      var states = new EnvironmentState[this._Environments.Values.Count];
      var i = 0;
      foreach (var environment in this._Environments.Values) {
        if (reaction.RecipientEnvironment != "all") {
          #if NEODROID_DEBUG
          if (this.Debugging) {
            Debug.Log($"Applying reaction to {reaction.RecipientEnvironment} environment");
          }
          #endif
          if (this._Environments.ContainsKey(reaction.RecipientEnvironment)) {
            states[i++] = this._Environments[reaction.RecipientEnvironment].ReactAndCollectState(reaction);
          }
          #if NEODROID_DEBUG
          else {
            if (this.Debugging) {
              Debug.Log($"Could not find environment: {reaction.RecipientEnvironment}");
            }
          }
          #endif
        } else {
          #if NEODROID_DEBUG
          if (this.Debugging) {
            Debug.Log("Applying reaction to all environments");
          }
          #endif
          states[i++] = environment.ReactAndCollectState(reaction);
        }
      }

      return states;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="reaction"></param>
    /// <returns></returns>
    public void React(Reaction reaction) {
      this.SetStepping(reaction);
      if (this._Environments.ContainsKey(reaction.RecipientEnvironment)) {
        this._Environments[reaction.RecipientEnvironment].React(reaction);
      } else {
        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log($"Could not find an environment with the identifier: {reaction.RecipientEnvironment}");
        }
        #endif

        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log($"Applying to all environments");
        }
        #endif

        foreach (var environment in this._Environments.Values) {
          environment.React(reaction);
        }
      }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="reactions"></param>
    /// <returns></returns>
    public void React(Reaction[] reactions) {
      this.SetStepping(reactions);
      foreach (var reaction in reactions) {
        if (this._Environments.ContainsKey(reaction.RecipientEnvironment)) {
          this._Environments[reaction.RecipientEnvironment].React(reaction);
        } else {
          #if NEODROID_DEBUG
          if (this.Debugging) {
            Debug.Log($"Could not find an environment with the identifier: {reaction.RecipientEnvironment}");
          }
          #endif

          #if NEODROID_DEBUG
          if (this.Debugging) {
            Debug.Log($"Applying to all environments");
          }
          #endif

          foreach (var environment in this._Environments.Values) {
            environment.React(reaction);
          }
        }
      }
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public EnvironmentState[] CollectStates() {
      var environments = this._Environments.Values;
      var states = new EnvironmentState[environments.Count];
      var i = 0;
      foreach (var environment in environments) {
        states[i++] = environment.CollectState();
      }

      return states;
    }

    void SetStepping(Reaction reaction) {
      if (reaction.Parameters.Step) {
        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log("Stepping from Reaction");
        }

        #endif

        this._step = true;
      } else {
        if (this.HasStepped) {
          this._step = false;
        }
      }
    }

    void SetStepping(Reaction[] reactions) {
      if (reactions.Any(reac => reac.Parameters.Step)) {
        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log("Stepping from any reactions");
        }

        #endif

        this._step = true;
      } else {
        if(this.HasStepped) {
          this._step = false;
        }
      }
    }

/*
    /// <summary>
    ///
    /// </summary>
    /// <param name="reactions"></param>
    /// <returns></returns>
    public EnvironmentState[] ReactAndCollectStates(Reaction[] reactions) {
      this.SetStepping(reactions);
      var states = new EnvironmentState[reactions.Length * this._Environments.Count];
      var i = 0;
      foreach (var reaction in reactions) {
        if (this._Environments.ContainsKey(reaction.RecipientEnvironment)) {
          states[i++] = this._Environments[reaction.RecipientEnvironment].ReactAndCollectState(reaction);
        } else {
          #if NEODROID_DEBUG
          if (this.Debugging) {
            Debug.Log($"Could not find an environment with the identifier: {reaction.RecipientEnvironment}");
          }
          #endif

          #if NEODROID_DEBUG
          if (this.Debugging) {
            Debug.Log($"Applying to all environments");
          }
          #endif

          foreach (var environment in this._Environments.Values) {
            states[i++] = environment.ReactAndCollectState(reaction);
          }
        }
      }

      return states;
    }
*/
    
    /// <summary>
    ///
    /// </summary>
    public void ResetAllEnvironments() {
      this.React(
          new Reaction(
              new ReactionParameters(true, false, true, episode_count : true),
              null,
              null,
              null,
              null,
              ""));
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public string GetStatus() {
      return this._Message_Server._Listening_For_Clients ? "Connected" : "Not Connected";
    }

    #endregion

    #region Registration

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="environment"></param>
    public void Register(NeodroidEnvironment environment) {
      this.Register(environment, environment.Identifier);
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="environment"></param>
    /// <param name="identifier"></param>
    public void Register(NeodroidEnvironment environment, string identifier) {
      if (!this._Environments.ContainsKey(identifier)) {
        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log($"Manager {this.name} already has an environment with the identifier: {identifier}");
        }
        #endif

        this._Environments.Add(identifier, environment);
      } else {
        Debug.LogWarning(
            $"WARNING! Please check for duplicates, SimulationManager {this.name} already has envi"
            + $"ronment {identifier} registered");
      }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="identifier"></param>
    public void UnRegisterEnvironment(string identifier) {
      if (this._Environments.ContainsKey(identifier)) {
        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log($"SimulationManager {this.name} unregistered enviroment {identifier}");
        }
        #endif

        this._Environments.Remove(identifier);
      }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="neodroid_environment"></param>
    public void UnRegister(NeodroidEnvironment neodroid_environment) {
      this.UnRegisterEnvironment(neodroid_environment.Identifier);
    }

    #endregion

    #region MessageServerCallbacks

    ///  <summary>
    ///
    ///  </summary>
    /// <param name="reactions"></param>
    void OnReceiveCallback(Reaction[] reactions) {
      lock (this._send_lock) {
        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log($"Received: {reactions.Select(r => r.ToString()).Aggregate((current, next) => $"{current}, {next}")}" );
        }
        #endif

        this.SetReactionsFromExternalSource(reactions);

        this.OnReceiveEvent?.Invoke();
      }
    }

    ///  <summary>
    ///
    ///  </summary>
    /// <param name="reactions"></param>
    protected void SetReactionsFromExternalSource(Reaction[] reactions) {
      lock (this._send_lock) {
        if (reactions != null) {
          if (this.AwaitingReply || !this.HasStepped) {
            #if NEODROID_DEBUG
            if (this.Debugging) {
              Debug.Log($"Got new reaction while not having stepped({!this.HasStepped}) or replied({this.AwaitingReply})" );
            }
            #endif
          }
              

          
          this.CurrentReactions = reactions;
          foreach (var current_reaction in this.CurrentReactions) {
            current_reaction.Parameters.IsExternal = true;
          }

          this.Configuration.StepExecutionPhase = this.CurrentReactions[0].Parameters.Phase;
          this.AwaitingReply = true;
          this.HasStepped = false;
          
        } else {
          Debug.LogWarning("Reaction was null");
        }
      }
    }

    /// <summary>
    ///
    /// </summary>
    void OnDisconnectCallback() {
      #if NEODROID_DEBUG
      if (this.Debugging) {
        Debug.Log("Client disconnected.");
      }
      #endif
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="error"></param>
    void OnDebugCallback(string error) {
      #if NEODROID_DEBUG
      if (this.Debugging) {
        //Debug.Log("DebugCallback: " + error);
      }
      #endif
    }

    /// <summary>
    ///
    /// </summary>
    void OnListeningCallback() {
      #if NEODROID_DEBUG
      if (this.Debugging) {
        Debug.Log("Client connected");
      }
      #endif

      this._Message_Server.StartReceiving(
          this.OnReceiveCallback,
          this.OnDisconnectCallback,
          this.OnDebugCallback);
    }

    #endregion

    #region Deconstruction

    /// <summary>
    ///
    /// </summary>
    void OnApplicationQuit() { this._Message_Server.CleanUp(); }

    /// <summary>
    ///
    /// </summary>
    void OnDestroy() { this._Message_Server.Destroy(); }

    #endregion
  }
}
