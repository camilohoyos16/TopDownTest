using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public Transform character;
    Vector3 nextCameraPosition;
    Vector3 smoothedMovement;

    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float distanceView;

    private void Start()
    {
        nextCameraPosition.y = distanceView;
    }

    void Update()
    {
        nextCameraPosition.x = character.position.x + offset.x;
        nextCameraPosition.z = character.position.z + offset.z;
        smoothedMovement = Vector3.Lerp(transform.position, nextCameraPosition, smoothSpeed);
        transform.position = smoothedMovement;
    }

}