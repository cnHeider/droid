﻿using droid.Runtime.Enums;
using droid.Runtime.Structs.Space;
using NUnit.Framework;
using UnityEngine;

namespace droid.Tests.Editor.Structs.Space {
  /// <summary>
  ///
  /// </summary>
  [TestFixture]
  public class Space3Tests {
    /// <summary>
    ///
    /// </summary>
    [Test]
    public void TestDenormalise010() {
      var space = new Space3 {
                                 Min = Vector3.zero,
                                 Max = Vector3.one * 10,
                                 Normalised = NormalisationEnum.Zero_one_
                             };

      Assert.That(Vector3.Distance(a : space.Reproject(v : Vector3.one * 0.5f), b : Vector3.one * 5f)
                  <= float.Epsilon,
                  Is.True);
    }

    /// <summary>
    ///
    /// </summary>
    [Test]
    public void TestNormalise010() {
      var space = new Space3 {
                                 Min = Vector3.zero,
                                 Max = Vector3.one * 10,
                                 Normalised = NormalisationEnum.Zero_one_
                             };

      Assert.That(Vector3.Distance(a : space.Project(v : 6 * Vector3.one), b : Vector3.one * 0.6f)
                  <= float.Epsilon,
                  Is.True);
    }

    /// <summary>
    ///
    /// </summary>
    [Test]
    public void TestNormaliseMinus11() {
      var space = new Space3 {
                                 Min = Vector3.one * -1,
                                 Max = Vector3.one * 1,
                                 Normalised = NormalisationEnum.Zero_one_
                             };

      Assert.That(Vector3.Distance(a : space.Project(v : 0.5f * Vector3.one), b : Vector3.one * 0.75f)
                  <= float.Epsilon,
                  Is.True);
    }

    /// <summary>
    ///
    /// </summary>
    [Test]
    public void TestDenormaliseMinus11() {
      var space = new Space3 {
                                 Min = Vector3.one * -1,
                                 Max = Vector3.one * 1,
                                 Normalised = NormalisationEnum.Zero_one_
                             };

      Assert.That(Vector3.Distance(a : space.Reproject(v : 0.75f * Vector3.one), b : Vector3.one * 0.5f)
                  <= float.Epsilon,
                  Is.True);
    }
  }
}
