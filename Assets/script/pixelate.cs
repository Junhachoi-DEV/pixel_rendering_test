using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//출처 https://www.youtube.com/watch?v=5rMkh9sl2bM&t=16s

//에디터에서도 실행 가능하게 해줌
[ExecuteInEditMode]
public class pixelate : MonoBehaviour
{
    [Range(1, 100)] public int pixelate_cut; //픽셀 갯수

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        source.filterMode = FilterMode.Point; //랜더링 되는거 point로 후처리 하겠다는 뜻

        //임시 랜더링 생성
        RenderTexture result_texture = RenderTexture.GetTemporary(source.width / pixelate_cut, source.height / pixelate_cut, 0, source.format);
        result_texture.filterMode = FilterMode.Point;
        
        Graphics.Blit(source, result_texture); // 소스를 리절트 택스쳐에 그리겠다는 뜻
        Graphics.Blit(result_texture, destination); //리절트 텍스쳐를 destination에 그리겟다.

        //임시 랜더링 해제
        RenderTexture.ReleaseTemporary(result_texture);
    }
}
