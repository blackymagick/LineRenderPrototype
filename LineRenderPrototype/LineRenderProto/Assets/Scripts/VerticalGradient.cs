using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalGradient : MonoBehaviour
{
    public Color topColor;
    public Color bottomColor;
    public int textureHeight = 256;

    void Start()
    {
        Texture2D texture = new Texture2D(1, textureHeight);

        for (int y = 0; y < textureHeight; y++)
        {
            float t = Mathf.InverseLerp(0, textureHeight - 1, y);
            Color color = Color.Lerp(topColor, bottomColor, t);
            texture.SetPixel(0, y, color);
        }

        texture.Apply();

        GetComponent<Renderer>().material.mainTexture = texture;
    }

}
