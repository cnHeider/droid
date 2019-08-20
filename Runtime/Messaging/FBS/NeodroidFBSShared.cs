// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using FlatBuffers;

namespace droid.Runtime.Messaging.FBS
{
  public enum FSimulationType : byte
{
 Independent = 0,
 FrameDependent = 1,
 PhysicsDependent = 2,
 EventDependent = 3,
};

public struct FUnobservables : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return this.__p.bb; } }
  public static FUnobservables GetRootAsFUnobservables(ByteBuffer _bb) { return GetRootAsFUnobservables(_bb, new FUnobservables()); }
  public static FUnobservables GetRootAsFUnobservables(ByteBuffer _bb, FUnobservables obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { this.__p.bb_pos = _i; this.__p.bb = _bb; }
  public FUnobservables __assign(int _i, ByteBuffer _bb) { this.__init(_i, _bb); return this; }

  public FQuaternionTransform? Poses(int j) { int o = this.__p.__offset(4); return o != 0 ? (FQuaternionTransform?)(new FQuaternionTransform()).__assign(this.__p.__vector(o) + j * 56, this.__p.bb) : null; }
  public int PosesLength { get { int o = this.__p.__offset(4); return o != 0 ? this.__p.__vector_len(o) : 0; } }
  public FBody? Bodies(int j) { int o = this.__p.__offset(6); return o != 0 ? (FBody?)(new FBody()).__assign(this.__p.__vector(o) + j * 48, this.__p.bb) : null; }
  public int BodiesLength { get { int o = this.__p.__offset(6); return o != 0 ? this.__p.__vector_len(o) : 0; } }

  public static Offset<FUnobservables> CreateFUnobservables(FlatBufferBuilder builder,
      VectorOffset posesOffset = default(VectorOffset),
      VectorOffset bodiesOffset = default(VectorOffset)) {
    builder.StartObject(2);
    FUnobservables.AddBodies(builder, bodiesOffset);
    FUnobservables.AddPoses(builder, posesOffset);
    return FUnobservables.EndFUnobservables(builder);
  }

  public static void StartFUnobservables(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddPoses(FlatBufferBuilder builder, VectorOffset posesOffset) { builder.AddOffset(0, posesOffset.Value, 0); }
  public static void StartPosesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(56, numElems, 8); }
  public static void AddBodies(FlatBufferBuilder builder, VectorOffset bodiesOffset) { builder.AddOffset(1, bodiesOffset.Value, 0); }
  public static void StartBodiesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(48, numElems, 8); }
  public static Offset<FUnobservables> EndFUnobservables(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FUnobservables>(o);
  }
};

public struct FVector2 : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return this.__p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { this.__p.bb_pos = _i; this.__p.bb = _bb; }
  public FVector2 __assign(int _i, ByteBuffer _bb) { this.__init(_i, _bb); return this; }

  public double X { get { return this.__p.bb.GetDouble(this.__p.bb_pos + 0); } }
  public double Y { get { return this.__p.bb.GetDouble(this.__p.bb_pos + 8); } }

  public static Offset<FVector2> CreateFVector2(FlatBufferBuilder builder, double X, double Y) {
    builder.Prep(8, 16);
    builder.PutDouble(Y);
    builder.PutDouble(X);
    return new Offset<FVector2>(builder.Offset);
  }
};

public struct FVector3 : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return this.__p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { this.__p.bb_pos = _i; this.__p.bb = _bb; }
  public FVector3 __assign(int _i, ByteBuffer _bb) { this.__init(_i, _bb); return this; }

  public double X { get { return this.__p.bb.GetDouble(this.__p.bb_pos + 0); } }
  public double Y { get { return this.__p.bb.GetDouble(this.__p.bb_pos + 8); } }
  public double Z { get { return this.__p.bb.GetDouble(this.__p.bb_pos + 16); } }

  public static Offset<FVector3> CreateFVector3(FlatBufferBuilder builder, double X, double Y, double Z) {
    builder.Prep(8, 24);
    builder.PutDouble(Z);
    builder.PutDouble(Y);
    builder.PutDouble(X);
    return new Offset<FVector3>(builder.Offset);
  }
};

public struct FQuaternion : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return this.__p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { this.__p.bb_pos = _i; this.__p.bb = _bb; }
  public FQuaternion __assign(int _i, ByteBuffer _bb) { this.__init(_i, _bb); return this; }

  public double X { get { return this.__p.bb.GetDouble(this.__p.bb_pos + 0); } }
  public double Y { get { return this.__p.bb.GetDouble(this.__p.bb_pos + 8); } }
  public double Z { get { return this.__p.bb.GetDouble(this.__p.bb_pos + 16); } }
  public double W { get { return this.__p.bb.GetDouble(this.__p.bb_pos + 24); } }

  public static Offset<FQuaternion> CreateFQuaternion(FlatBufferBuilder builder, double X, double Y, double Z, double W) {
    builder.Prep(8, 32);
    builder.PutDouble(W);
    builder.PutDouble(Z);
    builder.PutDouble(Y);
    builder.PutDouble(X);
    return new Offset<FQuaternion>(builder.Offset);
  }
};

public struct FQuaternionTransform : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return this.__p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { this.__p.bb_pos = _i; this.__p.bb = _bb; }
  public FQuaternionTransform __assign(int _i, ByteBuffer _bb) { this.__init(_i, _bb); return this; }

  public FVector3 Position { get { return (new FVector3()).__assign(this.__p.bb_pos + 0, this.__p.bb); } }
  public FQuaternion Rotation { get { return (new FQuaternion()).__assign(this.__p.bb_pos + 24, this.__p.bb); } }

  public static Offset<FQuaternionTransform> CreateFQuaternionTransform(FlatBufferBuilder builder, double position_X, double position_Y, double position_Z, double rotation_X, double rotation_Y, double rotation_Z, double rotation_W) {
    builder.Prep(8, 56);
    builder.Prep(8, 32);
    builder.PutDouble(rotation_W);
    builder.PutDouble(rotation_Z);
    builder.PutDouble(rotation_Y);
    builder.PutDouble(rotation_X);
    builder.Prep(8, 24);
    builder.PutDouble(position_Z);
    builder.PutDouble(position_Y);
    builder.PutDouble(position_X);
    return new Offset<FQuaternionTransform>(builder.Offset);
  }
};

public struct FEulerTransform : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return this.__p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { this.__p.bb_pos = _i; this.__p.bb = _bb; }
  public FEulerTransform __assign(int _i, ByteBuffer _bb) { this.__init(_i, _bb); return this; }

  public FVector3 Position { get { return (new FVector3()).__assign(this.__p.bb_pos + 0, this.__p.bb); } }
  public FVector3 Rotation { get { return (new FVector3()).__assign(this.__p.bb_pos + 24, this.__p.bb); } }
  public FVector3 Direction { get { return (new FVector3()).__assign(this.__p.bb_pos + 48, this.__p.bb); } }

  public static Offset<FEulerTransform> CreateFEulerTransform(FlatBufferBuilder builder, double position_X, double position_Y, double position_Z, double rotation_X, double rotation_Y, double rotation_Z, double direction_X, double direction_Y, double direction_Z) {
    builder.Prep(8, 72);
    builder.Prep(8, 24);
    builder.PutDouble(direction_Z);
    builder.PutDouble(direction_Y);
    builder.PutDouble(direction_X);
    builder.Prep(8, 24);
    builder.PutDouble(rotation_Z);
    builder.PutDouble(rotation_Y);
    builder.PutDouble(rotation_X);
    builder.Prep(8, 24);
    builder.PutDouble(position_Z);
    builder.PutDouble(position_Y);
    builder.PutDouble(position_X);
    return new Offset<FEulerTransform>(builder.Offset);
  }
};

public struct FBody : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return this.__p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { this.__p.bb_pos = _i; this.__p.bb = _bb; }
  public FBody __assign(int _i, ByteBuffer _bb) { this.__init(_i, _bb); return this; }

  public FVector3 Velocity { get { return (new FVector3()).__assign(this.__p.bb_pos + 0, this.__p.bb); } }
  public FVector3 AngularVelocity { get { return (new FVector3()).__assign(this.__p.bb_pos + 24, this.__p.bb); } }

  public static Offset<FBody> CreateFBody(FlatBufferBuilder builder, double velocity_X, double velocity_Y, double velocity_Z, double angular_velocity_X, double angular_velocity_Y, double angular_velocity_Z) {
    builder.Prep(8, 48);
    builder.Prep(8, 24);
    builder.PutDouble(angular_velocity_Z);
    builder.PutDouble(angular_velocity_Y);
    builder.PutDouble(angular_velocity_X);
    builder.Prep(8, 24);
    builder.PutDouble(velocity_Z);
    builder.PutDouble(velocity_Y);
    builder.PutDouble(velocity_X);
    return new Offset<FBody>(builder.Offset);
  }
};

public struct FRange : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return this.__p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { this.__p.bb_pos = _i; this.__p.bb = _bb; }
  public FRange __assign(int _i, ByteBuffer _bb) { this.__init(_i, _bb); return this; }

  public int DecimalGranularity { get { return this.__p.bb.GetInt(this.__p.bb_pos + 0); } }
  public float MaxValue { get { return this.__p.bb.GetFloat(this.__p.bb_pos + 4); } }
  public float MinValue { get { return this.__p.bb.GetFloat(this.__p.bb_pos + 8); } }
  public bool Normalised { get { return 0!=this.__p.bb.Get(this.__p.bb_pos + 12); } }

  public static Offset<FRange> CreateFRange(FlatBufferBuilder builder, int DecimalGranularity, float MaxValue, float MinValue, bool Normalised) {
    builder.Prep(4, 16);
    builder.Pad(3);
    builder.PutBool(Normalised);
    builder.PutFloat(MinValue);
    builder.PutFloat(MaxValue);
    builder.PutInt(DecimalGranularity);
    return new Offset<FRange>(builder.Offset);
  }
};

public struct FSimulatorConfiguration : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return this.__p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { this.__p.bb_pos = _i; this.__p.bb = _bb; }
  public FSimulatorConfiguration __assign(int _i, ByteBuffer _bb) { this.__init(_i, _bb); return this; }

  public int Width { get { return this.__p.bb.GetInt(this.__p.bb_pos + 0); } }
  public int Height { get { return this.__p.bb.GetInt(this.__p.bb_pos + 4); } }
  public bool FullScreen { get { return 0!=this.__p.bb.Get(this.__p.bb_pos + 8); } }
  public int QualityLevel { get { return this.__p.bb.GetInt(this.__p.bb_pos + 12); } }
  public float TimeScale { get { return this.__p.bb.GetFloat(this.__p.bb_pos + 16); } }
  public float TargetFrameRate { get { return this.__p.bb.GetFloat(this.__p.bb_pos + 20); } }
  public FSimulationType SimulationType { get { return (FSimulationType)this.__p.bb.Get(this.__p.bb_pos + 24); } }
  public int FrameSkips { get { return this.__p.bb.GetInt(this.__p.bb_pos + 28); } }
  public int ResetIterations { get { return this.__p.bb.GetInt(this.__p.bb_pos + 32); } }
  public int NumOfEnvironments { get { return this.__p.bb.GetInt(this.__p.bb_pos + 36); } }
  public bool DoSerialiseIndividualSensors { get { return 0!=this.__p.bb.Get(this.__p.bb_pos + 40); } }
  public bool DoSerialiseUnobservables { get { return 0!=this.__p.bb.Get(this.__p.bb_pos + 41); } }

  public static Offset<FSimulatorConfiguration> CreateFSimulatorConfiguration(FlatBufferBuilder builder, int Width, int Height, bool FullScreen, int QualityLevel, float TimeScale, float TargetFrameRate, FSimulationType SimulationType, int FrameSkips, int ResetIterations, int NumOfEnvironments, bool DoSerialiseIndividualSensors, bool DoSerialiseUnobservables) {
    builder.Prep(4, 44);
    builder.Pad(2);
    builder.PutBool(DoSerialiseUnobservables);
    builder.PutBool(DoSerialiseIndividualSensors);
    builder.PutInt(NumOfEnvironments);
    builder.PutInt(ResetIterations);
    builder.PutInt(FrameSkips);
    builder.Pad(3);
    builder.PutByte((byte)SimulationType);
    builder.PutFloat(TargetFrameRate);
    builder.PutFloat(TimeScale);
    builder.PutInt(QualityLevel);
    builder.Pad(3);
    builder.PutBool(FullScreen);
    builder.PutInt(Height);
    builder.PutInt(Width);
    return new Offset<FSimulatorConfiguration>(builder.Offset);
  }
};


}
