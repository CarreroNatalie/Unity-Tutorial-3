using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class MushroomEater : MonoBehaviour
{
    public ScreenFader screenFader;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool isHeld = false;

    [SerializeField] private InputActionReference eatAction;

    void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isHeld = true;
        eatAction.action.performed += OnEatPressed;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;
        eatAction.action.performed -= OnEatPressed;
    }

    private void OnEatPressed(InputAction.CallbackContext ctx)
    {
        if (isHeld)
        {
            EatMushroom();
        }
    }

    private void EatMushroom()
    {
        Debug.Log("Mushroom eaten!");

        // Hide visuals
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Destroy after delay
        Destroy(gameObject, 2f);
    }

    private void OnDestroy()
    {
        eatAction.action.performed -= OnEatPressed;
    }
}
