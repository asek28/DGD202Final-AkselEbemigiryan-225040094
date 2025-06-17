using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMover))]
public class InputHandler : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputActionAsset inputActionsAsset;

    private PlayerMover _mover;
    private InputAction _moveAction;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();

        // "Gameplay" action map'inden "Move" action'ýný al
        var gameplayMap = inputActionsAsset.FindActionMap("Gameplay", throwIfNotFound: true);
        _moveAction = gameplayMap.FindAction("Move", throwIfNotFound: true);
    }

    private void OnEnable()
    {
        _moveAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
    }

    private void Update()
    {
        // Vector2 girdisini oku
        Vector2 inputVector = _moveAction.ReadValue<Vector2>();
        _mover.Move(inputVector);
    }
}
