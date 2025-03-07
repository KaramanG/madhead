using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class weaponBehaviour : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable interactable;

    public void Start()
    {
        interactable.enabled = false;
    }

    public void becomeWeapon()
    {
        interactable.enabled = true;
    }
}
