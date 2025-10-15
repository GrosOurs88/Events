using UnityEngine;

public class Cours1_Exo2_1_Dice : MonoBehaviour
{
    public Cours1_Exo2_1 managerScript;

    [SerializeField]
    private bool asBeenLaunched = false;
    private bool asBeenCounted = false;

    private Rigidbody rb;

    public float timeBeforeValidating = 2.0f;
    private float currentTime = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(asBeenLaunched && !asBeenCounted)
        {
            if(rb.linearVelocity.magnitude < 0.1f)
            {
                currentTime += Time.deltaTime;

                if(currentTime >= timeBeforeValidating)
                {
                    CountDice();
                    asBeenCounted = true;
                }
            }
            currentTime = 0;
        }
    }

    private void CountDice()
    {
        float angle = 0.0f;
        
      //  (transform.for)
    }
}
