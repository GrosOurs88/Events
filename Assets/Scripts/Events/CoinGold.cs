using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CoinGold : MonoBehaviour
{
    public static UnityEvent<CoinGold> coinGoldCollected = new UnityEvent<CoinGold>();

    private void OnCollisionEnter( Collision collision )
    {
        if( collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        coinGoldCollected.Invoke(this);
        Destroy( gameObject );
    }
}
