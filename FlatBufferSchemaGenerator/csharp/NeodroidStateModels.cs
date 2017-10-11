// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Neodroid.Messaging.Models.State
{

using global::System;
using global::FlatBuffers;

public struct FlatBufferVec3 : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FlatBufferVec3 __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public float X { get { return __p.bb.GetFloat(__p.bb_pos + 0); } }
  public float Y { get { return __p.bb.GetFloat(__p.bb_pos + 4); } }
  public float Z { get { return __p.bb.GetFloat(__p.bb_pos + 8); } }

  public static Offset<FlatBufferVec3> CreateFlatBufferVec3(FlatBufferBuilder builder, float X, float Y, float Z) {
    builder.Prep(4, 12);
    builder.PutFloat(Z);
    builder.PutFloat(Y);
    builder.PutFloat(X);
    return new Offset<FlatBufferVec3>(builder.Offset);
  }
};

public struct FlatBufferQuat : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FlatBufferQuat __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public float X { get { return __p.bb.GetFloat(__p.bb_pos + 0); } }
  public float Y { get { return __p.bb.GetFloat(__p.bb_pos + 4); } }
  public float Z { get { return __p.bb.GetFloat(__p.bb_pos + 8); } }
  public float W { get { return __p.bb.GetFloat(__p.bb_pos + 12); } }

  public static Offset<FlatBufferQuat> CreateFlatBufferQuat(FlatBufferBuilder builder, float X, float Y, float Z, float W) {
    builder.Prep(4, 16);
    builder.PutFloat(W);
    builder.PutFloat(Z);
    builder.PutFloat(Y);
    builder.PutFloat(X);
    return new Offset<FlatBufferQuat>(builder.Offset);
  }
};

public struct FlatBufferActor : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FlatBufferActor GetRootAsFlatBufferActor(ByteBuffer _bb) { return GetRootAsFlatBufferActor(_bb, new FlatBufferActor()); }
  public static FlatBufferActor GetRootAsFlatBufferActor(ByteBuffer _bb, FlatBufferActor obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FlatBufferActor __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Name { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(4); }
  public FlatBufferPosRotDir? Posrotdir { get { int o = __p.__offset(6); return o != 0 ? (FlatBufferPosRotDir?)(new FlatBufferPosRotDir()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }
  public FlatBufferMotor? Motors(int j) { int o = __p.__offset(8); return o != 0 ? (FlatBufferMotor?)(new FlatBufferMotor()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int MotorsLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<FlatBufferActor> CreateFlatBufferActor(FlatBufferBuilder builder,
      StringOffset nameOffset = default(StringOffset),
      Offset<FlatBufferPosRotDir> posrotdirOffset = default(Offset<FlatBufferPosRotDir>),
      VectorOffset motorsOffset = default(VectorOffset)) {
    builder.StartObject(3);
    FlatBufferActor.AddMotors(builder, motorsOffset);
    FlatBufferActor.AddPosrotdir(builder, posrotdirOffset);
    FlatBufferActor.AddName(builder, nameOffset);
    return FlatBufferActor.EndFlatBufferActor(builder);
  }

  public static void StartFlatBufferActor(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddPosrotdir(FlatBufferBuilder builder, Offset<FlatBufferPosRotDir> posrotdirOffset) { builder.AddOffset(1, posrotdirOffset.Value, 0); }
  public static void AddMotors(FlatBufferBuilder builder, VectorOffset motorsOffset) { builder.AddOffset(2, motorsOffset.Value, 0); }
  public static VectorOffset CreateMotorsVector(FlatBufferBuilder builder, Offset<FlatBufferMotor>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartMotorsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<FlatBufferActor> EndFlatBufferActor(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FlatBufferActor>(o);
  }
};

public struct FlatBufferState : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FlatBufferState GetRootAsFlatBufferState(ByteBuffer _bb) { return GetRootAsFlatBufferState(_bb, new FlatBufferState()); }
  public static FlatBufferState GetRootAsFlatBufferState(ByteBuffer _bb, FlatBufferState obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public static bool FlatBufferStateBufferHasIdentifier(ByteBuffer _bb) { return Table.__has_identifier(_bb, "STAT"); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FlatBufferState __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public float TimeSinceRest { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public float TotalEnergySpentSinceReset { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public FlatBufferActor? Actors(int j) { int o = __p.__offset(8); return o != 0 ? (FlatBufferActor?)(new FlatBufferActor()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ActorsLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }
  public FlatBufferObserver? Observers(int j) { int o = __p.__offset(10); return o != 0 ? (FlatBufferObserver?)(new FlatBufferObserver()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ObserversLength { get { int o = __p.__offset(10); return o != 0 ? __p.__vector_len(o) : 0; } }
  public float RewardForLastStep { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public bool Interupted { get { int o = __p.__offset(14); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }

  public static Offset<FlatBufferState> CreateFlatBufferState(FlatBufferBuilder builder,
      float time_since_rest = 0.0f,
      float total_energy_spent_since_reset = 0.0f,
      VectorOffset actorsOffset = default(VectorOffset),
      VectorOffset observersOffset = default(VectorOffset),
      float reward_for_last_step = 0.0f,
      bool interupted = false) {
    builder.StartObject(6);
    FlatBufferState.AddRewardForLastStep(builder, reward_for_last_step);
    FlatBufferState.AddObservers(builder, observersOffset);
    FlatBufferState.AddActors(builder, actorsOffset);
    FlatBufferState.AddTotalEnergySpentSinceReset(builder, total_energy_spent_since_reset);
    FlatBufferState.AddTimeSinceRest(builder, time_since_rest);
    FlatBufferState.AddInterupted(builder, interupted);
    return FlatBufferState.EndFlatBufferState(builder);
  }

  public static void StartFlatBufferState(FlatBufferBuilder builder) { builder.StartObject(6); }
  public static void AddTimeSinceRest(FlatBufferBuilder builder, float timeSinceRest) { builder.AddFloat(0, timeSinceRest, 0.0f); }
  public static void AddTotalEnergySpentSinceReset(FlatBufferBuilder builder, float totalEnergySpentSinceReset) { builder.AddFloat(1, totalEnergySpentSinceReset, 0.0f); }
  public static void AddActors(FlatBufferBuilder builder, VectorOffset actorsOffset) { builder.AddOffset(2, actorsOffset.Value, 0); }
  public static VectorOffset CreateActorsVector(FlatBufferBuilder builder, Offset<FlatBufferActor>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartActorsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddObservers(FlatBufferBuilder builder, VectorOffset observersOffset) { builder.AddOffset(3, observersOffset.Value, 0); }
  public static VectorOffset CreateObserversVector(FlatBufferBuilder builder, Offset<FlatBufferObserver>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartObserversVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddRewardForLastStep(FlatBufferBuilder builder, float rewardForLastStep) { builder.AddFloat(4, rewardForLastStep, 0.0f); }
  public static void AddInterupted(FlatBufferBuilder builder, bool interupted) { builder.AddBool(5, interupted, false); }
  public static Offset<FlatBufferState> EndFlatBufferState(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FlatBufferState>(o);
  }
  public static void FinishFlatBufferStateBuffer(FlatBufferBuilder builder, Offset<FlatBufferState> offset) { builder.Finish(offset.Value, "STAT"); }
};

public struct FlatBufferPosRotDir : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FlatBufferPosRotDir GetRootAsFlatBufferPosRotDir(ByteBuffer _bb) { return GetRootAsFlatBufferPosRotDir(_bb, new FlatBufferPosRotDir()); }
  public static FlatBufferPosRotDir GetRootAsFlatBufferPosRotDir(ByteBuffer _bb, FlatBufferPosRotDir obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FlatBufferPosRotDir __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FlatBufferVec3? Position { get { int o = __p.__offset(4); return o != 0 ? (FlatBufferVec3?)(new FlatBufferVec3()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FlatBufferVec3? Direction { get { int o = __p.__offset(6); return o != 0 ? (FlatBufferVec3?)(new FlatBufferVec3()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FlatBufferQuat? Rotation { get { int o = __p.__offset(8); return o != 0 ? (FlatBufferQuat?)(new FlatBufferQuat()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartFlatBufferPosRotDir(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddPosition(FlatBufferBuilder builder, Offset<FlatBufferVec3> positionOffset) { builder.AddStruct(0, positionOffset.Value, 0); }
  public static void AddDirection(FlatBufferBuilder builder, Offset<FlatBufferVec3> directionOffset) { builder.AddStruct(1, directionOffset.Value, 0); }
  public static void AddRotation(FlatBufferBuilder builder, Offset<FlatBufferQuat> rotationOffset) { builder.AddStruct(2, rotationOffset.Value, 0); }
  public static Offset<FlatBufferPosRotDir> EndFlatBufferPosRotDir(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FlatBufferPosRotDir>(o);
  }
};

public struct FlatBufferObserver : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FlatBufferObserver GetRootAsFlatBufferObserver(ByteBuffer _bb) { return GetRootAsFlatBufferObserver(_bb, new FlatBufferObserver()); }
  public static FlatBufferObserver GetRootAsFlatBufferObserver(ByteBuffer _bb, FlatBufferObserver obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FlatBufferObserver __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Name { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(4); }
  public byte Data(int j) { int o = __p.__offset(6); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int DataLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }
  public ArraySegment<byte>? GetDataBytes() { return __p.__vector_as_arraysegment(6); }
  public FlatBufferPosRotDir? Posrotdir { get { int o = __p.__offset(8); return o != 0 ? (FlatBufferPosRotDir?)(new FlatBufferPosRotDir()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }

  public static Offset<FlatBufferObserver> CreateFlatBufferObserver(FlatBufferBuilder builder,
      StringOffset nameOffset = default(StringOffset),
      VectorOffset dataOffset = default(VectorOffset),
      Offset<FlatBufferPosRotDir> posrotdirOffset = default(Offset<FlatBufferPosRotDir>)) {
    builder.StartObject(3);
    FlatBufferObserver.AddPosrotdir(builder, posrotdirOffset);
    FlatBufferObserver.AddData(builder, dataOffset);
    FlatBufferObserver.AddName(builder, nameOffset);
    return FlatBufferObserver.EndFlatBufferObserver(builder);
  }

  public static void StartFlatBufferObserver(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddData(FlatBufferBuilder builder, VectorOffset dataOffset) { builder.AddOffset(1, dataOffset.Value, 0); }
  public static VectorOffset CreateDataVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static void StartDataVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddPosrotdir(FlatBufferBuilder builder, Offset<FlatBufferPosRotDir> posrotdirOffset) { builder.AddOffset(2, posrotdirOffset.Value, 0); }
  public static Offset<FlatBufferObserver> EndFlatBufferObserver(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FlatBufferObserver>(o);
  }
};

public struct FlatBufferMotor : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FlatBufferMotor GetRootAsFlatBufferMotor(ByteBuffer _bb) { return GetRootAsFlatBufferMotor(_bb, new FlatBufferMotor()); }
  public static FlatBufferMotor GetRootAsFlatBufferMotor(ByteBuffer _bb, FlatBufferMotor obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FlatBufferMotor __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Name { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(4); }
  public bool Binary { get { int o = __p.__offset(6); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public float EnergyCost { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public float EnergySpentSinceReset { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }

  public static Offset<FlatBufferMotor> CreateFlatBufferMotor(FlatBufferBuilder builder,
      StringOffset nameOffset = default(StringOffset),
      bool binary = false,
      float energy_cost = 0.0f,
      float energy_spent_since_reset = 0.0f) {
    builder.StartObject(4);
    FlatBufferMotor.AddEnergySpentSinceReset(builder, energy_spent_since_reset);
    FlatBufferMotor.AddEnergyCost(builder, energy_cost);
    FlatBufferMotor.AddName(builder, nameOffset);
    FlatBufferMotor.AddBinary(builder, binary);
    return FlatBufferMotor.EndFlatBufferMotor(builder);
  }

  public static void StartFlatBufferMotor(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddBinary(FlatBufferBuilder builder, bool binary) { builder.AddBool(1, binary, false); }
  public static void AddEnergyCost(FlatBufferBuilder builder, float energyCost) { builder.AddFloat(2, energyCost, 0.0f); }
  public static void AddEnergySpentSinceReset(FlatBufferBuilder builder, float energySpentSinceReset) { builder.AddFloat(3, energySpentSinceReset, 0.0f); }
  public static Offset<FlatBufferMotor> EndFlatBufferMotor(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FlatBufferMotor>(o);
  }
};


}
