using UnityEngine;

public class Unit : MonoBehaviour
{
    public Transform currentCaptureSpot = null;
    public float unitSpeed = 1.0f;
    public enum Team{ Blue, Red, None };
    public Team team;
    public float punchForce = 1.0f;

    void Start()
    {
        CheckShortestCapturePoint();
    }

    void Update()
    {
        Vector3 VectorFromCurrentCaptureSpot = (currentCaptureSpot.position - gameObject.GetComponent<Transform>().position).normalized;
        Vector3 VectorFromCurrentCaptureSpotWithoutY = new Vector3(VectorFromCurrentCaptureSpot.x,
                                                                   0.0f,
                                                                   VectorFromCurrentCaptureSpot.z);

        transform.position += VectorFromCurrentCaptureSpotWithoutY * unitSpeed * Time.deltaTime;
        transform.LookAt(new Vector3(currentCaptureSpot.position.x, 1.0f, currentCaptureSpot.position.z));
    }

    public float shortestDistance = 10000.0f;
    public void CheckShortestCapturePoint()
    {
        foreach(Transform t in CaptureSpotsManager.instance.captureSpots)
        {
            if((gameObject.GetComponent<Transform>().position - t.position).magnitude < shortestDistance)
            {
                shortestDistance = (gameObject.GetComponent<Transform>().position - t.position).magnitude;
                currentCaptureSpot = t;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Unit>())
        {
            if(collision.gameObject.GetComponent<Unit>().team != team)
            {
                Punch(collision.gameObject);
            }
        }
    }

    private void Punch(GameObject gO)
    {
        Vector3 punchVectorNormalized = (gO.transform.position - gameObject.transform.position).normalized;

        gO.GetComponent<Rigidbody>().AddForce(punchForce * punchVectorNormalized, ForceMode.Impulse);
    }
}
