using UnityEngine;

/// <summary>
/// Contains raycasting methods for input detection
/// </summary>
public struct InputRaycasts
{
    /// <summary>
    /// Returns a CustomRaycastHit (can be false) at the specified screen position of the camera. Overload which raycasts against specified layers only
    /// </summary>
    /// <param name="cam"></param>
    /// <param name="screenPos"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public CustomRaycastHit RaycastScreenPosition(Camera cam, Vector2 screenPos, int layer)
    {
        CustomRaycastHit customRaycastHit;

        Ray ray = cam.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out customRaycastHit.raycastHit, cam.farClipPlane, layer))
        {
            customRaycastHit.hitDetected = true;
            return customRaycastHit;
        }

        else
        {
            customRaycastHit.hitDetected = false;
            return customRaycastHit;
        }
    }

    /// <summary>
    /// Returns a CustomRaycastHit (can be false) at the specified screen position of the camera. Overload which raycasts against all layers
    /// </summary>
    /// <param name="cam"></param>
    /// <param name="screenPos"></param>
    /// <returns></returns>
    public CustomRaycastHit RaycastScreenPosition(Camera cam, Vector2 screenPos)
    {
        CustomRaycastHit customRaycastHit;

        Ray ray = cam.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out customRaycastHit.raycastHit, cam.farClipPlane))
        {
            customRaycastHit.hitDetected = true;
            return customRaycastHit;
        }

        else
        {
            customRaycastHit.hitDetected = false;
            return customRaycastHit;
        }
    }
}
