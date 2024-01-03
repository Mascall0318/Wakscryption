using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tablemanager : MonoBehaviour
{
    public TMP_InputField PX;
    public TMP_InputField PY;
    public TMP_InputField PZ;
    public TMP_InputField SX;
    public TMP_InputField SY;
    public TMP_InputField SZ;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(float.Parse(PX.text), float.Parse(PY.text), float.Parse(PZ.text));
        transform.localScale = new Vector3(float.Parse(SX.text), float.Parse(SY.text), float.Parse(SZ.text));
    }
}
