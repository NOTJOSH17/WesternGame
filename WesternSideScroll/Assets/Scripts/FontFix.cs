using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontFix : MonoBehaviour
{

    public Font[] fonts;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < fonts.Length; i++)
            {
                fonts[i].material.mainTexture.filterMode = FilterMode.Point;
            }
    }
}
