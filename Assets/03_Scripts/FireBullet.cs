using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBullet : MonoBehaviour
{
    [SerializeField] Transform _muzzlePoint;
    [SerializeField] GameObject _bulletPrefab;
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
            GameObject _bullet = Instantiate(_bulletPrefab, _muzzlePoint.position, Quaternion.identity);
            _bullet.GetComponent<Rigidbody>().AddForce(_muzzlePoint.forward * _bulletSpeed, ForceMode.Impulse);
        }
    }

}
