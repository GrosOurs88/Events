using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSourceSfx;
    

    public void PlayCoinSfx()
    {
        audioSourceSfx.Play();
    }
}
