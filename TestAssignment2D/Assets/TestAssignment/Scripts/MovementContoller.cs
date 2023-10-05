using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementContoller : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Transform finishLine;
    [SerializeField] private Vector2 playerSize;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;


    private void Awake()
    {
        maxY = finishLine.position.y - playerSize.y * 0.5f;
    }

    private void Update()
    {
        var movementVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        movementVector.Normalize();
        var deltaPos = speed * Time.deltaTime * movementVector;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + deltaPos.x, minX, maxX),
            Mathf.Clamp(transform.position.y + deltaPos.y, minY, maxY),
            0);
    }
}
