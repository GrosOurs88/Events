using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSourceSfx;

    private void OnEnable()
    {
        Coin.coinCollected.AddListener( PlayCoinSfx );
    }

    public void PlayCoinSfx(Coin coin)
    {
        audioSourceSfx.transform.position = coin.transform.position;
        audioSourceSfx.Play();
    }
}
