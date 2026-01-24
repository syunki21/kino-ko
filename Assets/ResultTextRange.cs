using System;
using UnityEngine;

[Serializable]
public class ResultTextPages
{
    public int min;
    public int max;

    [TextArea(3, 5)]
    public string[] pages;
}
