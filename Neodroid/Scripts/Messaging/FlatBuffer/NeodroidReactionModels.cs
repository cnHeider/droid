// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Neodroid.Messaging.Models.Reaction
{

using global::System;
using global::FlatBuffers;

public struct FlatBufferReaction : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FlatBufferReaction GetRootAsFlatBufferReaction(ByteBuffer _bb) { return GetRootAsFlatBufferReaction(_bb, new FlatBufferReaction()); }
  public static FlatBufferReaction GetRootAsFlatBufferReaction(ByteBuffer _bb, FlatBufferReaction obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public static bool FlatBufferReactionBufferHasIdentifier(ByteBuffer _bb) { return Table.__has_identifier(_bb, "REAC"); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FlatBufferReaction __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FlatBufferMotion? Motions(int j) { int o = __p.__offset(4); return o != 0 ? (FlatBufferMotion?)(new FlatBufferMotion()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int MotionsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
  public FlatBufferConfiguration? Configurations(int j) { int o = __p.__offset(6); return o != 0 ? (FlatBufferConfiguration?)(new FlatBufferConfiguration()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ConfigurationsLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }
  public bool Reset { get { int o = __p.__offset(8); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }

  public static Offset<FlatBufferReaction> CreateFlatBufferReaction(FlatBufferBuilder builder,
      VectorOffset motionsOffset = default(VectorOffset),
      VectorOffset configurationsOffset = default(VectorOffset),
      bool reset = false) {
    builder.StartObject(3);
    FlatBufferReaction.AddConfigurations(builder, configurationsOffset);
    FlatBufferReaction.AddMotions(builder, motionsOffset);
    FlatBufferReaction.AddReset(builder, reset);
    return FlatBufferReaction.EndFlatBufferReaction(builder);
  }

  public static void StartFlatBufferReaction(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddMotions(FlatBufferBuilder builder, VectorOffset motionsOffset) { builder.AddOffset(0, motionsOffset.Value, 0); }
  public static VectorOffset CreateMotionsVector(FlatBufferBuilder builder, Offset<FlatBufferMotion>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartMotionsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddConfigurations(FlatBufferBuilder builder, VectorOffset configurationsOffset) { builder.AddOffset(1, configurationsOffset.Value, 0); }
  public static VectorOffset CreateConfigurationsVector(FlatBufferBuilder builder, Offset<FlatBufferConfiguration>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartConfigurationsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddReset(FlatBufferBuilder builder, bool reset) { builder.AddBool(2, reset, false); }
  public static Offset<FlatBufferReaction> EndFlatBufferReaction(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FlatBufferReaction>(o);
  }
  public static void FinishFlatBufferReactionBuffer(FlatBufferBuilder builder, Offset<FlatBufferReaction> offset) { builder.Finish(offset.Value, "REAC"); }
};

public struct FlatBufferMotion : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FlatBufferMotion GetRootAsFlatBufferMotion(ByteBuffer _bb) { return GetRootAsFlatBufferMotion(_bb, new FlatBufferMotion()); }
  public static FlatBufferMotion GetRootAsFlatBufferMotion(ByteBuffer _bb, FlatBufferMotion obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FlatBufferMotion __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string ActorName { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetActorNameBytes() { return __p.__vector_as_arraysegment(4); }
  public string MotorName { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetMotorNameBytes() { return __p.__vector_as_arraysegment(6); }
  public float Strength { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }

  public static Offset<FlatBufferMotion> CreateFlatBufferMotion(FlatBufferBuilder builder,
      StringOffset actor_nameOffset = default(StringOffset),
      StringOffset motor_nameOffset = default(StringOffset),
      float strength = 0.0f) {
    builder.StartObject(3);
    FlatBufferMotion.AddStrength(builder, strength);
    FlatBufferMotion.AddMotorName(builder, motor_nameOffset);
    FlatBufferMotion.AddActorName(builder, actor_nameOffset);
    return FlatBufferMotion.EndFlatBufferMotion(builder);
  }

  public static void StartFlatBufferMotion(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddActorName(FlatBufferBuilder builder, StringOffset actorNameOffset) { builder.AddOffset(0, actorNameOffset.Value, 0); }
  public static void AddMotorName(FlatBufferBuilder builder, StringOffset motorNameOffset) { builder.AddOffset(1, motorNameOffset.Value, 0); }
  public static void AddStrength(FlatBufferBuilder builder, float strength) { builder.AddFloat(2, strength, 0.0f); }
  public static Offset<FlatBufferMotion> EndFlatBufferMotion(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FlatBufferMotion>(o);
  }
};

public struct FlatBufferConfiguration : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FlatBufferConfiguration GetRootAsFlatBufferConfiguration(ByteBuffer _bb) { return GetRootAsFlatBufferConfiguration(_bb, new FlatBufferConfiguration()); }
  public static FlatBufferConfiguration GetRootAsFlatBufferConfiguration(ByteBuffer _bb, FlatBufferConfiguration obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FlatBufferConfiguration __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Key { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetKeyBytes() { return __p.__vector_as_arraysegment(4); }
  public string Value { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetValueBytes() { return __p.__vector_as_arraysegment(6); }

  public static Offset<FlatBufferConfiguration> CreateFlatBufferConfiguration(FlatBufferBuilder builder,
      StringOffset keyOffset = default(StringOffset),
      StringOffset valueOffset = default(StringOffset)) {
    builder.StartObject(2);
    FlatBufferConfiguration.AddValue(builder, valueOffset);
    FlatBufferConfiguration.AddKey(builder, keyOffset);
    return FlatBufferConfiguration.EndFlatBufferConfiguration(builder);
  }

  public static void StartFlatBufferConfiguration(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddKey(FlatBufferBuilder builder, StringOffset keyOffset) { builder.AddOffset(0, keyOffset.Value, 0); }
  public static void AddValue(FlatBufferBuilder builder, StringOffset valueOffset) { builder.AddOffset(1, valueOffset.Value, 0); }
  public static Offset<FlatBufferConfiguration> EndFlatBufferConfiguration(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FlatBufferConfiguration>(o);
  }
};


}
