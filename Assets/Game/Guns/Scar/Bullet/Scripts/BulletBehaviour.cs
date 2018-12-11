using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    private Rigidbody m_RigidBody;

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    public void Shoot(float bulletVelocity, Transform direction)
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        m_RigidBody.velocity = direction.forward * bulletVelocity * Time.deltaTime;
        gameObject.transform.LookAt(m_RigidBody.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            
        }

        ReturnToPool();
    }

    private void ReturnToPool()
    {
        m_RigidBody.velocity = Vector3.zero;
        BulletPool.Instance.ReturnToPool(this);
    }
}
