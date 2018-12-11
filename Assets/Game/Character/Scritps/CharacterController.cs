using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [SerializeField] private float health;
    public int keysAmount;

    public SpriteRenderer m_roof;
    public SpriteRenderer m_back;
    public SpriteRenderer m_front;
    public SpriteRenderer m_backDoor;
    public SpriteRenderer m_frontDoor;

    private bool canBeAttacked;
    private bool CanBeAttacked
    {
        get
        {
            return canBeAttacked;
        }
    }

    public void LoseHealth(float amountOfDamage)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Key")) {
            keysAmount++;
            Destroy(other.gameObject);
        }
        if (other.tag.Equals("HouseBack"))
        {
            ControlSpriteStates(false, false, true, true, false);
        }
        if (other.tag.Equals("HouseFront") )
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
