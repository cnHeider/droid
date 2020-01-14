using UnityEngine;

namespace droid.Runtime.Utilities.Extensions {
  /// <summary>
  ///
  /// </summary>
  public static partial class NeodroidUtilities {
    /// <summary>
    ///
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector3 Divide(this Vector3 a, Vector3 b) {
      return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector3 Multiply(this Vector3 a, Vector3 b) {
      return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    /// <summary>
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="min_point"></param>
    /// <param name="max_point"></param>
    /// <returns></returns>
    public static Vector3 Clamp(this ref Vector3 vec, Vector3 min_point, Vector3 max_point) {
      vec.x = Mathf.Clamp(value : vec.x, min : min_point.x, max : max_point.x);
      vec.y = Mathf.Clamp(value : vec.y, min : min_point.y, max : max_point.y);
      vec.z = Mathf.Clamp(value : vec.z, min : min_point.z, max : max_point.z);
      return vec;
    }
  }
}
