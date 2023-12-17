using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for gameplay entitis in game.
/// </summary>
public abstract class BaseEntity : MonoBehaviour
{
   public virtual Vector3 WorldPosition { get => transform.position;}
   
}
