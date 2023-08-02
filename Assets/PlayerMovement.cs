using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private GameObject target;
    private float degreesPerSecond = 90;
    public static float stamina = 3;
    private float lastPlayerDirection;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        stamina = 3;
        lastPlayerDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(target.transform.position, new Vector3(0, -1, 0), degreesPerSecond * Time.deltaTime);
            lastPlayerDirection = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), degreesPerSecond * Time.deltaTime);
            lastPlayerDirection = 2;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)&&stamina > 0)
        {
            if (lastPlayerDirection == 0)
            {
                lastPlayerDirection = Random.Range(1, 3);
                StartCoroutine(Dash(0.33f, 90));
            }
            else
            {
                StartCoroutine(Dash(0.33f, 90));
            }
        }
    }

    IEnumerator Dash(float dashTimer, float degreesPerSecond)
    {
        float dashSpeed = degreesPerSecond / dashTimer;
        if (lastPlayerDirection == 1)
        {
            stamina --;
            for (float dashTime = 0f; dashTime < dashTimer; dashTime += Time.deltaTime)
            {
                transform.RotateAround(target.transform.position, new Vector3(0, -1, 0), dashSpeed * Time.deltaTime);
                yield return null;
            }
        }
        if (lastPlayerDirection == 2)
        {
            stamina--;
            for (float dashTime = 0f; dashTime < dashTimer; dashTime += Time.deltaTime)
            {
                transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), dashSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
