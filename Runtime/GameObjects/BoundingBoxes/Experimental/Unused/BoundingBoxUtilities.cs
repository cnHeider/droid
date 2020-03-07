using UnityEngine;

namespace droid.Runtime.GameObjects.BoundingBoxes.Experimental.Unused {
  public static class BoundingBoxUtilities {
    /// <summary>
    ///
    /// </summary>
    /// <param name="p"></param>
    /// <param name="r"></param>
    /// <param name="c"></param>
    public static void DrawBoxFromCenter(Vector3 p, float r, Color c) {
      // p is pos.yition of the center, r is "radius" and c is the color of the box
      //Bottom lines
      Debug.DrawLine(start : new Vector3(x : -r + p.x, y : -r + p.y, z : -r + p.z),
                     end : new Vector3(x : r + p.x, y : -r + p.y, z : -r + p.z),
                     color : c);
      Debug.DrawLine(start : new Vector3(x : -r + p.x, y : -r + p.y, z : -r + p.z),
                     end : new Vector3(x : -r + p.x, y : -r + p.y, z : r + p.z),
                     color : c);
      Debug.DrawLine(start : new Vector3(x : r + p.x, y : -r + p.y, z : r + p.z),
                     end : new Vector3(x : -r + p.x, y : -r + p.y, z : r + p.z),
                     color : c);
      Debug.DrawLine(start : new Vector3(x : r + p.x, y : -r + p.y, z : r + p.z),
                     end : new Vector3(x : r + p.x, y : -r + p.y, z : -r + p.z),
                     color : c);

      //Vertical lines
      Debug.DrawLine(start : new Vector3(x : -r + p.x, y : r + p.y, z : -r + p.z),
                     end : new Vector3(x : r + p.x, y : r + p.y, z : -r + p.z),
                     color : c);
      Debug.DrawLine(start : new Vector3(x : -r + p.x, y : r + p.y, z : -r + p.z),
                     end : new Vector3(x : -r + p.x, y : r + p.y, z : r + p.z),
                     color : c);
      Debug.DrawLine(start : new Vector3(x : r + p.x, y : r + p.y, z : r + p.z),
                     end : new Vector3(x : -r + p.x, y : r + p.y, z : r + p.z),
                     color : c);
      Debug.DrawLine(start : new Vector3(x : r + p.x, y : r + p.y, z : r + p.z),
                     end : new Vector3(x : r + p.x, y : r + p.y, z : -r + p.z),
                     color : c);

      //Top lines
      Debug.DrawLine(start : new Vector3(x : -r + p.x, y : -r + p.y, z : -r + p.z),
                     end : new Vector3(x : -r + p.x, y : r + p.y, z : -r + p.z),
                     color : c);
      Debug.DrawLine(start : new Vector3(x : -r + p.x, y : -r + p.y, z : r + p.z),
                     end : new Vector3(x : -r + p.x, y : r + p.y, z : r + p.z),
                     color : c);
      Debug.DrawLine(start : new Vector3(x : r + p.x, y : -r + p.y, z : -r + p.z),
                     end : new Vector3(x : r + p.x, y : r + p.y, z : -r + p.z),
                     color : c);
      Debug.DrawLine(start : new Vector3(x : r + p.x, y : -r + p.y, z : r + p.z),
                     end : new Vector3(x : r + p.x, y : r + p.y, z : r + p.z),
                     color : c);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="x_size"></param>
    /// <param name="y_size"></param>
    /// <param name="z_size"></param>
    /// <param name="pos"></param>
    /// <param name="color"></param>
    public static void DrawRect(float x_size, float y_size, float z_size, Vector3 pos, Color color) {
      var x = x_size / 2;
      var y = y_size / 2;
      var z = z_size / 2;

      //Vertical lines
      Debug.DrawLine(start : new Vector3(x : -x + pos.x, y : -y + pos.y, z : -z + pos.z),
                     end : new Vector3(x : -x + pos.x, y : y + pos.y, z : -z + pos.z),
                     color : color);
      Debug.DrawLine(start : new Vector3(x : x + pos.x, y : -y + pos.y, z : -z + pos.z),
                     end : new Vector3(x : x + pos.x, y : y + pos.y, z : -z + pos.z),
                     color : color);
      Debug.DrawLine(start : new Vector3(x : -x + pos.x, y : -y + pos.y, z : z + pos.z),
                     end : new Vector3(x : -x + pos.x, y : y + pos.y, z : z + pos.z),
                     color : color);
      Debug.DrawLine(start : new Vector3(x : x + pos.x, y : -y + pos.y, z : z + pos.z),
                     end : new Vector3(x : x + pos.x, y : y + pos.y, z : z + pos.z),
                     color : color);

      //Horizontal top
      Debug.DrawLine(start : new Vector3(x : -x + pos.x, y : y + pos.y, z : -z + pos.z),
                     end : new Vector3(x : x + pos.x, y : y + pos.y, z : -z + pos.z),
                     color : color);
      Debug.DrawLine(start : new Vector3(x : -x + pos.x, y : y + pos.y, z : z + pos.z),
                     end : new Vector3(x : x + pos.x, y : y + pos.y, z : z + pos.z),
                     color : color);
      Debug.DrawLine(start : new Vector3(x : -x + pos.x, y : y + pos.y, z : -z + pos.z),
                     end : new Vector3(x : -x + pos.x, y : y + pos.y, z : z + pos.z),
                     color : color);
      Debug.DrawLine(start : new Vector3(x : x + pos.x, y : y + pos.y, z : -z + pos.z),
                     end : new Vector3(x : x + pos.x, y : y + pos.y, z : z + pos.z),
                     color : color);

      //Horizontal bottom
      Debug.DrawLine(start : new Vector3(x : -x + pos.x, y : -y + pos.y, z : -z + pos.z),
                     end : new Vector3(x : x + pos.x, y : -y + pos.y, z : -z + pos.z),
                     color : color);
      Debug.DrawLine(start : new Vector3(x : -x + pos.x, y : -y + pos.y, z : z + pos.z),
                     end : new Vector3(x : x + pos.x, y : -y + pos.y, z : z + pos.z),
                     color : color);
      Debug.DrawLine(start : new Vector3(x : -x + pos.x, y : -y + pos.y, z : -z + pos.z),
                     end : new Vector3(x : -x + pos.x, y : -y + pos.y, z : z + pos.z),
                     color : color);
      Debug.DrawLine(start : new Vector3(x : x + pos.x, y : -y + pos.y, z : -z + pos.z),
                     end : new Vector3(x : x + pos.x, y : -y + pos.y, z : z + pos.z),
                     color : color);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="old_transforms"></param>
    /// <param name="newly_acquired_transforms"></param>
    /// <returns></returns>
    public static bool DidTransformsChange(
        Transform[] old_transforms,
        Transform[] newly_acquired_transforms) {
      if (old_transforms.Length != newly_acquired_transforms.Length) {
        return true;
      }

      var i = 0;
      for (var index = 0; index < old_transforms.Length; index++) {
        var old = old_transforms[index];
        if (old.position != newly_acquired_transforms[i].position
            || old.rotation != newly_acquired_transforms[i].rotation) {
          return true;
        }

        i++;
      }

      return false;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="object_transform"></param>
    /// <returns></returns>
    public static Bounds GetTotalMeshFilterBounds(Transform object_transform) {
      var mesh_filter = object_transform.GetComponent<MeshFilter>();

      var result = mesh_filter != null ? mesh_filter.mesh.bounds : new Bounds();

      foreach (Transform transform in object_transform) {
        var bounds = GetTotalMeshFilterBounds(object_transform : transform);
        result.Encapsulate(point : bounds.min);
        result.Encapsulate(point : bounds.max);
      }

      /*var bounds1 = GetTotalColliderBounds(objectTransform);
      result.Encapsulate(bounds1.min);
      result.Encapsulate(bounds1.max);
      */
      /*
            foreach (Transform transform in objectTransform) {
              var bounds = GetTotalColliderBounds(transform);
              result.Encapsulate(bounds.min);
              result.Encapsulate(bounds.max);
            }
            */
      var scaled_min = result.min;
      var local_scale = object_transform.localScale;
      scaled_min.Scale(scale : local_scale);
      result.min = scaled_min;
      var scaled_max = result.max;
      scaled_max.Scale(scale : local_scale);
      result.max = scaled_max;
      return result;
    }

    /// <summary>
    /// </summary>
    /// <param name="object_transform"></param>
    /// <returns></returns>
    public static Bounds GetTotalColliderBounds(Transform object_transform) {
      var mesh_filter = object_transform.GetComponent<Collider>();

      var result = mesh_filter != null ? mesh_filter.bounds : new Bounds();

      foreach (Transform transform in object_transform) {
        var bounds = GetTotalColliderBounds(object_transform : transform);
        result.Encapsulate(point : bounds.min);
        result.Encapsulate(point : bounds.max);
      }

      var scaled_min = result.min;
      var local_scale = object_transform.localScale;
      scaled_min.Scale(scale : local_scale);
      result.min = scaled_min;
      var scaled_max = result.max;
      scaled_max.Scale(scale : local_scale);
      result.max = scaled_max;
      return result;
    }

    /// <summary>
    /// </summary>
    /// <param name="g"></param>
    /// <returns></returns>
    public static Bounds GetMaxBounds(GameObject g) {
      var b = new Bounds(center : g.transform.position, size : Vector3.zero);
      foreach (var r in g.GetComponentsInChildren<Renderer>()) {
        b.Encapsulate(bounds : r.bounds);
      }

      return b;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="bounds"></param>
    /// <param name="cam"></param>
    /// <param name="margin"></param>
    /// <returns></returns>
    public static Rect GetBoundsScreenRectEncapsulationSlow(this Bounds bounds,
                                                            Camera cam,
                                                            float margin = 0) {
      var rect = new Rect();

      var points = new Vector3[8];
      var screen_pos = new Vector3[8];

      var b = bounds; // reference object ex Simple
      points[0] = new Vector3(x : b.min.x, y : b.min.y, z : b.min.z);
      points[1] = new Vector3(x : b.max.x, y : b.min.y, z : b.min.z);
      points[2] = new Vector3(x : b.max.x, y : b.max.y, z : b.min.z);
      points[3] = new Vector3(x : b.min.x, y : b.max.y, z : b.min.z);
      points[4] = new Vector3(x : b.min.x, y : b.min.y, z : b.max.z);
      points[5] = new Vector3(x : b.max.x, y : b.min.y, z : b.max.z);
      points[6] = new Vector3(x : b.max.x, y : b.max.y, z : b.max.z);
      points[7] = new Vector3(x : b.min.x, y : b.max.y, z : b.max.z);

      var screen_bounds = new Bounds();
      for (var i = 0; i < 8; i++) {
        screen_pos[i] = cam.WorldToScreenPoint(position : points[i]);

        if (i == 0) {
          screen_bounds = new Bounds(center : screen_pos[0], size : Vector3.zero);
        }

        screen_bounds.Encapsulate(point : screen_pos[i]);
      }

      //Debug.Log(screen_bounds.ToString());

      rect.xMin = screen_bounds.min.x;
      rect.yMin = screen_bounds.min.y;
      rect.xMax = screen_bounds.max.x;
      rect.yMax = screen_bounds.max.y;

      return rect;
    }

    /*
    /// <summary>
    ///
    /// </summary>
    /// <param name="bb"></param>
    /// <param name="cam"></param>
    /// <param name="margin"></param>
    /// <returns></returns>
    public static Rect GetBoundingBoxScreenRect(this BoundingBox bb, Camera cam, Single margin = 0) {
      var min = Vector2.zero;

      if (bb != null && bb.Points?.Length > 0) {
        if (bb._use_bb_transform && bb._bb_transform) {
          min = cam.WorldToScreenPoint(bb._bb_transform.TransformPoint(bb.Points[0]));
        } else {
          min = cam.WorldToScreenPoint(bb.Points[0]);
        }
      }

      var max = min;

      var point = min;
      GetMinMax(point, ref min, ref max);

      if (bb != null) {
        for (var i = 1; i < bb.Points?.Length; i++) {
          if (bb._use_bb_transform && bb._bb_transform) {
            point = cam.WorldToScreenPoint(bb._bb_transform.TransformPoint(bb.Points[i]));
          } else {
            point = cam.WorldToScreenPoint(bb.Points[i]);
          }

          GetMinMax(point, ref min, ref max);
        }
      }

      var r = Rect.MinMaxRect(min.x, min.y, max.x, max.y);
      r.xMin -= margin;
      r.xMax += margin;
      r.yMin -= margin;
      r.yMax += margin;

      return r;
    }
    */

    /// <summary>
    ///
    /// </summary>
    /// <param name="a_cam"></param>
    /// <param name="a_area"></param>
    /// <param name="a_limits"></param>
    /// <param name="a_max_height"></param>
    public static void CalculateLimits(Camera a_cam,
                                       Bounds a_area,
                                       out Rect a_limits,
                                       out float a_max_height) {
      // Half the FOV angle in radians
      var angle = a_cam.fieldOfView * Mathf.Deg2Rad * 0.5f;

      // half the size of the viewing frustum at a distance of "1" from the camera
      var tan = Vector2.one * Mathf.Tan(f : angle);
      tan.x *= a_cam.aspect;

      // the center point of the area and it's extents
      // the center point is taken from the bottom center of the bounding box
      var dim = a_area.extents;
      var center = a_area.center - new Vector3(0, y : a_area.extents.y, 0);

      // the maximum distance the camera can be above the area plane for each direction
      var max_dist = new Vector2(x : dim.x / tan.x, y : dim.z / tan.y);

      // actual distance of the camera above our plane
      var dist = a_cam.transform.position.y - center.y;

      // the max movement range around the center of the plane
      dim.x *= 1f - dist / max_dist.x;
      dim.z *= 1f - dist / max_dist.y;

      // maximum world space y coordinate the camera can be moved to
      a_max_height = center.y + Mathf.Min(a : max_dist.x, b : max_dist.y);

      // the min and max x and z coordinates the camera can be at the current distance.
      a_limits = new Rect(x : center.x - dim.x,
                          y : center.z - dim.z,
                          width : dim.x * 2,
                          height : dim.z * 2);
    }

    public static bool CullToFrustum(Mesh mesh, Camera cam, Transform trans, bool update_position) {
      var fov = cam.fieldOfView;
      cam.fieldOfView = fov * 0.97f;
      var planes = GeometryUtility.CalculateFrustumPlanes(camera : cam);
      cam.fieldOfView = fov;
      if (GeometryUtility.TestPlanesAABB(planes : planes, bounds : mesh.bounds)) {
        return true;
      }

      Debug.Log(message : "Culling :" + trans.name);
      return false;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="bounds"></param>
    /// <param name="t"></param>
    /// <param name="cam"></param>
    /// <param name="margin"></param>
    /// <returns></returns>
    public static Rect GetMinMaxRect(this Bounds bounds, Transform t, Camera cam, float margin = 0) {
      var cen = bounds.center;
      var ext = bounds.extents;

      var x_min = cen.x - ext.x;
      var y_min = cen.y - ext.y;
      var z_min = cen.z - ext.z;
      var x_max = cen.x + ext.x;
      var y_max = cen.y + ext.y;
      var z_max = cen.z + ext.z;

      Vector2 min = cam.WorldToScreenPoint(position : new Vector3(x : x_min, y : y_min, z : z_min));
      var max = min;

      var point = min;
      point.GetMinMax(min : ref min, max : ref max);

      point = cam.WorldToScreenPoint(position : new Vector3(x : x_max, y : y_max, z : z_max));
      point.GetMinMax(min : ref min, max : ref max);

      point = cam.WorldToScreenPoint(position : new Vector3(x : x_max, y : y_min, z : z_min));
      point.GetMinMax(min : ref min, max : ref max);

      point = cam.WorldToScreenPoint(position : new Vector3(x : x_min, y : y_max, z : z_min));
      point.GetMinMax(min : ref min, max : ref max);

      point = cam.WorldToScreenPoint(position : new Vector3(x : x_min, y : y_min, z : z_max));
      point.GetMinMax(min : ref min, max : ref max);

      point = cam.WorldToScreenPoint(position : new Vector3(x : x_max, y : y_min, z : z_max));
      point.GetMinMax(min : ref min, max : ref max);

      point = cam.WorldToScreenPoint(position : new Vector3(x : x_max, y : y_max, z : z_min));
      point.GetMinMax(min : ref min, max : ref max);

      point = cam.WorldToScreenPoint(position : new Vector3(x : x_min, y : y_max, z : z_max));
      point.GetMinMax(min : ref min, max : ref max);

      var r = Rect.MinMaxRect(xmin : min.x,
                              ymin : min.y,
                              xmax : max.x,
                              ymax : max.y);
      r.xMin -= margin;
      r.xMax += margin;
      r.yMin -= margin;
      r.yMax += margin;

      return r;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="vec"></param>
    /// <returns></returns>
    public static float MaxDim(this Vector3 vec) { return Mathf.Max(vec.x, vec.y, vec.z); }

    /// <summary>
    ///
    /// </summary>
    /// <param name="vec"></param>
    /// <returns></returns>
    public static float MinDim(this Vector3 vec) { return Mathf.Min(vec.x, vec.y, vec.z); }

    /// <summary>
    ///
    /// </summary>
    /// <param name="mesh"></param>
    /// <param name="t"></param>
    /// <param name="cam"></param>
    /// <returns></returns>
    public static Vector3[] GetMinMaxPoints(this MeshCollider mesh, Transform t, Camera cam) {
      return mesh.sharedMesh.GetCameraMinMaxPoints(t : t, cam : cam);
    }
  }
}
