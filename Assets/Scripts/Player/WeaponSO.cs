using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;

    [Header("Combat")]
    public int Damage = 1;
    public float FireRate = 0.5f;
    public int MagazineSize = 12;
    public bool IsAutomatic = false;

    [Header("Effects")]
    public GameObject HitVFXPrefab;

    [Header("Zoom")]
    public bool CanZoom = false;
    public float ZoomAmount = 10f;
    public float ZoomRotationSpeed = 0.3f;

    [Header("Audio")]
    public AudioClip ShootSFX;
    [Range(0f, 1f)] public float ShootVolume = 1f;
    [Range(0.5f, 1.5f)] public float ShootPitch = 1f;

}
