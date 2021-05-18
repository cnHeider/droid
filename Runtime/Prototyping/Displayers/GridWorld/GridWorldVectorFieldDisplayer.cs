namespace droid.Runtime.Prototyping.Displayers.GridWorld {
  /// <inheritdoc />
  /// <summary>
  /// </summary>
  [UnityEngine.ExecuteInEditMode]
  [UnityEngine.AddComponentMenu(menuName : DisplayerComponentMenuPath._ComponentMenuPath
                                           + "GridWorldVectorField"
                                           + DisplayerComponentMenuPath._Postfix)]
  public class GridWorldVectorFieldDisplayer : Displayer {
    void Update() {
      if (this._RetainLastPlot) {
        if (this._Values != null) {
          PlotSeries(points : this._Values);
        }
      }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public override void Setup() { }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    public override void Display(double value) { }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="values"></param>
    public override void Display(float[] values) { }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="values"></param>
    public override void Display(string values) { }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="T:System.NotImplementedException"></exception>
    public override void Display(UnityEngine.Vector3 value) { throw new System.NotImplementedException(); }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    public override void Display(UnityEngine.Vector3[] value) { this.ScatterPlot(points : value); }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="points"></param>
    public override void Display(droid.Runtime.Structs.Points.ValuePoint points) {
      this.PlotSeries(points : new[] {points});
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="points"></param>
    public override void Display(droid.Runtime.Structs.Points.ValuePoint[] points) { }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="point"></param>
    /// <exception cref="T:System.NotImplementedException"></exception>
    public override void Display(droid.Runtime.Structs.Points.StringPoint point) {
      throw new System.NotImplementedException();
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="points"></param>
    /// <exception cref="T:System.NotImplementedException"></exception>
    public override void Display(droid.Runtime.Structs.Points.StringPoint[] points) {
      throw new System.NotImplementedException();
    }

    //public override void Display(Object o) { throw new NotImplementedException(); }
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <param name="values"></param>
    public override void Display(float values) { }

    /// <summary>
    /// </summary>
    /// <param name="points"></param>
    public void ScatterPlot(UnityEngine.Vector3[] points) { }

    /*public override void PlotSeries(float[] points) {

    }*/

    /// <summary>
    /// </summary>
    /// <param name="points"></param>
    public override void PlotSeries(droid.Runtime.Structs.Points.ValuePoint[] points) {
      #if NEODROID_DEBUG
      if (this.Debugging) {
        UnityEngine.Debug.Log("Plotting value points");
      }
      #endif

      this._Values = points;

      foreach (var point in points) {
        //point._Size
        switch ((int)point._Val) {
          case 0:
            droid.Runtime.Utilities.Drawing.NeodroidDrawingUtilities.ForDebug(pos : point._Pos,
              direction : UnityEngine.Vector3.forward,
              color : UnityEngine.Color.cyan);
            break;
          case 1:
            droid.Runtime.Utilities.Drawing.NeodroidDrawingUtilities.ForDebug(pos : point._Pos,
              direction : UnityEngine.Vector3.back,
              color : UnityEngine.Color.cyan);
            break;
          case 2:
            droid.Runtime.Utilities.Drawing.NeodroidDrawingUtilities.ForDebug(pos : point._Pos,
              direction : UnityEngine.Vector3.up,
              color : UnityEngine.Color.cyan);
            break;
          case 3:
            droid.Runtime.Utilities.Drawing.NeodroidDrawingUtilities.ForDebug(pos : point._Pos,
              direction : UnityEngine.Vector3.down,
              color : UnityEngine.Color.cyan);
            break;
          case 4:
            droid.Runtime.Utilities.Drawing.NeodroidDrawingUtilities.ForDebug(pos : point._Pos,
              direction : UnityEngine.Vector3.left,
              color : UnityEngine.Color.cyan);
            break;
          case 5:
            droid.Runtime.Utilities.Drawing.NeodroidDrawingUtilities.ForDebug(pos : point._Pos,
              direction : UnityEngine.Vector3.right,
              color : UnityEngine.Color.cyan);
            break;
        }
      }
    }
  }
}