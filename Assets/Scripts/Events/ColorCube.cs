using Unity.VisualScripting;
using UnityEngine;

public class ColorCube : MonoBehaviour
{
    void OnEnable()
    {
        Coin.coinCollected.AddListener( ChangeColor );
    }

    private void OnDisable()
    {
        Coin.coinCollected.RemoveListener( ChangeColor );
    }

    private void ChangeColor(Coin coin)
    {
        Color newColor = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        gameObject.GetComponent<MeshRenderer>().material.color = newColor;
    }
}
