using UnityEngine;
using UnityEngine.InputSystem;

public class ColouringObject : MonoBehaviour
{
    public Color colour;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Renderer>().material.color = colour;
            Chop();
        }
    }


    public virtual void Chop()
    {
        Debug.Log("The " + gameObject.name + " fruit has been chopped.");
    }
}
