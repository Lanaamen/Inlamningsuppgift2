using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandPresenceActionBased : MonoBehaviour
{
    [SerializeField]
    private InputActionReference triggerAction;

    [SerializeField]
    private InputActionReference gripAction;

    public Animator handAnimator;

    private void OnEnable()
    {
        // Aktiverar input actions
        triggerAction.action.Enable();
        gripAction.action.Enable();

        // Subscriber till deras performed event
        triggerAction.action.performed += Action_Trigger_performed;
        gripAction.action.performed += Action_Grip_performed;
    }

    private void OnDisable()
    {
        // Unsubscribe till att lyssna p� performed event
        triggerAction.action.performed -= Action_Trigger_performed;
        gripAction.action.performed -= Action_Grip_performed;

        // Inaktiverar input actions
        triggerAction.action.Disable();
        gripAction.action.Disable();
    }

    private void Action_Trigger_performed(InputAction.CallbackContext obj)
    {
        float triggerValue = obj.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
    }

    private void Action_Grip_performed(InputAction.CallbackContext obj)
    {
        // L�ser av flyttalsv�rdet (float) fr�n gripknappen p� XR Controller
        // Beroende p� hur mycket ni trycker ned tagenten kommer ocks� ge ett
        // v�rde mellan 0 och 1
        float gripValue = obj.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }


}
