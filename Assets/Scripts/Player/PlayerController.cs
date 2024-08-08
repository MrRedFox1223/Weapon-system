using UnityEngine;

[RequireComponent(typeof(WeaponHolder))]
public class PlayerController : MonoBehaviour
{
    private WeaponHolder weaponHolder;

    private void Start()
    {
        weaponHolder = this.gameObject.GetComponent<WeaponHolder>();
    }

    private void OnEnable()
    {
        GameEventsManager.instance.inputEvents.onUsePressed += UseWeapon;
        GameEventsManager.instance.inputEvents.onReloadPressed += ReloadWeapon;
        GameEventsManager.instance.inputEvents.onChangePressed += ChangeWeapon;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.inputEvents.onUsePressed -= UseWeapon;
        GameEventsManager.instance.inputEvents.onReloadPressed -= ReloadWeapon;
        GameEventsManager.instance.inputEvents.onChangePressed -= ChangeWeapon;
    }

    private void UseWeapon()
    {
        weaponHolder.UseWeapon();
    }

    private void ReloadWeapon()
    {
        weaponHolder.ReloadWeapon();
    }

    private void ChangeWeapon()
    {
        weaponHolder.ChangeWeapon();
    }
}
