using UnityEngine;

/// <summary>
/// Controls the selection for Tiles (inherits from SelectionController)
/// </summary>
public class TileSelection : SelectionController
{
    /// <summary>
    /// Override of SelectionController Awake which adds the MonoConstructor for Tiles layer detection
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        MonoConstructor(LayerMask.NameToLayer("Tiles"), false);
    }
}
