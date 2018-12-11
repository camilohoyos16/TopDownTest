using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour {

    public Animator m_Animator;
    public bool isOpen;
    public GameObject obstacleDoor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")){
            OpenDoor(other);
        }
    }

    private void OpenDoor(Collider other)
    {
        CharacterController characterController = other.GetComponent<CharacterController>();
        if (!isOpen)
        {
            if (characterController.keysAmount > 0 )
            {
                isOpen = true;
                Destroy(obstacleDoor);
                characterController.keysAmount--;
                m_Animator.SetTrigger("openDoor");
            }
            else
            {
                //wrong sound
            }
        }
        else
        {
            m_Animator.SetTrigger("openDoor");
        }
    }
}
