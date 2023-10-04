using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private static GameObject staticBulletPrefab;
    private static List<GameObject> bullets = new();
    private static List<GameObject> freeBullets = new();
    private static Transform defaultTransform;


    private void Awake()
    {
        defaultTransform = transform;
        staticBulletPrefab = bulletPrefab;
    }

    public static GameObject GetBullet()
    {
        GameObject _bullet;

        if (freeBullets.Count > 0)
        {
            _bullet = freeBullets[0];
            _bullet.SetActive(true);
            freeBullets.Remove(_bullet);
        }
        else
        {
            _bullet = Instantiate(staticBulletPrefab, defaultTransform);
            _bullet.transform.SetParent(defaultTransform);
            bullets.Add(_bullet);
        }

        return _bullet;
    }

    public static void ReturnBullet(GameObject _bullet)
    {
        _bullet.SetActive(false);
        freeBullets.Add(_bullet);
    }

    public static void HideBullets()
    {
        foreach (GameObject _bullet in bullets)
        {
            ReturnBullet(_bullet);
        }
    }
}
