using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSourceSfx;
    public AudioClip clipCoin;
    public AudioClip clipGoldCoin;

    private void OnEnable()
    {
        Coin.coinCollected.AddListener( PlayCoinSfx );
        CoinGold.coinGoldCollected.AddListener( PlayCoinGoldSfx );
    }

    public void PlayCoinSfx( Coin coin )
    {
        audioSourceSfx.transform.position = coin.transform.position;
        audioSourceSfx.clip = clipCoin;
        audioSourceSfx.Play();
    }

    public void PlayCoinGoldSfx( CoinGold coin )
    {
        audioSourceSfx.transform.position = coin.transform.position;
        audioSourceSfx.clip = clipGoldCoin;
        audioSourceSfx.Play();
    }
}
