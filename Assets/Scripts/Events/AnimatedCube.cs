using UnityEngine;

public class AnimatedCube : MonoBehaviour
{


    private void OnEnable()
    {
        Coin.coinCollected.AddListener( Animate );
        CoinGold.coinGoldCollected.AddListener( ChangeSize );
    }

    private void OnDisable()
    {
        Coin.coinCollected.RemoveListener( Animate );   
    }

    private void ChangeSize(CoinGold coinGold)
    {
        gameObject.transform.localScale *= 0.95f; 
    }

    private void Animate(Coin coin)
    {
        gameObject.GetComponent<Animator>().SetTrigger( "Jump" );
    }
}
