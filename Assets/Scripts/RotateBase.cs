using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RotateBase : MonoBehaviour
{
    private Dictionary<int, string> methots = new Dictionary<int, string>(); 
    public float speed;
    [SerializeField] private HealthController healthController;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        methots.Add(1, "FullRotate");
        methots.Add(2, "RotateLeft");
        methots.Add(3, "RotateRight");

        //StartCoroutine(FullRotate(1, 2,3));
        StartCoroutine(MidRotate());
    }

    private void Update()
    {
        if (speed <= 100)
        {
            speed += 0.005f;
        }
        else
        {
            speed = 60;
        }
    }

    public IEnumerator FullRotation()
    {
        int sign = Random.Range(0, 2);
        speed = sign == 0 ? speed : speed * -1;
        float startTime = 0;
        int timeToRotation = Random.Range(3, 10);
        while(healthController.health > 0)
        {
            startTime += Time.deltaTime;
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            yield return null;

            if (startTime > timeToRotation)
            {
                if(Enumerable.Range(2, 3).Contains((int)transform.localEulerAngles.z))
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    break;
                }
            }
        }

        StopCoroutine(nameof(FullRotation));
    }


    public IEnumerator MidRotate()
    {
        bool back = false;
        int sign = Random.Range(0, 2);
        speed = sign == 0 ? speed : speed * -1;
        while (healthController.health > 0)
        {
            if (!back)
            {
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);

                if (speed > 0)
                {
                    if (transform.localEulerAngles.z >= 60)
                    {
                        transform.localRotation = Quaternion.Euler(0, 0, 60);
                        yield return new WaitForSecondsRealtime(2f);
                    }
                }
                else
                {
                    if (360 - transform.localEulerAngles.z >= 60)
                    {
                        transform.localRotation = Quaternion.Euler(0, 0, 300);
                        yield return new WaitForSecondsRealtime(2f);
                    }
                }
            }

            yield return null;

            if (Mathf.Approximately(transform.localEulerAngles.z, 300) || Mathf.Approximately(transform.localEulerAngles.z,60))
            {
                back = true;
            }

            if (back)
            {
                transform.Rotate(Vector3.forward * -speed * Time.deltaTime);
                if (Enumerable.Range(2, 3).Contains((int)transform.localEulerAngles.z))
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    yield return new WaitForSecondsRealtime(2f);
                    break;
                }
            }
            
        }

        Debug.Log("Finish Coroutine");
        StopCoroutine(nameof(MidRotate));
    }
}
