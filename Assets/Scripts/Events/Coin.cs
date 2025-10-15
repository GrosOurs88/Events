using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public static UnityEvent<Coin> coinCollected = new UnityEvent<Coin>();

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

    virtual public void Collect()
    {
        coinCollected.Invoke(this);
        Destroy(gameObject);
    }  
}