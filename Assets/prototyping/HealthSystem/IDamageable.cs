using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    Vector3 Position { get; }
    void Damage(float damage);
}