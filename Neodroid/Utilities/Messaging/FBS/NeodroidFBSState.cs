// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Neodroid.FBS.State
{

using global::System;
using global::FlatBuffers;

public struct FState : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FState GetRootAsFState(ByteBuffer _bb) { return GetRootAsFState(_bb, new FState()); }
  public static FState GetRootAsFState(ByteBuffer _bb, FState obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public static bool FStateBufferHasIdentifier(ByteBuffer _bb) { return Table.__has_identifier(_bb, "STAT"); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FState __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string EnvironmentName { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetEnvironmentNameBytes() { return __p.__vector_as_arraysegment(4); }
  public int FrameNumber { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public float Signal { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public bool Terminated { get { int o = __p.__offset(10); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public string TerminationReason { get { int o = __p.__offset(12); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetTerminationReasonBytes() { return __p.__vector_as_arraysegment(12); }
  public float TotalEnergySpent { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public FOBS? Observations(int j) { int o = __p.__offset(16); return o != 0 ? (FOBS?)(new FOBS()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ObservationsLength { get { int o = __p.__offset(16); return o != 0 ? __p.__vector_len(o) : 0; } }
  public FOBS? ObservationsByKey(string key) { int o = __p.__offset(16); return o != 0 ? FOBS.__lookup_by_key(__p.__vector(o), key, __p.bb) : null; }
  public float Observables(int j) { int o = __p.__offset(18); return o != 0 ? __p.bb.GetFloat(__p.__vector(o) + j * 4) : (float)0; }
  public int ObservablesLength { get { int o = __p.__offset(18); return o != 0 ? __p.__vector_len(o) : 0; } }
  public ArraySegment<byte>? GetObservablesBytes() { return __p.__vector_as_arraysegment(18); }
  public Neodroid.FBS.FUnobservables? Unobservables { get { int o = __p.__offset(20); return o != 0 ? (Neodroid.FBS.FUnobservables?)(new Neodroid.FBS.FUnobservables()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }
  public FEnvironmentDescription? EnvironmentDescription { get { int o = __p.__offset(22); return o != 0 ? (FEnvironmentDescription?)(new FEnvironmentDescription()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }
  public string SerialisedMessage { get { int o = __p.__offset(24); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetSerialisedMessageBytes() { return __p.__vector_as_arraysegment(24); }

  public static Offset<FState> CreateFState(FlatBufferBuilder builder,
      StringOffset environment_nameOffset = default(StringOffset),
      int frame_number = 0,
      float signal = 0.0f,
      bool terminated = false,
      StringOffset termination_reasonOffset = default(StringOffset),
      float total_energy_spent = 0.0f,
      VectorOffset observationsOffset = default(VectorOffset),
      VectorOffset observablesOffset = default(VectorOffset),
      Offset<Neodroid.FBS.FUnobservables> unobservablesOffset = default(Offset<Neodroid.FBS.FUnobservables>),
      Offset<FEnvironmentDescription> environment_descriptionOffset = default(Offset<FEnvironmentDescription>),
      StringOffset serialised_messageOffset = default(StringOffset)) {
    builder.StartObject(11);
    FState.AddSerialisedMessage(builder, serialised_messageOffset);
    FState.AddEnvironmentDescription(builder, environment_descriptionOffset);
    FState.AddUnobservables(builder, unobservablesOffset);
    FState.AddObservables(builder, observablesOffset);
    FState.AddObservations(builder, observationsOffset);
    FState.AddTotalEnergySpent(builder, total_energy_spent);
    FState.AddTerminationReason(builder, termination_reasonOffset);
    FState.AddSignal(builder, signal);
    FState.AddFrameNumber(builder, frame_number);
    FState.AddEnvironmentName(builder, environment_nameOffset);
    FState.AddTerminated(builder, terminated);
    return FState.EndFState(builder);
  }

  public static void StartFState(FlatBufferBuilder builder) { builder.StartObject(11); }
  public static void AddEnvironmentName(FlatBufferBuilder builder, StringOffset environmentNameOffset) { builder.AddOffset(0, environmentNameOffset.Value, 0); }
  public static void AddFrameNumber(FlatBufferBuilder builder, int frameNumber) { builder.AddInt(1, frameNumber, 0); }
  public static void AddSignal(FlatBufferBuilder builder, float signal) { builder.AddFloat(2, signal, 0.0f); }
  public static void AddTerminated(FlatBufferBuilder builder, bool terminated) { builder.AddBool(3, terminated, false); }
  public static void AddTerminationReason(FlatBufferBuilder builder, StringOffset terminationReasonOffset) { builder.AddOffset(4, terminationReasonOffset.Value, 0); }
  public static void AddTotalEnergySpent(FlatBufferBuilder builder, float totalEnergySpent) { builder.AddFloat(5, totalEnergySpent, 0.0f); }
  public static void AddObservations(FlatBufferBuilder builder, VectorOffset observationsOffset) { builder.AddOffset(6, observationsOffset.Value, 0); }
  public static VectorOffset CreateObservationsVector(FlatBufferBuilder builder, Offset<FOBS>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartObservationsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddObservables(FlatBufferBuilder builder, VectorOffset observablesOffset) { builder.AddOffset(7, observablesOffset.Value, 0); }
  public static VectorOffset CreateObservablesVector(FlatBufferBuilder builder, float[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddFloat(data[i]); return builder.EndVector(); }
  public static void StartObservablesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddUnobservables(FlatBufferBuilder builder, Offset<Neodroid.FBS.FUnobservables> unobservablesOffset) { builder.AddOffset(8, unobservablesOffset.Value, 0); }
  public static void AddEnvironmentDescription(FlatBufferBuilder builder, Offset<FEnvironmentDescription> environmentDescriptionOffset) { builder.AddOffset(9, environmentDescriptionOffset.Value, 0); }
  public static void AddSerialisedMessage(FlatBufferBuilder builder, StringOffset serialisedMessageOffset) { builder.AddOffset(10, serialisedMessageOffset.Value, 0); }
  public static Offset<FState> EndFState(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // environment_name
    return new Offset<FState>(o);
  }
  public static void FinishFStateBuffer(FlatBufferBuilder builder, Offset<FState> offset) { builder.Finish(offset.Value, "STAT"); }

  public static VectorOffset CreateSortedVectorOfFState(FlatBufferBuilder builder, Offset<FState>[] offsets) {
    Array.Sort(offsets, (Offset<FState> o1, Offset<FState> o2) => Table.CompareStrings(Table.__offset(4, o1.Value, builder.DataBuffer), Table.__offset(4, o2.Value, builder.DataBuffer), builder.DataBuffer));
    return builder.CreateVectorOfTables(offsets);
  }

  public static FState? __lookup_by_key(int vectorLocation, string key, ByteBuffer bb) {
    byte[] byteKey = System.Text.Encoding.UTF8.GetBytes(key);
    int span = bb.GetInt(vectorLocation - 4);
    int start = 0;
    while (span != 0) {
      int middle = span / 2;
      int tableOffset = Table.__indirect(vectorLocation + 4 * (start + middle), bb);
      int comp = Table.CompareStrings(Table.__offset(4, bb.Length - tableOffset, bb), byteKey, bb);
      if (comp > 0) {
        span = middle;
      } else if (comp < 0) {
        middle++;
        start += middle;
        span -= middle;
      } else {
        return new FState().__assign(tableOffset, bb);
      }
    }
    return null;
  }
};

public struct FObjective : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FObjective GetRootAsFObjective(ByteBuffer _bb) { return GetRootAsFObjective(_bb, new FObjective()); }
  public static FObjective GetRootAsFObjective(ByteBuffer _bb, FObjective obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FObjective __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string ObjectiveName { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetObjectiveNameBytes() { return __p.__vector_as_arraysegment(4); }
  public int MaxEpisodeLength { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public float SolvedThreshold { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }

  public static Offset<FObjective> CreateFObjective(FlatBufferBuilder builder,
      StringOffset objective_nameOffset = default(StringOffset),
      int max_episode_length = 0,
      float solved_threshold = 0.0f) {
    builder.StartObject(3);
    FObjective.AddSolvedThreshold(builder, solved_threshold);
    FObjective.AddMaxEpisodeLength(builder, max_episode_length);
    FObjective.AddObjectiveName(builder, objective_nameOffset);
    return FObjective.EndFObjective(builder);
  }

  public static void StartFObjective(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddObjectiveName(FlatBufferBuilder builder, StringOffset objectiveNameOffset) { builder.AddOffset(0, objectiveNameOffset.Value, 0); }
  public static void AddMaxEpisodeLength(FlatBufferBuilder builder, int maxEpisodeLength) { builder.AddInt(1, maxEpisodeLength, 0); }
  public static void AddSolvedThreshold(FlatBufferBuilder builder, float solvedThreshold) { builder.AddFloat(2, solvedThreshold, 0.0f); }
  public static Offset<FObjective> EndFObjective(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FObjective>(o);
  }
};

public struct FEnvironmentDescription : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FEnvironmentDescription GetRootAsFEnvironmentDescription(ByteBuffer _bb) { return GetRootAsFEnvironmentDescription(_bb, new FEnvironmentDescription()); }
  public static FEnvironmentDescription GetRootAsFEnvironmentDescription(ByteBuffer _bb, FEnvironmentDescription obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FEnvironmentDescription __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FObjective? Objective { get { int o = __p.__offset(4); return o != 0 ? (FObjective?)(new FObjective()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }
  public FObjective? AvailableObjectives(int j) { int o = __p.__offset(6); return o != 0 ? (FObjective?)(new FObjective()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int AvailableObjectivesLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }
  public FActor? Actors(int j) { int o = __p.__offset(8); return o != 0 ? (FActor?)(new FActor()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ActorsLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }
  public FActor? ActorsByKey(string key) { int o = __p.__offset(8); return o != 0 ? FActor.__lookup_by_key(__p.__vector(o), key, __p.bb) : null; }
  public FConfigurable? Configurables(int j) { int o = __p.__offset(10); return o != 0 ? (FConfigurable?)(new FConfigurable()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ConfigurablesLength { get { int o = __p.__offset(10); return o != 0 ? __p.__vector_len(o) : 0; } }
  public FConfigurable? ConfigurablesByKey(string key) { int o = __p.__offset(10); return o != 0 ? FConfigurable.__lookup_by_key(__p.__vector(o), key, __p.bb) : null; }

  public static Offset<FEnvironmentDescription> CreateFEnvironmentDescription(FlatBufferBuilder builder,
      Offset<FObjective> objectiveOffset = default(Offset<FObjective>),
      VectorOffset available_objectivesOffset = default(VectorOffset),
      VectorOffset actorsOffset = default(VectorOffset),
      VectorOffset configurablesOffset = default(VectorOffset)) {
    builder.StartObject(4);
    FEnvironmentDescription.AddConfigurables(builder, configurablesOffset);
    FEnvironmentDescription.AddActors(builder, actorsOffset);
    FEnvironmentDescription.AddAvailableObjectives(builder, available_objectivesOffset);
    FEnvironmentDescription.AddObjective(builder, objectiveOffset);
    return FEnvironmentDescription.EndFEnvironmentDescription(builder);
  }

  public static void StartFEnvironmentDescription(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddObjective(FlatBufferBuilder builder, Offset<FObjective> objectiveOffset) { builder.AddOffset(0, objectiveOffset.Value, 0); }
  public static void AddAvailableObjectives(FlatBufferBuilder builder, VectorOffset availableObjectivesOffset) { builder.AddOffset(1, availableObjectivesOffset.Value, 0); }
  public static VectorOffset CreateAvailableObjectivesVector(FlatBufferBuilder builder, Offset<FObjective>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartAvailableObjectivesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddActors(FlatBufferBuilder builder, VectorOffset actorsOffset) { builder.AddOffset(2, actorsOffset.Value, 0); }
  public static VectorOffset CreateActorsVector(FlatBufferBuilder builder, Offset<FActor>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartActorsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddConfigurables(FlatBufferBuilder builder, VectorOffset configurablesOffset) { builder.AddOffset(3, configurablesOffset.Value, 0); }
  public static VectorOffset CreateConfigurablesVector(FlatBufferBuilder builder, Offset<FConfigurable>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartConfigurablesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<FEnvironmentDescription> EndFEnvironmentDescription(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<FEnvironmentDescription>(o);
  }
};

public struct FConfigurable : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FConfigurable GetRootAsFConfigurable(ByteBuffer _bb) { return GetRootAsFConfigurable(_bb, new FConfigurable()); }
  public static FConfigurable GetRootAsFConfigurable(ByteBuffer _bb, FConfigurable obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FConfigurable __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string ConfigurableName { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetConfigurableNameBytes() { return __p.__vector_as_arraysegment(4); }
  public FObservation ObservationType { get { int o = __p.__offset(6); return o != 0 ? (FObservation)__p.bb.Get(o + __p.bb_pos) : FObservation.NONE; } }
  public TTable? Observation<TTable>() where TTable : struct, IFlatbufferObject { int o = __p.__offset(8); return o != 0 ? (TTable?)__p.__union<TTable>(o) : null; }

  public static Offset<FConfigurable> CreateFConfigurable(FlatBufferBuilder builder,
      StringOffset configurable_nameOffset = default(StringOffset),
      FObservation observation_type = FObservation.NONE,
      int observationOffset = 0) {
    builder.StartObject(3);
    FConfigurable.AddObservation(builder, observationOffset);
    FConfigurable.AddConfigurableName(builder, configurable_nameOffset);
    FConfigurable.AddObservationType(builder, observation_type);
    return FConfigurable.EndFConfigurable(builder);
  }

  public static void StartFConfigurable(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddConfigurableName(FlatBufferBuilder builder, StringOffset configurableNameOffset) { builder.AddOffset(0, configurableNameOffset.Value, 0); }
  public static void AddObservationType(FlatBufferBuilder builder, FObservation observationType) { builder.AddByte(1, (byte)observationType, 0); }
  public static void AddObservation(FlatBufferBuilder builder, int observationOffset) { builder.AddOffset(2, observationOffset, 0); }
  public static Offset<FConfigurable> EndFConfigurable(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // configurable_name
    return new Offset<FConfigurable>(o);
  }

  public static VectorOffset CreateSortedVectorOfFConfigurable(FlatBufferBuilder builder, Offset<FConfigurable>[] offsets) {
    Array.Sort(offsets, (Offset<FConfigurable> o1, Offset<FConfigurable> o2) => Table.CompareStrings(Table.__offset(4, o1.Value, builder.DataBuffer), Table.__offset(4, o2.Value, builder.DataBuffer), builder.DataBuffer));
    return builder.CreateVectorOfTables(offsets);
  }

  public static FConfigurable? __lookup_by_key(int vectorLocation, string key, ByteBuffer bb) {
    byte[] byteKey = System.Text.Encoding.UTF8.GetBytes(key);
    int span = bb.GetInt(vectorLocation - 4);
    int start = 0;
    while (span != 0) {
      int middle = span / 2;
      int tableOffset = Table.__indirect(vectorLocation + 4 * (start + middle), bb);
      int comp = Table.CompareStrings(Table.__offset(4, bb.Length - tableOffset, bb), byteKey, bb);
      if (comp > 0) {
        span = middle;
      } else if (comp < 0) {
        middle++;
        start += middle;
        span -= middle;
      } else {
        return new FConfigurable().__assign(tableOffset, bb);
      }
    }
    return null;
  }
};

public struct FActor : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FActor GetRootAsFActor(ByteBuffer _bb) { return GetRootAsFActor(_bb, new FActor()); }
  public static FActor GetRootAsFActor(ByteBuffer _bb, FActor obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FActor __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string ActorName { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetActorNameBytes() { return __p.__vector_as_arraysegment(4); }
  public bool Alive { get { int o = __p.__offset(6); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public FMotor? Motors(int j) { int o = __p.__offset(8); return o != 0 ? (FMotor?)(new FMotor()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int MotorsLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }
  public FMotor? MotorsByKey(string key) { int o = __p.__offset(8); return o != 0 ? FMotor.__lookup_by_key(__p.__vector(o), key, __p.bb) : null; }

  public static Offset<FActor> CreateFActor(FlatBufferBuilder builder,
      StringOffset actor_nameOffset = default(StringOffset),
      bool alive = false,
      VectorOffset motorsOffset = default(VectorOffset)) {
    builder.StartObject(3);
    FActor.AddMotors(builder, motorsOffset);
    FActor.AddActorName(builder, actor_nameOffset);
    FActor.AddAlive(builder, alive);
    return FActor.EndFActor(builder);
  }

  public static void StartFActor(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddActorName(FlatBufferBuilder builder, StringOffset actorNameOffset) { builder.AddOffset(0, actorNameOffset.Value, 0); }
  public static void AddAlive(FlatBufferBuilder builder, bool alive) { builder.AddBool(1, alive, false); }
  public static void AddMotors(FlatBufferBuilder builder, VectorOffset motorsOffset) { builder.AddOffset(2, motorsOffset.Value, 0); }
  public static VectorOffset CreateMotorsVector(FlatBufferBuilder builder, Offset<FMotor>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartMotorsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<FActor> EndFActor(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // actor_name
    return new Offset<FActor>(o);
  }

  public static VectorOffset CreateSortedVectorOfFActor(FlatBufferBuilder builder, Offset<FActor>[] offsets) {
    Array.Sort(offsets, (Offset<FActor> o1, Offset<FActor> o2) => Table.CompareStrings(Table.__offset(4, o1.Value, builder.DataBuffer), Table.__offset(4, o2.Value, builder.DataBuffer), builder.DataBuffer));
    return builder.CreateVectorOfTables(offsets);
  }

  public static FActor? __lookup_by_key(int vectorLocation, string key, ByteBuffer bb) {
    byte[] byteKey = System.Text.Encoding.UTF8.GetBytes(key);
    int span = bb.GetInt(vectorLocation - 4);
    int start = 0;
    while (span != 0) {
      int middle = span / 2;
      int tableOffset = Table.__indirect(vectorLocation + 4 * (start + middle), bb);
      int comp = Table.CompareStrings(Table.__offset(4, bb.Length - tableOffset, bb), byteKey, bb);
      if (comp > 0) {
        span = middle;
      } else if (comp < 0) {
        middle++;
        start += middle;
        span -= middle;
      } else {
        return new FActor().__assign(tableOffset, bb);
      }
    }
    return null;
  }
};

public struct FMotor : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FMotor GetRootAsFMotor(ByteBuffer _bb) { return GetRootAsFMotor(_bb, new FMotor()); }
  public static FMotor GetRootAsFMotor(ByteBuffer _bb, FMotor obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FMotor __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string MotorName { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetMotorNameBytes() { return __p.__vector_as_arraysegment(4); }
  public Neodroid.FBS.FRange? ValidInput { get { int o = __p.__offset(6); return o != 0 ? (Neodroid.FBS.FRange?)(new Neodroid.FBS.FRange()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public float EnergySpentSinceReset { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }

  public static void StartFMotor(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddMotorName(FlatBufferBuilder builder, StringOffset motorNameOffset) { builder.AddOffset(0, motorNameOffset.Value, 0); }
  public static void AddValidInput(FlatBufferBuilder builder, Offset<Neodroid.FBS.FRange> validInputOffset) { builder.AddStruct(1, validInputOffset.Value, 0); }
  public static void AddEnergySpentSinceReset(FlatBufferBuilder builder, float energySpentSinceReset) { builder.AddFloat(2, energySpentSinceReset, 0.0f); }
  public static Offset<FMotor> EndFMotor(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // motor_name
    builder.Required(o, 6);  // valid_input
    return new Offset<FMotor>(o);
  }

  public static VectorOffset CreateSortedVectorOfFMotor(FlatBufferBuilder builder, Offset<FMotor>[] offsets) {
    Array.Sort(offsets, (Offset<FMotor> o1, Offset<FMotor> o2) => Table.CompareStrings(Table.__offset(4, o1.Value, builder.DataBuffer), Table.__offset(4, o2.Value, builder.DataBuffer), builder.DataBuffer));
    return builder.CreateVectorOfTables(offsets);
  }

  public static FMotor? __lookup_by_key(int vectorLocation, string key, ByteBuffer bb) {
    byte[] byteKey = System.Text.Encoding.UTF8.GetBytes(key);
    int span = bb.GetInt(vectorLocation - 4);
    int start = 0;
    while (span != 0) {
      int middle = span / 2;
      int tableOffset = Table.__indirect(vectorLocation + 4 * (start + middle), bb);
      int comp = Table.CompareStrings(Table.__offset(4, bb.Length - tableOffset, bb), byteKey, bb);
      if (comp > 0) {
        span = middle;
      } else if (comp < 0) {
        middle++;
        start += middle;
        span -= middle;
      } else {
        return new FMotor().__assign(tableOffset, bb);
      }
    }
    return null;
  }
};

public struct FOBS : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static FOBS GetRootAsFOBS(ByteBuffer _bb) { return GetRootAsFOBS(_bb, new FOBS()); }
  public static FOBS GetRootAsFOBS(ByteBuffer _bb, FOBS obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public FOBS __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string ObservationName { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetObservationNameBytes() { return __p.__vector_as_arraysegment(4); }
  public FObservation ObservationType { get { int o = __p.__offset(6); return o != 0 ? (FObservation)__p.bb.Get(o + __p.bb_pos) : FObservation.NONE; } }
  public TTable? Observation<TTable>() where TTable : struct, IFlatbufferObject { int o = __p.__offset(8); return o != 0 ? (TTable?)__p.__union<TTable>(o) : null; }

  public static Offset<FOBS> CreateFOBS(FlatBufferBuilder builder,
      StringOffset observation_nameOffset = default(StringOffset),
      FObservation observation_type = FObservation.NONE,
      int observationOffset = 0) {
    builder.StartObject(3);
    FOBS.AddObservation(builder, observationOffset);
    FOBS.AddObservationName(builder, observation_nameOffset);
    FOBS.AddObservationType(builder, observation_type);
    return FOBS.EndFOBS(builder);
  }

  public static void StartFOBS(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddObservationName(FlatBufferBuilder builder, StringOffset observationNameOffset) { builder.AddOffset(0, observationNameOffset.Value, 0); }
  public static void AddObservationType(FlatBufferBuilder builder, FObservation observationType) { builder.AddByte(1, (byte)observationType, 0); }
  public static void AddObservation(FlatBufferBuilder builder, int observationOffset) { builder.AddOffset(2, observationOffset, 0); }
  public static Offset<FOBS> EndFOBS(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    builder.Required(o, 4);  // observation_name
    return new Offset<FOBS>(o);
  }

  public static VectorOffset CreateSortedVectorOfFOBS(FlatBufferBuilder builder, Offset<FOBS>[] offsets) {
    Array.Sort(offsets, (Offset<FOBS> o1, Offset<FOBS> o2) => Table.CompareStrings(Table.__offset(4, o1.Value, builder.DataBuffer), Table.__offset(4, o2.Value, builder.DataBuffer), builder.DataBuffer));
    return builder.CreateVectorOfTables(offsets);
  }

  public static FOBS? __lookup_by_key(int vectorLocation, string key, ByteBuffer bb) {
    byte[] byteKey = System.Text.Encoding.UTF8.GetBytes(key);
    int span = bb.GetInt(vectorLocation - 4);
    int start = 0;
    while (span != 0) {
      int middle = span / 2;
      int tableOffset = Table.__indirect(vectorLocation + 4 * (start + middle), bb);
      int comp = Table.CompareStrings(Table.__offset(4, bb.Length - tableOffset, bb), byteKey, bb);
      if (comp > 0) {
        span = middle;
      } else if (comp < 0) {
        middle++;
        start += middle;
        span -= middle;
      } else {
        return new FOBS().__assign(tableOffset, bb);
      }
    }
    return null;
  }
};


}
