﻿#if UNITY_EDITOR
using droid.Runtime.Environments;
using droid.Runtime.Managers;
using droid.Runtime.Prototyping.Evaluation;
using droid.Runtime.Utilities.EventRecipients;
using droid.Runtime.Utilities.EventRecipients.droid.Neodroid.Utilities.Unsorted;
using JetBrains.Annotations;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace droid.Runtime.Utilities.StatusDisplayer {
  /// <inheritdoc />
  /// <summary>
  /// </summary>
  [ExecuteInEditMode]
  public class AutoSetupStatusDisplayer : MonoBehaviour {
    [SerializeField] bool _clean_empty_no_target_events = true;

    [CanBeNull] [SerializeField] NeodroidEnvironment _environment;
    [CanBeNull] [SerializeField] TextUpdater _environment_frame;
    [CanBeNull] [SerializeField] TextUpdater _environment_obs;

    [CanBeNull] [SerializeField] TextUpdater _environment_text;
    [CanBeNull] [SerializeField] ObjectiveFunction _evaluation_function;
    [CanBeNull] [SerializeField] NeodroidManager _manager;
    [CanBeNull] [SerializeField] Button _reset_button;
    [CanBeNull] [SerializeField] TextUpdater _signal;
    [CanBeNull] [SerializeField] TextUpdater _status_text = null;
    [CanBeNull] [SerializeField] ToggleUpdater _terminated;
    [CanBeNull] [SerializeField] Toggle _testing_toggle;
    [SerializeField] UnityEventCallState _unity_event_call_state = UnityEventCallState.RuntimeOnly;

#if NEODROID_DEBUG
    bool Debugging { get { return this._debugging; } set { this._debugging = value; } }
        [SerializeField] bool _debugging;
#endif

    void TryRegister(DataPoller poller, UnityAction<DataPoller> f) {
      if (poller) {
        var count = poller.PollEvent.GetPersistentEventCount();
        if (this._clean_empty_no_target_events && count > 0) {
          //poller.PollEvent.RemoveAllListeners(); // Only non-persistant listeners.
          for (var i = 0; i < count; i++) {
            if (poller.PollEvent.GetPersistentTarget(i) == null
                || poller.PollEvent.GetPersistentMethodName(i) == null) {
              UnityEventTools.RemovePersistentListener(poller.PollEvent, i);
            }
          }
        }

        count = poller.PollEvent.GetPersistentEventCount();
        if (count == 0) {
          UnityEventTools.AddObjectPersistentListener(poller.PollEvent, f, poller);
          poller.PollEvent.SetPersistentListenerState(0, this._unity_event_call_state);
        } else if (count > 0 && poller.PollEvent.GetPersistentTarget(0) != poller) {
#if NEODROID_DEBUG
          if (this.Debugging) {
            Debug.Log($"PollEvent on {poller} already has a listeners");
          }
#endif
        }
      }
    }

    void TryRegisterVoid(UnityEventBase poller, UnityAction f) {
      var count = poller.GetPersistentEventCount();
      if (this._clean_empty_no_target_events && count > 0) {
        //poller.PollEvent.RemoveAllListeners(); // Only non-persistant listeners.
        for (var i = 0; i < count; i++) {
          if (poller.GetPersistentTarget(i) == null || poller.GetPersistentMethodName(i) == null) {
            UnityEventTools.RemovePersistentListener(poller, i);
          }
        }
      }

      count = poller.GetPersistentEventCount();
      if (count == 0) {
        UnityEventTools.AddVoidPersistentListener(poller, f);
        poller.SetPersistentListenerState(0, this._unity_event_call_state);
      } else if (count > 0) {
#if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log($"PollEvent on {poller} already has a listeners");
        }
#endif
      }
    }

    void TryRegisterProperty(Toggle.ToggleEvent poller, UnityAction<bool> f) {
      var count = poller.GetPersistentEventCount();
      if (this._clean_empty_no_target_events && count > 0) {
        //poller.PollEvent.RemoveAllListeners(); // Only non-persistent listeners.
        for (var i = 0; i < count; i++) {
          if (poller.GetPersistentTarget(i) == null || poller.GetPersistentMethodName(i) == null) {
            UnityEventTools.RemovePersistentListener(poller, i);
          }
        }
      }

      count = poller.GetPersistentEventCount();
      if (count == 0) {
        UnityEventTools.AddPersistentListener(poller, f);
        poller.SetPersistentListenerState(0, this._unity_event_call_state);
      } else if (count > 0) {
        #if NEODROID_DEBUG
        if (this.Debugging) {
          Debug.Log($"PollEvent on {poller} already has a listeners");
        }
        #endif
      }
    }

    void Start() {
      if (!this._environment) {
        this._environment = FindObjectOfType<NeodroidEnvironment>();
      }

      var neodroid_environment = this._environment;

      if (neodroid_environment != null) {
        this.TryRegister(this._environment_text, neodroid_environment.IdentifierString);
        this.TryRegister(this._environment_frame, neodroid_environment.FrameString);
        this.TryRegister(this._environment_obs, neodroid_environment.ObservationsString);
        this.TryRegister(this._terminated, neodroid_environment.TerminatedBoolean);
      }

      if (!this._evaluation_function) {
        this._evaluation_function = FindObjectOfType<ObjectiveFunction>();
      }

      var evaluation_function = this._evaluation_function;
      if (evaluation_function != null) {
        this.TryRegister(this._signal, evaluation_function.SignalString);
      }

      if (!this._manager) {
        this._manager = FindObjectOfType<NeodroidManager>();
      }

      if (this._manager) {
        if (this._status_text) {
          this.TryRegister(this._status_text, this._manager.StatusString);
        }

        if (this._testing_toggle) {
          this.TryRegisterProperty(this._testing_toggle.onValueChanged, this._manager.SetTesting);
        }
      }

      if (this._reset_button) {
        this.TryRegisterVoid(this._reset_button.onClick, this._manager.ResetAllEnvironments);
      }
    }
  }
}
#endif
