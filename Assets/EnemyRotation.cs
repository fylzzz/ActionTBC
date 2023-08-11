using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{

    [SerializeField] public Transform target; // The object to face
    public float rotationSpeed = 0.5f; // The speed of rotation (useless apparently)

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
        // Store current location and target location
        initialRotation = transform.rotation;
        targetRotation = target.transform.rotation;

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
        // Begin counting delayTimer (even though it hasn't been reset yet, what was i thinking here?)
        delayTimer += Time.deltaTime;
        Debug.Log(delayTimer);

        if(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.A))
        {
            // why is this in an obvious if statement?
            delayTimer = 0;
        }
        if(delayTimer >= 0.33)
        {
            // Lerp from initial to target over rotationSpeed seconds (or however fast you like because Unity doesn't listen?)
            Quaternion newRotation = Quaternion.Lerp(initialRotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = newRotation;
            
        }
    }
    void dashRotateToTarget()
    {
        // same as RotateToTarget but i reset the timer first this time (yay good job)
        delayTimer = 0;
        delayTimer += Time.deltaTime;
        Debug.Log(delayTimer);

        if (delayTimer >= 1)
        {
            // do the same thing as RotateToTarget but take longer before it happens
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = newRotation;
        }
    }
}
