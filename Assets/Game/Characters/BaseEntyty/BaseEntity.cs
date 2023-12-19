using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Base class for gameplay entitis in game.
/// </summary>
public abstract class BaseEntity : MonoBehaviour
{
    [SerializeField, HideInInspector] private string id = Guid.NewGuid().ToString();
   public virtual Vector3 WorldPosition { get => transform.position;}
    public string Id { get => id; }
}
