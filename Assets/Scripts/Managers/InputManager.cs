using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private static InputManager _instance;

    public static InputManager instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void PlayerUsePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameEventsManager.instance.inputEvents.UsePressed();
        }
    }

    public void PlayerReloadPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameEventsManager.instance.inputEvents.RealodPressed();
        }
    }

    public void PlayerChangePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameEventsManager.instance.inputEvents.ChangePressed();
        }
    }
}
