using System;
using droid.Runtime.Messaging.Messages;

namespace droid.Runtime.Interfaces {
  /// <inheritdoc />
  ///  <summary>
  ///  </summary>
  public interface IEnvironment : IRegisterable {
    /// <summary>
    ///
    /// </summary>
    Reaction LastReaction { get; }

    /// <summary>
    ///
    /// </summary>
    int StepI { get; }

    /// <summary>
    ///
    /// </summary>
    bool Terminated { get; }

    /// <summary>
    ///
    /// </summary>
    string LastTerminationReason { get; }

    /// <summary>
    ///
    /// </summary>
    bool IsResetting { get; }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    EnvironmentSnapshot Snapshot();

    /// <summary>
    ///
    /// </summary>
    /// <param name="reaction"></param>
    void Step(Reaction reaction);

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    Reaction SampleReaction();

    /// <summary>
    ///
    /// </summary>
    void PostStep();

    /// <summary>
    ///
    /// </summary>
    void Configure(Reaction reaction);

    /// <summary>
    ///
    /// </summary>
    void Reset();
  }
}
