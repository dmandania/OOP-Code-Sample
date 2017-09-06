using UnityEngine;

/// <summary>
/// Controls the selection for Heroes (inherits from SelectionController)
/// </summary>
public class HeroSelection : SelectionController
{
    /// <summary>
    /// Override of SelectionController Awake which adds the MonoConstructor for Heroes layer detection
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        MonoConstructor(LayerMask.NameToLayer("Heroes"), false);
    }
}
