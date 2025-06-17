using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet : MonoBehaviour
{
    [SerializeField] Transform _muzzlePoint;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject _FirePrefab;
    [SerializeField] BulletObjectPool _bulletPool;
    [SerializeField] int _bulletSpeed;
    [SerializeField] XRSocketInteractor _Magazine;

    bool _isReload = false;

    // Check Magazine Engagement
    public void MagerzineLoad()
    {
        _isReload = true;
    }

    // Check Magazine Engagement
    public void MagerzineUnLoad()
    {
        _isReload = false;
    }

    // Bullet Fire Action
    public void Fire()
    {
        if(_isReload)
        {
            BulletStorageBox _bullet = _bulletPool.BulletBorrow(_muzzlePoint.position, _muzzlePoint.rotation);
            Rigidbody _bulletRigid = _bullet.GetComponent<Rigidbody>();
            Instantiate(_FirePrefab, _muzzlePoint.position, _muzzlePoint.rotation);
            _bulletRigid.AddForce(_muzzlePoint.forward * _bulletSpeed, ForceMode.Impulse);
        }
    }

}
