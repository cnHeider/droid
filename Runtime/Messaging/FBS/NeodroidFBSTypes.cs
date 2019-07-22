// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Neodroid.FBS
{

using global::System;
using global::FlatBuffers;

public enum FByteDataType : byte
{
 UINT8 = 0,
 FLOAT16 = 1,
 FLOAT32 = 2,
 PNG = 3,
 JPEG = 4,
 Other = 5,
};

public struct FSingle : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FSingle GetRootAsFSingle(ByteBuffer _bb) { return GetRootAsFSingle(_bb, new FSingle()); }
  public static FSingle GetRootAsFSingle(ByteBuffer _bb, FSingle obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FSingle __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public double Value { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetDouble(o + __p.bb_pos) : (double)0.0; } }
  public FRange? Range { get { int o = __p.__offset(6); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartFSingle(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddValue(FlatBufferBuilder builder, double value) { builder.AddDouble(0, value, 0.0); }
  public static void AddRange(FlatBufferBuilder builder, Offset<FRange> rangeOffset) { builder.AddStruct(1, rangeOffset.Value, 0); }
  public static Offset<FSingle> EndFSingle(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FSingle>(o);
  }
};

public struct FDouble : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FDouble GetRootAsFDouble(ByteBuffer _bb) { return GetRootAsFDouble(_bb, new FDouble()); }
  public static FDouble GetRootAsFDouble(ByteBuffer _bb, FDouble obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FDouble __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FVector2? Vec2 { get { int o = __p.__offset(4); return o != 0 ? (FVector2?)(new FVector2()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? XRange { get { int o = __p.__offset(6); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? YRange { get { int o = __p.__offset(8); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartFDouble(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddVec2(FlatBufferBuilder builder, Offset<FVector2> vec2Offset) { builder.AddStruct(0, vec2Offset.Value, 0); }
  public static void AddXRange(FlatBufferBuilder builder, Offset<FRange> xRangeOffset) { builder.AddStruct(1, xRangeOffset.Value, 0); }
  public static void AddYRange(FlatBufferBuilder builder, Offset<FRange> yRangeOffset) { builder.AddStruct(2, yRangeOffset.Value, 0); }
  public static Offset<FDouble> EndFDouble(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FDouble>(o);
  }
};

public struct FTriple : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FTriple GetRootAsFTriple(ByteBuffer _bb) { return GetRootAsFTriple(_bb, new FTriple()); }
  public static FTriple GetRootAsFTriple(ByteBuffer _bb, FTriple obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FTriple __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FVector3? Vec3 { get { int o = __p.__offset(4); return o != 0 ? (FVector3?)(new FVector3()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? XRange { get { int o = __p.__offset(6); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? YRange { get { int o = __p.__offset(8); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? ZRange { get { int o = __p.__offset(10); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartFTriple(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddVec3(FlatBufferBuilder builder, Offset<FVector3> vec3Offset) { builder.AddStruct(0, vec3Offset.Value, 0); }
  public static void AddXRange(FlatBufferBuilder builder, Offset<FRange> xRangeOffset) { builder.AddStruct(1, xRangeOffset.Value, 0); }
  public static void AddYRange(FlatBufferBuilder builder, Offset<FRange> yRangeOffset) { builder.AddStruct(2, yRangeOffset.Value, 0); }
  public static void AddZRange(FlatBufferBuilder builder, Offset<FRange> zRangeOffset) { builder.AddStruct(3, zRangeOffset.Value, 0); }
  public static Offset<FTriple> EndFTriple(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // vec3
    return new Offset<FTriple>(o);
  }
};

public struct FQuadruple : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FQuadruple GetRootAsFQuadruple(ByteBuffer _bb) { return GetRootAsFQuadruple(_bb, new FQuadruple()); }
  public static FQuadruple GetRootAsFQuadruple(ByteBuffer _bb, FQuadruple obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FQuadruple __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FQuaternion? Quat { get { int o = __p.__offset(4); return o != 0 ? (FQuaternion?)(new FQuaternion()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? XRange { get { int o = __p.__offset(6); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? YRange { get { int o = __p.__offset(8); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? ZRange { get { int o = __p.__offset(10); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? WRange { get { int o = __p.__offset(12); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartFQuadruple(FlatBufferBuilder builder) { builder.StartObject(5); }
  public static void AddQuat(FlatBufferBuilder builder, Offset<FQuaternion> quatOffset) { builder.AddStruct(0, quatOffset.Value, 0); }
  public static void AddXRange(FlatBufferBuilder builder, Offset<FRange> xRangeOffset) { builder.AddStruct(1, xRangeOffset.Value, 0); }
  public static void AddYRange(FlatBufferBuilder builder, Offset<FRange> yRangeOffset) { builder.AddStruct(2, yRangeOffset.Value, 0); }
  public static void AddZRange(FlatBufferBuilder builder, Offset<FRange> zRangeOffset) { builder.AddStruct(3, zRangeOffset.Value, 0); }
  public static void AddWRange(FlatBufferBuilder builder, Offset<FRange> wRangeOffset) { builder.AddStruct(4, wRangeOffset.Value, 0); }
  public static Offset<FQuadruple> EndFQuadruple(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // quat
    return new Offset<FQuadruple>(o);
  }
};

public struct FArray : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FArray GetRootAsFArray(ByteBuffer _bb) { return GetRootAsFArray(_bb, new FArray()); }
  public static FArray GetRootAsFArray(ByteBuffer _bb, FArray obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FArray __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public float Array(int j) { int o = __p.__offset(4); return o != 0 ? __p.bb.GetFloat(__p.__vector(o) + j * 4) : (float)0; }
  public int ArrayLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetArrayBytes() { return __p.__vector_as_span(4); }
#else
  public ArraySegment<byte>? GetArrayBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public float[] GetArrayArray() { return __p.__vector_as_array<float>(4); }
  public FRange? Ranges(int j) { int o = __p.__offset(6); return o != 0 ? (FRange?)(new FRange()).__assign(__p.__vector(o) + j * 16, __p.bb) : null; }
  public int RangesLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<FArray> CreateFArray(FlatBufferBuilder builder,
      VectorOffset arrayOffset = default(VectorOffset),
      VectorOffset rangesOffset = default(VectorOffset)) {
    builder.StartObject(2);
    FArray.AddRanges(builder, rangesOffset);
    FArray.AddArray(builder, arrayOffset);
    return FArray.EndFArray(builder);
  }

  public static void StartFArray(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddArray(FlatBufferBuilder builder, VectorOffset arrayOffset) { builder.AddOffset(0, arrayOffset.Value, 0); }
  public static VectorOffset CreateArrayVector(FlatBufferBuilder builder, float[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddFloat(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateArrayVectorBlock(FlatBufferBuilder builder, float[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartArrayVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddRanges(FlatBufferBuilder builder, VectorOffset rangesOffset) { builder.AddOffset(1, rangesOffset.Value, 0); }
  public static void StartRangesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(16, numElems, 4); }
  public static Offset<FArray> EndFArray(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // array
    return new Offset<FArray>(o);
  }
};

public struct FRBObs : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FRBObs GetRootAsFRBObs(ByteBuffer _bb) { return GetRootAsFRBObs(_bb, new FRBObs()); }
  public static FRBObs GetRootAsFRBObs(ByteBuffer _bb, FRBObs obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FRBObs __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FBody? Body { get { int o = __p.__offset(4); return o != 0 ? (FBody?)(new FBody()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? VelRange { get { int o = __p.__offset(6); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? AngRange { get { int o = __p.__offset(8); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartFRBObs(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddBody(FlatBufferBuilder builder, Offset<FBody> bodyOffset) { builder.AddStruct(0, bodyOffset.Value, 0); }
  public static void AddVelRange(FlatBufferBuilder builder, Offset<FRange> velRangeOffset) { builder.AddStruct(1, velRangeOffset.Value, 0); }
  public static void AddAngRange(FlatBufferBuilder builder, Offset<FRange> angRangeOffset) { builder.AddStruct(2, angRangeOffset.Value, 0); }
  public static Offset<FRBObs> EndFRBObs(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // body
    return new Offset<FRBObs>(o);
  }
};

public struct FETObs : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FETObs GetRootAsFETObs(ByteBuffer _bb) { return GetRootAsFETObs(_bb, new FETObs()); }
  public static FETObs GetRootAsFETObs(ByteBuffer _bb, FETObs obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FETObs __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FEulerTransform? Transform { get { int o = __p.__offset(4); return o != 0 ? (FEulerTransform?)(new FEulerTransform()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? PosRange { get { int o = __p.__offset(6); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? RotRange { get { int o = __p.__offset(8); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? DirRange { get { int o = __p.__offset(10); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartFETObs(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddTransform(FlatBufferBuilder builder, Offset<FEulerTransform> transformOffset) { builder.AddStruct(0, transformOffset.Value, 0); }
  public static void AddPosRange(FlatBufferBuilder builder, Offset<FRange> posRangeOffset) { builder.AddStruct(1, posRangeOffset.Value, 0); }
  public static void AddRotRange(FlatBufferBuilder builder, Offset<FRange> rotRangeOffset) { builder.AddStruct(2, rotRangeOffset.Value, 0); }
  public static void AddDirRange(FlatBufferBuilder builder, Offset<FRange> dirRangeOffset) { builder.AddStruct(3, dirRangeOffset.Value, 0); }
  public static Offset<FETObs> EndFETObs(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // transform
    return new Offset<FETObs>(o);
  }
};

public struct FQTObs : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FQTObs GetRootAsFQTObs(ByteBuffer _bb) { return GetRootAsFQTObs(_bb, new FQTObs()); }
  public static FQTObs GetRootAsFQTObs(ByteBuffer _bb, FQTObs obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FQTObs __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FQuaternionTransform? Transform { get { int o = __p.__offset(4); return o != 0 ? (FQuaternionTransform?)(new FQuaternionTransform()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? PosRange { get { int o = __p.__offset(6); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public FRange? RotRange { get { int o = __p.__offset(8); return o != 0 ? (FRange?)(new FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartFQTObs(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddTransform(FlatBufferBuilder builder, Offset<FQuaternionTransform> transformOffset) { builder.AddStruct(0, transformOffset.Value, 0); }
  public static void AddPosRange(FlatBufferBuilder builder, Offset<FRange> posRangeOffset) { builder.AddStruct(1, posRangeOffset.Value, 0); }
  public static void AddRotRange(FlatBufferBuilder builder, Offset<FRange> rotRangeOffset) { builder.AddStruct(2, rotRangeOffset.Value, 0); }
  public static Offset<FQTObs> EndFQTObs(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // transform
    return new Offset<FQTObs>(o);
  }
};

public struct FString : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FString GetRootAsFString(ByteBuffer _bb) { return GetRootAsFString(_bb, new FString()); }
  public static FString GetRootAsFString(ByteBuffer _bb, FString obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FString __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Str { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetStrBytes() { return __p.__vector_as_span(4); }
#else
  public ArraySegment<byte>? GetStrBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetStrArray() { return __p.__vector_as_array<byte>(4); }

  public static Offset<FString> CreateFString(FlatBufferBuilder builder,
      StringOffset strOffset = default(StringOffset)) {
    builder.StartObject(1);
    FString.AddStr(builder, strOffset);
    return FString.EndFString(builder);
  }

  public static void StartFString(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddStr(FlatBufferBuilder builder, StringOffset strOffset) { builder.AddOffset(0, strOffset.Value, 0); }
  public static Offset<FString> EndFString(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // str
    return new Offset<FString>(o);
  }
};

public struct FByteArray : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FByteArray GetRootAsFByteArray(ByteBuffer _bb) { return GetRootAsFByteArray(_bb, new FByteArray()); }
  public static FByteArray GetRootAsFByteArray(ByteBuffer _bb, FByteArray obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FByteArray __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public byte Bytes(int j) { int o = __p.__offset(4); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int BytesLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetBytesBytes() { return __p.__vector_as_span(4); }
#else
  public ArraySegment<byte>? GetBytesBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetBytesArray() { return __p.__vector_as_array<byte>(4); }
  public FByteDataType Type { get { int o = __p.__offset(6); return o != 0 ? (FByteDataType)__p.bb.Get(o + __p.bb_pos) : FByteDataType.UINT8; } }
  public int Shape(int j) { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(__p.__vector(o) + j * 4) : (int)0; }
  public int ShapeLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetShapeBytes() { return __p.__vector_as_span(8); }
#else
  public ArraySegment<byte>? GetShapeBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public int[] GetShapeArray() { return __p.__vector_as_array<int>(8); }

  public static Offset<FByteArray> CreateFByteArray(FlatBufferBuilder builder,
      VectorOffset bytesOffset = default(VectorOffset),
      FByteDataType type = FByteDataType.UINT8,
      VectorOffset shapeOffset = default(VectorOffset)) {
    builder.StartObject(3);
    FByteArray.AddShape(builder, shapeOffset);
    FByteArray.AddBytes(builder, bytesOffset);
    FByteArray.AddType(builder, type);
    return FByteArray.EndFByteArray(builder);
  }

  public static void StartFByteArray(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddBytes(FlatBufferBuilder builder, VectorOffset bytesOffset) { builder.AddOffset(0, bytesOffset.Value, 0); }
  public static VectorOffset CreateBytesVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateBytesVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static void StartBytesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddType(FlatBufferBuilder builder, FByteDataType type) { builder.AddByte(1, (byte)type, 0); }
  public static void AddShape(FlatBufferBuilder builder, VectorOffset shapeOffset) { builder.AddOffset(2, shapeOffset.Value, 0); }
  public static VectorOffset CreateShapeVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateShapeVectorBlock(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartShapeVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<FByteArray> EndFByteArray(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // bytes
    return new Offset<FByteArray>(o);
  }
};

public struct FValue : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FValue GetRootAsFValue(ByteBuffer _bb) { return GetRootAsFValue(_bb, new FValue()); }
  public static FValue GetRootAsFValue(ByteBuffer _bb, FValue obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FValue __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public double Val { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetDouble(o + __p.bb_pos) : (double)0.0; } }

  public static Offset<FValue> CreateFValue(FlatBufferBuilder builder,
      double val = 0.0) {
    builder.StartObject(1);
    FValue.AddVal(builder, val);
    return FValue.EndFValue(builder);
  }

  public static void StartFValue(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddVal(FlatBufferBuilder builder, double val) { builder.AddDouble(0, val, 0.0); }
  public static Offset<FValue> EndFValue(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FValue>(o);
  }
};

public struct FValues : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FValues GetRootAsFValues(ByteBuffer _bb) { return GetRootAsFValues(_bb, new FValues()); }
  public static FValues GetRootAsFValues(ByteBuffer _bb, FValues obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FValues __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public double Vals(int j) { int o = __p.__offset(4); return o != 0 ? __p.bb.GetDouble(__p.__vector(o) + j * 8) : (double)0; }
  public int ValsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetValsBytes() { return __p.__vector_as_span(4); }
#else
  public ArraySegment<byte>? GetValsBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public double[] GetValsArray() { return __p.__vector_as_array<double>(4); }

  public static Offset<FValues> CreateFValues(FlatBufferBuilder builder,
      VectorOffset valsOffset = default(VectorOffset)) {
    builder.StartObject(1);
    FValues.AddVals(builder, valsOffset);
    return FValues.EndFValues(builder);
  }

  public static void StartFValues(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddVals(FlatBufferBuilder builder, VectorOffset valsOffset) { builder.AddOffset(0, valsOffset.Value, 0); }
  public static VectorOffset CreateValsVector(FlatBufferBuilder builder, double[] data) { builder.StartVector(8, data.Length, 8); for (int i = data.Length - 1; i >= 0; i--) builder.AddDouble(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateValsVectorBlock(FlatBufferBuilder builder, double[] data) { builder.StartVector(8, data.Length, 8); builder.Add(data); return builder.EndVector(); }
  public static void StartValsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(8, numElems, 8); }
  public static Offset<FValues> EndFValues(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // vals
    return new Offset<FValues>(o);
  }
};

public struct FValuedVector3Point : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FValuedVector3Point GetRootAsFValuedVector3Point(ByteBuffer _bb) { return GetRootAsFValuedVector3Point(_bb, new FValuedVector3Point()); }
  public static FValuedVector3Point GetRootAsFValuedVector3Point(ByteBuffer _bb, FValuedVector3Point obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FValuedVector3Point __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public double Val { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetDouble(o + __p.bb_pos) : (double)0.0; } }
  public FVector3? Point { get { int o = __p.__offset(6); return o != 0 ? (FVector3?)(new FVector3()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartFValuedVector3Point(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddVal(FlatBufferBuilder builder, double val) { builder.AddDouble(0, val, 0.0); }
  public static void AddPoint(FlatBufferBuilder builder, Offset<FVector3> pointOffset) { builder.AddStruct(1, pointOffset.Value, 0); }
  public static Offset<FValuedVector3Point> EndFValuedVector3Point(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FValuedVector3Point>(o);
  }
};

public struct FVector3s : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FVector3s GetRootAsFVector3s(ByteBuffer _bb) { return GetRootAsFVector3s(_bb, new FVector3s()); }
  public static FVector3s GetRootAsFVector3s(ByteBuffer _bb, FVector3s obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FVector3s __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FVector3? Points(int j) { int o = __p.__offset(4); return o != 0 ? (FVector3?)(new FVector3()).__assign(__p.__vector(o) + j * 24, __p.bb) : null; }
  public int PointsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<FVector3s> CreateFVector3s(FlatBufferBuilder builder,
      VectorOffset pointsOffset = default(VectorOffset)) {
    builder.StartObject(1);
    FVector3s.AddPoints(builder, pointsOffset);
    return FVector3s.EndFVector3s(builder);
  }

  public static void StartFVector3s(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddPoints(FlatBufferBuilder builder, VectorOffset pointsOffset) { builder.AddOffset(0, pointsOffset.Value, 0); }
  public static void StartPointsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(24, numElems, 8); }
  public static Offset<FVector3s> EndFVector3s(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // points
    return new Offset<FVector3s>(o);
  }
};

public struct FValuedVector3s : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FValuedVector3s GetRootAsFValuedVector3s(ByteBuffer _bb) { return GetRootAsFValuedVector3s(_bb, new FValuedVector3s()); }
  public static FValuedVector3s GetRootAsFValuedVector3s(ByteBuffer _bb, FValuedVector3s obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FValuedVector3s __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public double Vals(int j) { int o = __p.__offset(4); return o != 0 ? __p.bb.GetDouble(__p.__vector(o) + j * 8) : (double)0; }
  public int ValsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetValsBytes() { return __p.__vector_as_span(4); }
#else
  public ArraySegment<byte>? GetValsBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public double[] GetValsArray() { return __p.__vector_as_array<double>(4); }
  public FVector3? Points(int j) { int o = __p.__offset(6); return o != 0 ? (FVector3?)(new FVector3()).__assign(__p.__vector(o) + j * 24, __p.bb) : null; }
  public int PointsLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<FValuedVector3s> CreateFValuedVector3s(FlatBufferBuilder builder,
      VectorOffset valsOffset = default(VectorOffset),
      VectorOffset pointsOffset = default(VectorOffset)) {
    builder.StartObject(2);
    FValuedVector3s.AddPoints(builder, pointsOffset);
    FValuedVector3s.AddVals(builder, valsOffset);
    return FValuedVector3s.EndFValuedVector3s(builder);
  }

  public static void StartFValuedVector3s(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddVals(FlatBufferBuilder builder, VectorOffset valsOffset) { builder.AddOffset(0, valsOffset.Value, 0); }
  public static VectorOffset CreateValsVector(FlatBufferBuilder builder, double[] data) { builder.StartVector(8, data.Length, 8); for (int i = data.Length - 1; i >= 0; i--) builder.AddDouble(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateValsVectorBlock(FlatBufferBuilder builder, double[] data) { builder.StartVector(8, data.Length, 8); builder.Add(data); return builder.EndVector(); }
  public static void StartValsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(8, numElems, 8); }
  public static void AddPoints(FlatBufferBuilder builder, VectorOffset pointsOffset) { builder.AddOffset(1, pointsOffset.Value, 0); }
  public static void StartPointsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(24, numElems, 8); }
  public static Offset<FValuedVector3s> EndFValuedVector3s(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // vals
    builder.Required(o, 6);  // points
    return new Offset<FValuedVector3s>(o);
  }
};


}
