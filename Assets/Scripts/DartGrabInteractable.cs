using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Drop this component on the same GameObject as <see cref="DartStick"/> and <see cref="XRGrabInteractable"/>.
/// When the dart is picked up (SelectEntered), it tells the <see cref="DartStick"/> to unstick so physics is re-enabled.
/// </summary>
[RequireComponent(typeof(DartStick), typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
public class DartGrabInteractable : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    private DartStick _dartStick;

    protected override void Awake()
    {
        base.Awake();
        _dartStick = GetComponent<DartStick>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Ensure the dart is free before handing it to the interactor
        _dartStick?.Unstick();
        base.OnSelectEntered(args);
    }
}
