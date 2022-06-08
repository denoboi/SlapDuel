using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Ragdoll : MonoBehaviour
{
    private Collider collider;
    public Collider Collider { get { return collider == null ? collider = GetComponent<Collider>() : collider; } }
}
