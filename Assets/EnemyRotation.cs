using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{

    [SerializeField] public Transform target; // The object to face
    public float rotationSpeed = 180f; // The speed of rotation

    private Quaternion targetRotation;
    private Quaternion initialRotation;
    private float delayTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial rotation of the object
        initialRotation = transform.rotation;

        // Set delay timer to 0
        delayTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        initialRotation = transform.rotation;
        Quaternion directionToTarget = target.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);

        if (initialRotation != targetRotation)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                dashRotateToTarget();
            }
            else
            {
                RotateToTarget();
            }
            
        }
    }

    void RotateToTarget()
    {
        delayTimer += Time.deltaTime;
        Debug.Log(delayTimer);

        if(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.A))
        {
            delayTimer = 0;
        }
        if(delayTimer >= 0.33)
        {
            //Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            //transform.rotation = newRotation;
            transform.rotation = Quaternion.RotateTowards(initialRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    void dashRotateToTarget()
    {
        delayTimer = 0;
        delayTimer += Time.deltaTime;
        Debug.Log(delayTimer);

        if (delayTimer >= 1)
        {
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = newRotation;
        }
    }
}
