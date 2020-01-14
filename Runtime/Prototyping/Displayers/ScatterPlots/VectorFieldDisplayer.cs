using System;
using droid.Runtime.Structs;
using droid.Runtime.Utilities.Drawing;
using UnityEngine;

namespace droid.Runtime.Prototyping.Displayers.ScatterPlots {
  /// <inheritdoc />
  /// <summary>
  /// </summary>
  [ExecuteInEditMode]
  [AddComponentMenu(DisplayerComponentMenuPath._ComponentMenuPath
                    + "VectorField"
                    + DisplayerComponentMenuPath._Postfix)]
  public class VectorFieldDisplayer : Displayer {
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public override void Setup() { }

    public override void Display(Double value) { }

    public override void Display(float[] values) { }

    public override void Display(String values) { }

    public override void Display(Vector3 value) { throw new NotImplementedException(); }
    public override void Display(Vector3[] value) { this.ScatterPlot(points : value); }

    public override void Display(Points.ValuePoint points) { this.PlotSeries(new[] {points}); }

    public override void Display(Points.ValuePoint[] points) { }

    public override void Display(Points.StringPoint point) { throw new NotImplementedException(); }
    public override void Display(Points.StringPoint[] points) { throw new NotImplementedException(); }

    //public override void Display(Object o) { throw new NotImplementedException(); }
    public override void Display(float values) { }

    void Update() {
      if (this._RetainLastPlot) {
        if (this._Values != null) {
          PlotSeries(points : this._Values);
        }
      }
    }

    /// <summary>
    /// </summary>
    /// <param name="points"></param>
    public void ScatterPlot(Vector3[] points) { }

    /*public override void PlotSeries(float[] points) {

    }*/

    /// <summary>
    /// </summary>
    /// <param name="points"></param>
    public override void PlotSeries(Points.ValuePoint[] points) {
      #if NEODROID_DEBUG
      if (this.Debugging) {
        Debug.Log("Plotting value points");
      }
      #endif

      this._Values = points;

      for (var index = 0; index < points.Length; index++) {
        var point = points[index];
//point._Size
        switch ((int)point._Val) {
          case 0:
            NeodroidDrawingUtilities.ForDebug(pos : point._Pos, direction : Vector3.forward, color : Color.cyan);
            break;
          case 1:
            NeodroidDrawingUtilities.ForDebug(pos : point._Pos, direction : Vector3.back, color : Color.cyan);
            break;
          case 2:
            NeodroidDrawingUtilities.ForDebug(pos : point._Pos, direction : Vector3.up, color : Color.cyan);
            break;
          case 3:
            NeodroidDrawingUtilities.ForDebug(pos : point._Pos, direction : Vector3.down, color : Color.cyan);
            break;
          case 4:
            NeodroidDrawingUtilities.ForDebug(pos : point._Pos, direction : Vector3.left, color : Color.cyan);
            break;
          case 5:
            NeodroidDrawingUtilities.ForDebug(pos : point._Pos, direction : Vector3.right, color : Color.cyan);
            break;
        }
      }
    }
  }
}
