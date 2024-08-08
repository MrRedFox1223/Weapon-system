using System;

public class InputEvents
{
    public event Action onUsePressed;
    public event Action onReloadPressed;
    public event Action onChangePressed;


    public void UsePressed()
    {
        onUsePressed?.Invoke();
    }

    public void RealodPressed()
    {
        onReloadPressed?.Invoke();
    }

    public void ChangePressed()
    {
        onChangePressed?.Invoke();
    }
}
