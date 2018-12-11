using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool instance;
    public static BulletPool Instance
    {
        get
        {
             return instance;
        }
    }

    [SerializeField] private BulletBehaviour bulletPrefab;
    [SerializeField] private int amountBulletsAtStart;

    private List<BulletBehaviour> availableBullets;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    private bool AraAvailableBullets
    {
        get
        {
            return availableBullets.Count > 0;
        }
    }

    private void Start()
    {
        InitStartBullets();
    }

    private void InitStartBullets()
    {
        availableBullets = new List<BulletBehaviour>();
        for (int i = 0; i < amountBulletsAtStart; i++)
        {
            BulletBehaviour newBullet = Instantiate(bulletPrefab, this.transform);
            newBullet.gameObject.SetActive(false);
            availableBullets.Add(newBullet);
        }
    }

    public BulletBehaviour GetBullet()
    {
        if (AraAvailableBullets)
        {
            BulletBehaviour bulletToUse = availableBullets[0];
            availableBullets.RemoveAt(0);
            return bulletToUse;
        }
        else
        {
            return CreateNewBulletInstance();
        }
    }

    private BulletBehaviour CreateNewBulletInstance()
    {
        BulletBehaviour newBullet = Instantiate(bulletPrefab, this.transform);
        return newBullet;
    }

    public void ReturnToPool(BulletBehaviour bullet)
    {
        bullet.gameObject.SetActive(false);
        availableBullets.Add(bullet);
    }
}
