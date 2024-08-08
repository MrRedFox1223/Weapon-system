using UnityEngine;

[CreateAssetMenu(fileName = "Ranged weapon", menuName = "Weapons/Ranged/Ranged weapon", order = 0)]
public class RangedWeaponSO : WeaponSO
{
    [SerializeField] private int ammoLimit;
    [SerializeField] private int ammo;

    [Header("Configuration data")]
    [SerializeField] private ShootConfigurationSO shootConfig;

    public override void Attack()
    {
        if (Time.time > shootConfig.fireRate + lastUseTime)
        {
            lastUseTime = Time.time;

            if (ammo > 0)
            {
                Debug.Log("Pew " + damage + " " + damageType + " DMG" );
                ammo--;
            }
            else
            {
                Debug.Log("Click");
            }
        }
    }

    public void Reload()
    {
        Debug.Log("Reloading");
        ammo = ammoLimit;
    }
}
