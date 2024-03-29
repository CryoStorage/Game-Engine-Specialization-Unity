using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private bool _canInteract;
    private PlayerInputHandler _playerInputHandler;
    private Interactable _currentInteractable;

    private void Start()
    {
        _playerInputHandler = GetComponent<PlayerInputHandler>();
        _playerInputHandler.InputActions.Player.Interact.performed += ctx => Interact();
    }
    
    private void Interact()
    {
        if(!_canInteract) return;
        _currentInteractable.Interact();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent<Interactable>(out var interactable)) return;
        _canInteract = true;
        _currentInteractable = interactable;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Interactable>()) return;
        _canInteract = false;
        
    }
}
