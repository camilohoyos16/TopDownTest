using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShootingState : MonoBehaviour {
    [SerializeField] private float coolDownTimer;
    [SerializeField] private float shootVelocity;
    [SerializeField] private GameObject spawnBulletsPoint;
    public bool canShoot;

    private bool isFirstTime;

    public Action onStartShooting;
    public Action onStopShooting;

    private void Awake()
    {
        isFirstTime = true;
    }

    public void OnEnable()
    {
        canShoot = true;
    }

    private void OnDisable()
    {
        if (isFirstTime)
        {
            isFirstTime = false;
            return;
        }
        StopShooting();
    }

    public void Update()
    {
        if (CharacterStatesManager.CharacterStateCurrent == CharacterStates.shooting || CharacterStatesManager.CharacterStateCurrent == CharacterStates.runShooting)
        {
            Shoot();
        }
    }

    protected void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            if(onStartShooting != null)
            {
                onStartShooting();
            }
            BulletBehaviour bulletToShoot = BulletPool.Instance.GetBullet();
            bulletToShoot.gameObject.SetActive(true);
            bulletToShoot.transform.position = spawnBulletsPoint.transform.position;
            bulletToShoot.Shoot(shootVelocity, spawnBulletsPoint.transform);
            StartCoroutine(CoolDownShooting());
        }
    }

    IEnumerator CoolDownShooting()
    {
        yield return new WaitForSeconds(coolDownTimer);
        canShoot = true;
    }

    private void StopShooting()
    {
        canShoot = false;
        StopAllCoroutines();
        if (onStopShooting != null)
        {
            onStopShooting();
        }
    }
}
