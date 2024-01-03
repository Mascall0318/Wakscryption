using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sdgsdsdrh : MonoBehaviour
{
    public GameObject targetPosition;
    public GameObject me;
    void Update()
    {
        me.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, 0.001f);
    }
}
