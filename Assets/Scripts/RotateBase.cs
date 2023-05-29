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
    [SerializeField] GameObject player;
    private bool canCallCorroutine = true;
    // Start is called before the first frame update
    void Awake()
    {
        methots.Add(0, "FullRotation");
        methots.Add(1, "PersuitPlayer");
        methots.Add(2, "MidRotate");

        StartCoroutine(StartBaseMethots());

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

    public IEnumerator PersuitPlayer()
    {
        canCallCorroutine = false;
        float startTime = 0;
        int timeToRotation = Random.Range(3, 10);
        bool stopPersuing = false;
        
        while (healthController.health > 0)
        {
            startTime += Time.deltaTime;
            if (!stopPersuing)
            {
                if (player!=null)
                {
                    var targetPos = player.transform.position;
                    Vector3 direction = targetPos - transform.position;
                    direction.Normalize();
                    float z_rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, z_rot - 90);
                }
            }
                     
            yield return null;
            if (startTime > timeToRotation)
            {
                stopPersuing = true;
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);
                if (Enumerable.Range(2, 3).Contains((int)transform.localEulerAngles.z))
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    break;
                }
            }
        }

        StopCoroutine(nameof(PersuitPlayer));
        canCallCorroutine = true;
    }

    public IEnumerator FullRotation()
    {
        canCallCorroutine = false;
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
        canCallCorroutine = true;
    }

    public IEnumerator MidRotate()
    {
        canCallCorroutine = false;
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
       
        StopCoroutine(nameof(MidRotate));
        canCallCorroutine = true;
    }

    public IEnumerator StartBaseMethots()
    {
        while(healthController.health > 0)
        {
            int indexMethod = Random.Range(0, methots.Count);

            if (canCallCorroutine)
            {
                yield return new WaitForSeconds(2);
                StartCoroutine(methots[indexMethod]);
                Debug.Log(methots[indexMethod]);
            }

            yield return null;
        }

        StopAllCoroutines();
    }
}
