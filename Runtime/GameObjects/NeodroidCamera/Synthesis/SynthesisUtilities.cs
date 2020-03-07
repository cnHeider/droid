using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace droid.Runtime.GameObjects.NeodroidCamera.Synthesis {
  /// <summary>
  ///
  /// </summary>
  public static class SynthesisUtilities {
    static readonly int _sensitivity = Shader.PropertyToID("_Sensitivity");
    public const string _Shader_Layer_Color_Name = "_LayerColor";
    public const string _Shader_Tag_Color_Name = "_TagColor";
    public const string _Shader_MaterialId_Color_Name = "_MaterialIdColor";
    public const string _Shader_ObjectId_Color_Name = "_ObjectIdColor";
    public const string _Shader_OutputMode_Name = "_OutputMode";

    public static CapturePass[] _Default_Capture_Passes = {
                                                              new CapturePass {
                                                                                  _Name = "_img",
                                                                                  _ReplacementMode =
                                                                                      ReplacementModes.None_
                                                                              },
                                                              new CapturePass {
                                                                                  _Name = "_id",
                                                                                  _SupportsAntialiasing =
                                                                                      false,
                                                                                  _ReplacementMode =
                                                                                      ReplacementModes
                                                                                          .Object_id_
                                                                              },
                                                              new CapturePass {
                                                                                  _Name = "_layer",
                                                                                  _SupportsAntialiasing =
                                                                                      false,
                                                                                  _ReplacementMode =
                                                                                      ReplacementModes
                                                                                          .Layer_id_
                                                                              },
                                                              new CapturePass {
                                                                                  _Name = "_depth",
                                                                                  _ReplacementMode =
                                                                                      ReplacementModes
                                                                                          .Depth_compressed_
                                                                              },
                                                              new CapturePass {
                                                                                  _Name = "_normals",
                                                                                  _ReplacementMode =
                                                                                      ReplacementModes
                                                                                          .Normals_
                                                                              },
                                                              new CapturePass {
                                                                                  _Name = "_mat_id",
                                                                                  _SupportsAntialiasing =
                                                                                      false,
                                                                                  _ReplacementMode =
                                                                                      ReplacementModes
                                                                                          .Material_id_
                                                                              },
                                                              new CapturePass {
                                                                                  _Name = "_tag",
                                                                                  _SupportsAntialiasing =
                                                                                      false,
                                                                                  _ReplacementMode =
                                                                                      ReplacementModes
                                                                                          .Material_id_
                                                                              },
                                                              new CapturePass {
                                                                                  _Name = "_flow",
                                                                                  _SupportsAntialiasing =
                                                                                      false,
                                                                                  _NeedsRescale = true,
                                                                                  _ReplacementMode =
                                                                                      ReplacementModes.Flow_
                                                                              }
                                                          };

    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public struct CapturePass {
      // configuration
      public string _Name;
      public bool _SupportsAntialiasing;
      public bool _NeedsRescale;
      public Camera _Camera;
      public ReplacementModes _ReplacementMode;
    }

    /// <summary>
    ///
    /// </summary>
    public enum ReplacementModes {
      /// <summary>
      ///
      /// </summary>
      Object_id_ = 0,

      /// <summary>
      ///
      /// </summary>
      Material_id_ = 1,

      /// <summary>
      ///
      /// </summary>
      Layer_id_ = 2,

      /// <summary>
      ///
      /// </summary>
      Tag_id_ = 3,

      /// <summary>
      ///
      /// </summary>
      Depth_compressed_ = 4,

      /// <summary>
      ///
      /// </summary>
      Depth_multichannel_ = 5,

      /// <summary>
      ///
      /// </summary>
      Normals_ = 6,

      /// <summary>
      ///
      /// </summary>
      None_ = 7,

      /// <summary>
      ///
      /// </summary>
      Flow_ = 8
    }

    /// <summary>
    ///
    /// </summary>
    public static void SetupCapturePassesFull(Camera camera,
                                              Shader replacement_shader,
                                              Shader optical_flow_shader,
                                              Material optical_flow_material,
                                              float optical_flow_sensitivity,
                                              ref CapturePass[] capture_passes) {
      SetupHiddenCapturePassCameras(camera : camera, capture_passes : ref capture_passes);
      CleanRefreshPassCameras(camera : camera, capture_passes : ref capture_passes);

      // cache materials and setup material properties
      if (!optical_flow_material || optical_flow_material.shader != optical_flow_shader) {
        optical_flow_material = new Material(shader : optical_flow_shader);
      }

      optical_flow_material.SetFloat(nameID : _sensitivity, value : optical_flow_sensitivity);

      // setup command buffers and replacement shaders
      AddReplacementShaderCommandBufferOnCamera(cam : capture_passes[1]._Camera,
                                                shader : replacement_shader,
                                                mode : capture_passes[1]._ReplacementMode);
      AddReplacementShaderCommandBufferOnCamera(cam : capture_passes[2]._Camera,
                                                shader : replacement_shader,
                                                mode : capture_passes[2]._ReplacementMode);
      AddReplacementShaderCommandBufferOnCamera(cam : capture_passes[6]._Camera,
                                                shader : replacement_shader,
                                                mode : capture_passes[6]._ReplacementMode);

      AddReplacementShaderCommandBufferOnCamera(cam : capture_passes[5]._Camera,
                                                shader : replacement_shader,
                                                mode : capture_passes[5]._ReplacementMode);

      AddReplacementShaderCommandBufferOnCamera(camera : capture_passes[3]._Camera,
                                                shader : replacement_shader,
                                                mode : capture_passes[3]._ReplacementMode,
                                                clear_color : Color.white);
      AddReplacementShaderCommandBufferOnCamera(cam : capture_passes[4]._Camera,
                                                shader : replacement_shader,
                                                mode : capture_passes[4]._ReplacementMode);
      SetupCameraWithPostShader(cam : capture_passes[8]._Camera,
                                material : optical_flow_material,
                                depth_texture_mode : DepthTextureMode.Depth | DepthTextureMode.MotionVectors);
    }

    public static void SetupCapturePassesReplacementShader(Camera camera,
                                                           Shader replacement_shader,
                                                           ref CapturePass[] capture_passes) {
      SetupHiddenCapturePassCameras(camera : camera, capture_passes : ref capture_passes);
      CleanRefreshPassCameras(camera : camera, capture_passes : ref capture_passes);

      foreach (var capture_pass in capture_passes) {
        AddReplacementShaderCommandBufferOnCamera(cam : capture_pass._Camera,
                                                  shader : replacement_shader,
                                                  mode : capture_pass._ReplacementMode);
      }
    }

    static void CleanRefreshPassCameras(Camera camera, ref CapturePass[] capture_passes) {
      var target_display = 1;
      foreach (var pass in capture_passes) {
        if (pass._Camera == camera) {
          continue;
        }

        pass._Camera.RemoveAllCommandBuffers(); // cleanup capturing camera
        pass._Camera.CopyFrom(other : camera); // copy all "main" camera parameters into capturing camera
        pass._Camera.targetDisplay =
            target_display++; // set targetDisplay here since it gets overriden by CopyFrom()
      }
    }

    static void AddReplacementShaderCommandBufferOnCamera(Camera cam, Shader shader, ReplacementModes mode) {
      AddReplacementShaderCommandBufferOnCamera(camera : cam,
                                                shader : shader,
                                                mode : mode,
                                                clear_color : Color.black);
    }

    static void AddReplacementShaderCommandBufferOnCamera(Camera camera,
                                                          Shader shader,
                                                          ReplacementModes mode,
                                                          Color clear_color) {
      var cb = new CommandBuffer {name = mode.ToString()};
      cb.SetGlobalInt(name : _Shader_OutputMode_Name, value : (int)mode);
      camera.AddCommandBuffer(evt : CameraEvent.BeforeForwardOpaque, buffer : cb);
      camera.AddCommandBuffer(evt : CameraEvent.BeforeFinalPass, buffer : cb);
      camera.SetReplacementShader(shader : shader, "");
      camera.backgroundColor = clear_color;
      camera.clearFlags = CameraClearFlags.SolidColor;
    }

    static void SetupCameraWithPostShader(Camera cam,
                                          Material material,
                                          DepthTextureMode depth_texture_mode = DepthTextureMode.None) {
      var cb = new CommandBuffer {name = cam.name};
      cb.Blit(null, dest : BuiltinRenderTextureType.CurrentActive, mat : material);
      cam.AddCommandBuffer(evt : CameraEvent.AfterEverything, buffer : cb);
      cam.depthTextureMode = depth_texture_mode;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="capture_passes"></param>
    static void SetupHiddenCapturePassCameras(Camera camera, ref CapturePass[] capture_passes) {
      capture_passes[0]._Camera = camera;
      for (var q = 1; q < capture_passes.Length; q++) {
        capture_passes[q]._Camera =
            CreateHiddenCamera(cam_name : capture_passes[q]._Name, parent : camera.transform);
      }
    }

    static Camera CreateHiddenCamera(string cam_name, Transform parent) {
      var go = new GameObject(name : cam_name, typeof(Camera)) {hideFlags = HideFlags.HideAndDontSave};
      go.transform.parent = parent;

      var new_camera = go.GetComponent<Camera>();
      return new_camera;
    }
  }
}
