using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {

    [SerializeField] private float health;
    private float currentHealth;

    public int keysAmount;

    public SpriteRenderer m_roof;
    public SpriteRenderer m_back;
    public SpriteRenderer m_front;
    public SpriteRenderer m_backDoor;
    public SpriteRenderer m_frontDoor;

    public Image healthImage;

    public GameObject canvasGame;

    public void LoseHealth(float amountOfDamage)
    {
        StartCoroutine(DecreaseHealth(amountOfDamage));
    }

    IEnumerator DecreaseHealth(float amountOfDamage)
    {
        health -= amountOfDamage;
        while(health < currentHealth)
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
            canvasGame.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bullet"))
        {
            LoseHealth(other.GetComponent<BulletBehaviour>().damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Key")) {
            keysAmount++;
            Destroy(other.gameObject);
        }
        if (other.tag.Equals("HouseBack") || other.tag.Equals("BackDoor"))
        {
            ControlSpriteStates(false, false, true, true, false);
        }
        if (other.tag.Equals("HouseFront") || other.tag.Equals("FrontDoor"))
        {
            ControlSpriteStates(true, true, false, false, false);
        }
        if (other.tag.Equals("HouseInside"))
        {
            ControlSpriteStates(true, true, true, true, false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("HouseBack"))
        {
            ControlSpriteStates(true, true, true, true, true);
        }
        if (other.tag.Equals("HouseFront"))
        {
            ControlSpriteStates(true, true, true, true, true);
        }
        if (other.tag.Equals("HouseInside"))
        {
            ControlSpriteStates(true, true, true, true, true);
        }
    }

    private void ControlSpriteStates(bool back, bool backDoor, bool front, bool frontDoor, bool roof)
    {
        m_back.enabled = back;
        m_backDoor.enabled = backDoor;
        m_front.enabled = front;
        m_frontDoor.enabled = frontDoor;
        m_roof.enabled = roof;
    }
}
