using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlink : MonoBehaviour
{
    public void URL(string url)
    {
        Application.OpenURL(url);
    }
}
