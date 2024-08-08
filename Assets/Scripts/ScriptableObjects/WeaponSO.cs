using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

abstract public class WeaponSO : ScriptableObject
{
    [Header("Basic data")]
    public string weaponName;
    [SerializeField] private AssetReferenceGameObject spriteAddressablePrefab;

    [Header("UI data")]
    public Vector2 UIPosition;
    public GameObject spritePrefab;

    [Header("Combat data")]
    public DamageType damageType;
    public float damage;

    protected float lastUseTime;

    private void OnEnable()
    {
        spriteAddressablePrefab.LoadAssetAsync().Completed += OnAddressableInstantiate;
    }

    private void OnAddressableInstantiate(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
            spritePrefab = handle.Result;
    }

    public void Spawn()
    {
        // In editor lastUseTime will not be properly reset, so doing it manually
        lastUseTime = 0f;
    }

    abstract public void Attack();
}
