using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CaptureSpotsManager : MonoBehaviour
{
    public List<Transform> captureSpots = new List<Transform>();

    public static CaptureSpotsManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
