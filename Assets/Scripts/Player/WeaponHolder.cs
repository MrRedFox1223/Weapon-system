using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponHolder : MonoBehaviour
{
    [Header("Weapon list")]
    [SerializeField] private List<WeaponSO> weapons;

    [Header("References")]
    [SerializeField] private Image weaponImage;
    [SerializeField] private TextMeshProUGUI weaponName;

    private int activeWeaponIndex;
    private WeaponSO activeWeapon;

    private void Start()
    {
        weaponImage = GameObject.Find("WeaponImage").GetComponent<Image>();
        weaponName = GameObject.Find("WeaponName").GetComponent<TextMeshProUGUI>();

        activeWeaponIndex = 0;
        SpawnWeapon();
    }

    private void SpawnWeapon()
    {
        activeWeapon = weapons[activeWeaponIndex];

        weaponImage.sprite = activeWeapon.spritePrefab.GetComponent<SpriteRenderer>().sprite;
        weaponName.text = activeWeapon.weaponName;

        activeWeapon.Spawn();
    }

    public void UseWeapon()
    {
        activeWeapon.Attack();
    }

    public void ReloadWeapon()
    {
        if (activeWeapon.GetType() == typeof(RangedWeaponSO))
        {
            RangedWeaponSO rangedActiveWeapon = (RangedWeaponSO)activeWeapon;
            rangedActiveWeapon.Reload();
        }
    }

    public void ChangeWeapon()
    {
        //Looping through weapons
        if (activeWeaponIndex + 1 >= weapons.Count)
        {
            activeWeaponIndex = 0;
        }
        else
            activeWeaponIndex++;

        SpawnWeapon();
    }
}
