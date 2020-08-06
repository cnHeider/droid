﻿using System;
using System.Linq;
using droid.Runtime.GameObjects.NeodroidCamera.Synthesis;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Object = UnityEngine.Object;

namespace droid.Runtime.GameObjects.NeodroidCamera.Experimental {
  /// <inheritdoc />
  /// <summary>
  /// </summary>
  [ExecuteInEditMode]
  public class MultiPassCamera : MonoBehaviour {
    /// <summary>
    /// </summary>
    Renderer[] _all_renders = null;

    /// <summary>
    /// </summary>
    MaterialPropertyBlock _block = null;

    [SerializeField] RenderTexture depthRenderTexture = null;
    [SerializeField] RenderTexture objectIdRenderTexture = null;
    [SerializeField] RenderTexture tagIdRenderTexture = null;
    [SerializeField] RenderTexture flowRenderTexture = null;

    /// <summary>
    /// </summary>
    void Start() { this.Setup(); }

    void Awake() {
      //this._asf= new TextureFlipper();
    }

    void CheckBlock() {
      if (this._block == null) {
        this._block = new MaterialPropertyBlock();
      }
    }

    [SerializeField] CapturePassMaterial[] _capture_passes;

    [SerializeField] Camera _camera;
    [SerializeField] bool debug = true;
    [SerializeField] bool always_re = true;
    [SerializeField] Mesh m_quad;
    [SerializeField] GUISkin gui_style = null;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static Mesh CreateFullscreenQuad() {
      var r = new Mesh {
                           vertices = new[] {
                                                new Vector3(1.0f, 1.0f, 0.0f),
                                                new Vector3(-1.0f, 1.0f, 0.0f),
                                                new Vector3(-1.0f, -1.0f, 0.0f),
                                                new Vector3(1.0f, -1.0f, 0.0f)
                                            },
                           triangles = new[] {
                                                 0,
                                                 1,
                                                 2,
                                                 2,
                                                 3,
                                                 0
                                             }
                       };
      r.UploadMeshData(true);
      return r;
    }

    /// <summary>
    /// </summary>
    void Setup() {
      if (!this.gui_style) {
        this.gui_style = Resources.FindObjectsOfTypeAll<GUISkin>().First(a => a.name == "BoundingBox");
      }

      this._all_renders = FindObjectsOfType<Renderer>();
      if (this._capture_passes == null || this._capture_passes.Length == 0 || this.always_re) {
        this._capture_passes = new[] {
                                         new CapturePassMaterial(when : CameraEvent.AfterDepthTexture,
                                                                 source : BuiltinRenderTextureType.Depth) {
                                                                                                              _SupportsAntialiasing
                                                                                                                  = false,
                                                                                                              _RenderTexture
                                                                                                                  = this
                                                                                                                      .depthRenderTexture
                                                                                                          },
                                         new CapturePassMaterial(when : CameraEvent.AfterForwardAlpha,
                                                                 source : BuiltinRenderTextureType
                                                                     .MotionVectors) {
                                                                                         _SupportsAntialiasing
                                                                                             = false,
                                                                                         _RenderTexture =
                                                                                             this
                                                                                                 .flowRenderTexture
                                                                                     },
                                         new CapturePassMaterial(when : CameraEvent.AfterForwardAlpha,
                                                                 source : BuiltinRenderTextureType.None) {
                                                                                                             _SupportsAntialiasing
                                                                                                                 = false,
                                                                                                             _RenderTexture
                                                                                                                 = this
                                                                                                                     .objectIdRenderTexture,
                                                                                                             _TextureId
                                                                                                                 = Shader
                                                                                                                     .PropertyToID("_TmpFrameBuffer")
                                                                                                         },
                                         new CapturePassMaterial(when : CameraEvent.AfterDepthTexture,
                                                                 source : BuiltinRenderTextureType.None) {
                                                                                                             _SupportsAntialiasing
                                                                                                                 = false,
                                                                                                             _RenderTexture
                                                                                                                 = this
                                                                                                                     .tagIdRenderTexture,
                                                                                                             _TextureId
                                                                                                                 = Shader
                                                                                                                     .PropertyToID("_CameraDepthTexture")
                                                                                                         }
                                     };
      }

      if (this.m_quad == null) {
        this.m_quad = CreateFullscreenQuad();
      }

      this._camera = this.GetComponent<Camera>();
      //this._camera.SetReplacementShader(this.uberMaterial.shader,"");

      this._camera.RemoveAllCommandBuffers(); // cleanup capturing camera

      this._camera.depthTextureMode = DepthTextureMode.Depth | DepthTextureMode.MotionVectors;

      foreach (var capture_pass in this._capture_passes) {
        var cb = new CommandBuffer {name = capture_pass.Source.ToString()};

        cb.Clear();

        if (capture_pass._Material) {
          cb.GetTemporaryRT(nameID : capture_pass._TextureId,
                            -1,
                            -1,
                            0,
                            filter : FilterMode.Point);
          //cb.Blit(capture_pass.Source, capture_pass._RenderTexture, capture_pass._Material);
          cb.Blit(source : capture_pass.Source, dest : capture_pass._TextureId);
          cb.SetRenderTarget(colors : new RenderTargetIdentifier[] {capture_pass._RenderTexture},
                             depth : capture_pass._RenderTexture);
          cb.DrawMesh(mesh : this.m_quad,
                      matrix : Matrix4x4.identity,
                      material : capture_pass._Material,
                      0,
                      0);
          cb.ReleaseTemporaryRT(nameID : capture_pass._TextureId);
        } else {
          cb.Blit(source : capture_pass.Source, dest : capture_pass._RenderTexture);
        }

        this._camera.AddCommandBuffer(evt : capture_pass.When, buffer : cb);
      }

      this.CheckBlock();
      foreach (var r in this._all_renders) {
        r.GetPropertyBlock(properties : this._block);
        var sm = r.sharedMaterial;
        if (sm) {
          var id = sm.GetInstanceID();
          var color = ColorEncoding.EncodeIdAsColor(instance_id : id);

          this._block.SetColor(name : SynthesisUtilities._Shader_MaterialId_Color_Name, value : color);
          r.SetPropertyBlock(properties : this._block);
        }
      }
    }

    const int _size = 100;
    const int _margin = 20;

    void OnGUI() {
      if (this.debug) {
        var index = 0;

        foreach (var pass in this._capture_passes) {
          var xi = (_size + _margin) * index++;
          var x = xi % (Screen.width - _size);
          var y = (_size + _margin) * (xi / (Screen.width - _size));
          var r = new Rect(x : _margin + x,
                           y : _margin + y,
                           width : _size,
                           height : _size);
          //this._asf?.Flip(pass._RenderTexture);

          GUI.DrawTexture(position : r, image : pass._RenderTexture, scaleMode : ScaleMode.ScaleToFit);
          GUI.TextField(position : r, text : pass.Source.ToString(), style : this.gui_style.box);
        }
      }
    }

    TextureFlipper _asf;
  }

  /// <summary>
  ///
  /// </summary>
  [Serializable]
  public struct CapturePassMaterial {
    public bool _SupportsAntialiasing;
    public bool _NeedsRescale;
    public Material _Material;
    public RenderTexture _RenderTexture;
    public CameraEvent When;
    public BuiltinRenderTextureType Source;
    public int _TextureId;

    public CapturePassMaterial(CameraEvent when = CameraEvent.AfterEverything,
                               BuiltinRenderTextureType source = BuiltinRenderTextureType.CurrentActive) {
      this.When = when;
      this.Source = source;
      this._Material = null;
      this._RenderTexture = null;
      this._SupportsAntialiasing = false;
      this._NeedsRescale = false;
      this._TextureId = 0;
    }
  }

  public class TextureFlipper : IDisposable {
    Shader _m_sh_v_flip;
    Material _m_vf_lip_material;
    RenderTexture _m_work_texture;

    public TextureFlipper() {
      this._m_sh_v_flip = Shader.Find("Neodroid/Experimental/VerticalFlipper");
      if (this._m_sh_v_flip) {
        this._m_vf_lip_material = new Material(shader : this._m_sh_v_flip);
      }
    }

    public void Flip(RenderTexture target) {
      if (this._m_work_texture == null
          || this._m_work_texture.width != target.width
          || this._m_work_texture.height != target.height) {
        UnityHelpers.Destroy(obj : this._m_work_texture);
        this._m_work_texture = new RenderTexture(width : target.width,
                                                 height : target.height,
                                                 depth : target.depth,
                                                 format : target.format,
                                                 readWrite : RenderTextureReadWrite.Linear);
      }

      if (this._m_vf_lip_material) {
        Graphics.Blit(source : target, dest : this._m_work_texture, mat : this._m_vf_lip_material);
        Graphics.Blit(source : this._m_work_texture, dest : target);
      }
    }

    public void Dispose() {
      UnityHelpers.Destroy(obj : this._m_work_texture);
      this._m_work_texture = null;
      if (this._m_vf_lip_material) {
        UnityHelpers.Destroy(obj : this._m_vf_lip_material);
        this._m_vf_lip_material = null;
      }
    }
  }

  /// <summary>
  /// What is this:
  /// Motivation  :
  /// Notes:
  /// </summary>
  public static class UnityHelpers {
    public static void Destroy(Object obj, bool allow_destroying_assets = false) {
      if (obj == null) {
        return;
      }
      #if UNITY_EDITOR
      if (EditorApplication.isPlaying) {
        Object.Destroy(obj : obj);
      } else {
        Object.DestroyImmediate(obj : obj, allowDestroyingAssets : allow_destroying_assets);
      }
      #else
            Object.Destroy(obj);
      #endif
      obj = null;
    }

    public static bool IsPlaying() {
      #if UNITY_EDITOR
      return EditorApplication.isPlaying;
      #else
            return true;
      #endif
    }
  }
}
