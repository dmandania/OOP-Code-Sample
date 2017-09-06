using UnityEngine;

/// <summary>
/// Stores Unity's default RaycastHit struct as well as a hitDetected bool
/// </summary>
public struct CustomRaycastHit
{
    public bool hitDetected;
    public RaycastHit raycastHit;
}
