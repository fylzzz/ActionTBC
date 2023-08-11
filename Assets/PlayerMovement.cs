using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private GameObject target; // enemy object
    private float degreesPerSecond = 90; // speed of rotation (Unity respects it for RotateAround but not Lerp for some reason)
    public static float stamina = 3; // dash stamina (why didnt i make this a ScriptableObject? or at least put it in GameStateManager and reference it?)
    private float lastPlayerDirection; // so the player dashes in the same direction they were moving
    private Quaternion targetRotation; // this is never used - what?

    // Start is called before the first frame update
    void Start()
    {
        stamina = 3; // why did i define this again?
        lastPlayerDirection = 0; // why didnt i define this b4?
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            // rotate anti-clockwise around target degreesPerSecond
            transform.RotateAround(target.transform.position, new Vector3(0, -1, 0), degreesPerSecond * Time.deltaTime);
            lastPlayerDirection = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            // rotate clockwise around target degreesPerSecond
            transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), degreesPerSecond * Time.deltaTime);
            lastPlayerDirection = 2;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)&&stamina > 0) // make sure stamina isnt 0
        {
            if (lastPlayerDirection == 0)
            {
                // pick a random direction if there isnt one already
                lastPlayerDirection = Random.Range(1, 3);
                StartCoroutine(Dash(0.33f, 90)); // do the thing
            }
            else
            {
                StartCoroutine(Dash(0.33f, 90)); // do the thing
            }
        }
    }

    IEnumerator Dash(float dashTimer, float degreesPerSecond)
    {
        float dashSpeed = degreesPerSecond / dashTimer;
        if (lastPlayerDirection == 1)
        {
            stamina --; // decrease stamina
            for (float dashTime = 0f; dashTime < dashTimer; dashTime += Time.deltaTime)
            {
                // rotate anti-clockwise but make it fast
                transform.RotateAround(target.transform.position, new Vector3(0, -1, 0), dashSpeed * Time.deltaTime);
                yield return null;
            }
        }
        if (lastPlayerDirection == 2)
        {
            stamina--; // decrease stamina
            for (float dashTime = 0f; dashTime < dashTimer; dashTime += Time.deltaTime)
            {
                // rotate clockwise but make it fast
                transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), dashSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
