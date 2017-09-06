using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base class for controlling selection
/// </summary>
public class SelectionController : MonoBehaviour
{
    /// <summary>
    /// Enum to define which MonoConstructor overload is being used
    /// </summary>
    private enum SelectionControllerType
    {
        Default,
        Layer
    }

    /// <summary>
    /// Tracks the MonoConstructor overload being used for the class
    /// </summary>
    private SelectionControllerType selectionType;

    /// <summary>
    /// Used as a pseudo-constructor. Overload for selection against all layers
    /// </summary>
    protected void MonoConstructor()
    {
        selectionType = SelectionControllerType.Default;
    }

    /// <summary>
    /// Used as a pseudo-constructor. Overload for selection against specified layers only
    /// </summary>
    /// <param name="layer"></param>
    /// <param name="invertMask"></param>
    protected void MonoConstructor(int layer, bool invertMask)
    {
        selectionType = SelectionControllerType.Layer;
        layerSaved = layer;
        invertMaskSaved = invertMask;
    }

    /// <summary>
    /// Saves the layer variable when the relevant constructor is used
    /// </summary>
    private int layerSaved;

    /// <summary>
    /// Saves the invertMask variable when the relevant constructor is used
    /// </summary>
    private bool invertMaskSaved;

    /// <summary>
    /// An event that fires when something has been selected
    /// </summary>
    protected UnityEvent selectionEvent = new UnityEvent();

    /// <summary>
    /// Property which returns the currently selected GameObject as well as invoking the selectionEvent in the setter
    /// </summary>
    protected virtual GameObject CurrentSelection
    {
        get
        {
            return currentSelection;
        }

        set
        {
            currentSelection = value;

            selectionEvent.Invoke();
        }
    }
    private GameObject currentSelection;

    /// <summary>
    /// Contains methods for raycasting
    /// </summary>
    private InputRaycasts inputRaycasts;

    /// <summary>
    /// Detects the last selected GameObject and saves the result to CurrentSelection
    /// </summary>
    private void OnSelect()
    {
        if (Input.GetMouseButtonUp(0) == true)
        {
            switch (selectionType)
            {
                case SelectionControllerType.Default:
                {
                    if (inputRaycasts.RaycastScreenPosition(GameController.Instance.primaryCamera, Input.mousePosition).hitDetected == true)
                        CurrentSelection = inputRaycasts.RaycastScreenPosition(GameController.Instance.primaryCamera, Input.mousePosition).raycastHit.collider.gameObject;
                    else
                        CurrentSelection = null;

                    break;
                }

                case SelectionControllerType.Layer:
                {
                    int layer;

                    layer = 1 << layerSaved;

                    if (invertMaskSaved == true)
                        layer = ~layer;

                    if (inputRaycasts.RaycastScreenPosition(GameController.Instance.primaryCamera, Input.mousePosition, layer).hitDetected == true)
                        CurrentSelection = inputRaycasts.RaycastScreenPosition(GameController.Instance.primaryCamera, Input.mousePosition, layer).raycastHit.collider.gameObject;
                    else
                        CurrentSelection = null;

                    break;
                }
            }
        }
    }

    /// <summary>
    /// Overridable Awake method which sets CurrentSelection to null
    /// </summary>
    protected virtual void Awake()
    {
        CurrentSelection = null;
    }

    /// <summary>
    /// Overridable Update method which runs SelectionController functionality (output is saved to CurrentSelection)
    /// </summary>
    protected virtual void Update()
    {
        OnSelect();
    }
}
