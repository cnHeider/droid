﻿using UnityEngine;
using System;
using Neodroid.Evaluation;

[RequireComponent(typeof(Rigidbody))]
public class PusnishmentFunction : ObjectiveFunction {

  public LayerMask _layer_mask;
  public GameObject _player;
  private int hits;

  // Use this for initialization
  void Start() {
    ResetHits();
    var balls = GameObject.FindGameObjectsWithTag("balls");

    foreach (GameObject ball in balls) {
      ball.AddComponent<OnChildCollision>().CollisionDelegate = OnChildCollision;
    }
  }

  private void OnChildCollision(Collision collision) {
    if (collision.collider.name == _player.name)
      hits += 1;

    if (true) {
      Debug.Log(hits);
    }
  }

  void ResetHits() {
    hits = 0;
  }

  public override float Evaluate() {
    return hits * -1f;
  }
}