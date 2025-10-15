using UnityEngine;

public class Cours1_Exo1_1 : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 direction = new Vector3();

    private int currentFrame = 0;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        currentFrame += 1;

        if(currentFrame >= 50)
        {
            ChangeColor();
            currentFrame = 0;
        }
    }

    private void ChangeColor()
    {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

    private void OnDisable()
    {
        print(gameObject.name + " " + "est désactivé");
    }
}
