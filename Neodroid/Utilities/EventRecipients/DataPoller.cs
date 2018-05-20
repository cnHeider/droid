﻿using UnityEngine;
using UnityEngine.Events;

namespace droid.Neodroid.Utilities.EventRecipients {
  namespace droid.Neodroid.Utilities.Unsorted {
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public abstract class DataPoller: MonoBehaviour {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="data"></param>
      public abstract void PollData(dynamic data);
      
      
      [SerializeField] UnityEvent _poll_event;
      
      // Update is called once per frame
      /// <summary>
      /// 
      /// </summary>
      void Update() {
          this._poll_event?.Invoke();
      }
    }
  }

}
