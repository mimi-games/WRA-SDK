using DependentObjects.Interfaces;
using UnityEngine;

namespace Character.Interactions
{
    public class InteractionController3D : InteractionControllerBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Interaction"))
                return;
            interactables.Add(other.GetComponent<IInteractable>());
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Interaction"))
                return;
            RemoveInteractables(interactables.FindIndex(ctg => ctg == other.GetComponent<IInteractable>()));
        }
    }
}
