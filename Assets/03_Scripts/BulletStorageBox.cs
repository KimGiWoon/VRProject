using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStorageBox : MonoBehaviour
{
    [SerializeField] float _settingTime;
    public BulletObjectPool _bulletPool;
    float _returnTime;

    private void OnEnable()
    {
        _returnTime = _settingTime;
    }

    private void Update()
    {
        _returnTime -= Time.deltaTime;
        if(_returnTime <= 0)
        {
            BulletReturn();
        }
    }

    public void BulletReturn()
    {
        if(_bulletPool == null)
        {
            Destroy(gameObject);
        }
        else
        {
            _bulletPool.BulletReceive(this);
        }        
    }
}
