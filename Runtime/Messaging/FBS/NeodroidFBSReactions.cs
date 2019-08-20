// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using System;
using FlatBuffers;

namespace droid.Runtime.Messaging.FBS
{
  public struct FReactions : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return this.__p.bb; } }
  public static FReactions GetRootAsFReactions(ByteBuffer _bb) { return GetRootAsFReactions(_bb, new FReactions()); }
  public static FReactions GetRootAsFReactions(ByteBuffer _bb, FReactions obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public static bool FReactionsBufferHasIdentifier(ByteBuffer _bb) { return Table.__has_identifier(_bb, "XREA"); }
  public void __init(int _i, ByteBuffer _bb) { this.__p.bb_pos = _i; this.__p.bb = _bb; }
  public FReactions __assign(int _i, ByteBuffer _bb) { this.__init(_i, _bb); return this; }

  public FReaction? Reactions(int j) { int o = this.__p.__offset(4); return o != 0 ? (FReaction?)(new FReaction()).__assign(this.__p.__indirect(this.__p.__vector(o) + j * 4), this.__p.bb) : null; }
  public int ReactionsLength { get { int o = this.__p.__offset(4); return o != 0 ? this.__p.__vector_len(o) : 0; } }
  public FReaction? ReactionsByKey(string key) { int o = this.__p.__offset(4); return o != 0 ? FReaction.__lookup_by_key(this.__p.__vector(o), key, this.__p.bb) : null; }
  public string ApiVersion { get { int o = this.__p.__offset(6); return o != 0 ? this.__p.__string(o + this.__p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetApiVersionBytes() { return __p.__vector_as_span(6); }
#else
  public ArraySegment<byte>? GetApiVersionBytes() { return this.__p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetApiVersionArray() { return this.__p.__vector_as_array<byte>(6); }
  public FSimulatorConfiguration? SimulatorConfiguration { get { int o = this.__p.__offset(8); return o != 0 ? (FSimulatorConfiguration?)(new FSimulatorConfiguration()).__assign(o + this.__p.bb_pos, this.__p.bb) : null; } }
  public bool Close { get { int o = this.__p.__offset(10); return o != 0 ? 0!=this.__p.bb.Get(o + this.__p.bb_pos) : (bool)false; } }

  public static void StartFReactions(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddReactions(FlatBufferBuilder builder, VectorOffset reactionsOffset) { builder.AddOffset(0, reactionsOffset.Value, 0); }
  public static VectorOffset CreateReactionsVector(FlatBufferBuilder builder, Offset<FReaction>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateReactionsVectorBlock(FlatBufferBuilder builder, Offset<FReaction>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartReactionsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddApiVersion(FlatBufferBuilder builder, StringOffset apiVersionOffset) { builder.AddOffset(1, apiVersionOffset.Value, 0); }
  public static void AddSimulatorConfiguration(FlatBufferBuilder builder, Offset<FSimulatorConfiguration> simulatorConfigurationOffset) { builder.AddStruct(2, simulatorConfigurationOffset.Value, 0); }
  public static void AddClose(FlatBufferBuilder builder, bool close) { builder.AddBool(3, close, false); }
  public static Offset<FReactions> EndFReactions(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FReactions>(o);
  }
  public static void FinishFReactionsBuffer(FlatBufferBuilder builder, Offset<FReactions> offset) { builder.Finish(offset.Value, "XREA"); }
  public static void FinishSizePrefixedFReactionsBuffer(FlatBufferBuilder builder, Offset<FReactions> offset) { builder.FinishSizePrefixed(offset.Value, "XREA"); }
};


}
