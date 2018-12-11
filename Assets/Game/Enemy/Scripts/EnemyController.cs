using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {


    [SerializeField] private float health;
    private float currentHealth;

    [HideInInspector] public NavMeshAgent m_NavMeshAgent;

    public AudioSource deathAudioSOurce;

    // Use this for initialization
    void Awake () {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
	}

    public Image healthImage;
    public GameObject healthGO;


    public void LoseHealth(float amountOfDamage)
    {
        StartCoroutine(DecreaseHealth(amountOfDamage));
    }

    IEnumerator DecreaseHealth(float amountOfDamage)
    {
        health -= amountOfDamage;
        while (health < currentHealth)
        {
            yield return null;
            currentHealth -= Time.deltaTime;
            healthImage.fillAmount = currentHealth / 100;
        }
        currentHealth = health;
    }

    private void Update()
    {
        if (currentHealth < 0)
        {
            healthGO.SetActive(false);
            GameMenu.instance.enemiesAlive--;
            deathAudioSOurce.Play();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bullet"))
        {
            LoseHealth(other.GetComponent<BulletBehaviour>().damage);
        }
    }

}
