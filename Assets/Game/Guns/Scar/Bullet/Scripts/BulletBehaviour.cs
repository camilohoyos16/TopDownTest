using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    private Rigidbody m_RigidBody;
    public int damage;
    public GameObject particles;

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    public void Shoot(float bulletVelocity, Transform direction)
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        m_RigidBody.velocity = (direction.forward + Vector3.right * 0.4f) * bulletVelocity * Time.deltaTime;
        gameObject.transform.LookAt(m_RigidBody.velocity);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.tag.Equals("Key"))
        {
            Instantiate(particles, transform.position, transform.rotation);
            ReturnToPool();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.tag.Equals("Key"))
        {
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        m_RigidBody.velocity = Vector3.zero;
        BulletPool.Instance.ReturnToPool(this);
    }
}
