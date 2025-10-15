using UnityEngine;

public class ColouringObjectChild : ColouringObject
{

    public override void Chop()
    {
        Debug.Log("The " + gameObject.name + " fruit has been chopped.");
        Debug.Log("But " + gameObject.name + " is also smaller");
    }
}
