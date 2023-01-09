using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class pixelate_obj : MonoBehaviour
{
    public Material pixel_material;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //source.filterMode = FilterMode.Point;
        Graphics.Blit(source, destination, pixel_material);
    }
}
