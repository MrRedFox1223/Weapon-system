using UnityEngine;

[CreateAssetMenu(fileName = "Melee weapon", menuName = "Weapons/Melee/Melee weapon", order = 0)]
public class MeleeWeaponSO : WeaponSO
{
    [Range(0, 1)]
    [SerializeField] private float blockFactor;

    [Header("Configuration data")]
    [SerializeField] private SwingConfigurationSO slashConfig;

    public override void Attack()
    {
        if (Time.time > slashConfig.swingRate + lastUseTime)
        {
            lastUseTime = Time.time;
            Debug.Log("Slash " + damage + " " + damageType + " DMG");
        }
    }
}
