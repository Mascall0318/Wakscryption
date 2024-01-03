using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frametest : MonoBehaviour
{
    [SerializeField] int frame = 60;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = frame; 
    }
}
