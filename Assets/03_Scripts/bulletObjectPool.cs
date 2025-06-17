using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    [SerializeField] List<BulletStorageBox> _bulletStorageBox = new List<BulletStorageBox>();
    [SerializeField] int _storageSpace;
    [SerializeField] BulletStorageBox _bulletPrefab;
    [SerializeField] Transform _bulletBox;
    BulletStorageBox _generation;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        BulletSpawn();
    }

    // Bullet Create
    public void BulletSpawn()
    {
        for(int i = 0; i < _storageSpace; i++)
        {
            _generation = Instantiate(_bulletPrefab, _bulletBox);
            _generation.gameObject.SetActive(false);
            _bulletStorageBox.Add(_generation);
        }
    }
    
    // Bullet Borrow
    public BulletStorageBox BulletBorrow(Vector3 position, Quaternion rotation)
    {
        if(_bulletStorageBox.Count == 0)
        {
            return Instantiate(_bulletPrefab, position, rotation, _bulletBox);
        }

        _generation = _bulletStorageBox[_bulletStorageBox.Count - 1];
        _bulletStorageBox.RemoveAt(_bulletStorageBox.Count - 1);

        _generation.transform.position = position;
        _generation.transform.rotation = rotation;
        _generation.gameObject.SetActive(true);
        _generation._bulletPool = this;

        return _generation;
    }

    public void BulletReceive(BulletStorageBox generation)
    {
        generation.gameObject.SetActive(false);
        _bulletStorageBox.Add(generation);
    }
}
