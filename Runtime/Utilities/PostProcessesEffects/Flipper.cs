﻿
using UnityEngine;
#if UNITY_POST_PROCESSING_STACK_V2
using System;
using UnityEngine.Rendering.PostProcessing;

namespace droid.Runtime.Utilities.PostProcessesEffects {
  /// <summary>
  ///
  /// </summary>
  [Serializable]
  [PostProcess(typeof(FlipperRenderer),
      eventType : PostProcessEvent.AfterStack,
      "Neodroid/Flip")]
  public sealed class Flipper : PostProcessEffectSettings {
    /// <summary>
    ///
    /// </summary>
    public BoolParameter flip_x = new BoolParameter {value = false};

    /// <summary>
    ///
    /// </summary>
    public BoolParameter flip_y = new BoolParameter {value = false};
  }

  public sealed class FlipperRenderer : PostProcessEffectRenderer<Flipper> {
    static readonly Int32 _flip_x = Shader.PropertyToID("_Flip_x");
    static readonly Int32 _flip_y = Shader.PropertyToID("_Flip_y");
    static readonly Shader _s = Shader.Find("Neodroid/PostProcessing/Flip");

    /// <summary>
    ///
    /// </summary>
    /// <param name="context"></param>
    public override void Render(PostProcessRenderContext context) {
      var sheet = context.propertySheets.Get(shader : _s);
      sheet.properties.SetFloat(nameID : _flip_x, this.settings.flip_x ? -1.0f : 1.0f);
      sheet.properties.SetFloat(nameID : _flip_y, this.settings.flip_y ? -1.0f : 1.0f);
      context.command.BlitFullscreenTriangle(source : context.source,
                                             destination : context.destination,
                                             propertySheet : sheet,
                                             0);
    }
  }
}
#endif
