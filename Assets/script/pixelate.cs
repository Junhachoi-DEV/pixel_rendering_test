using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ó https://www.youtube.com/watch?v=5rMkh9sl2bM&t=16s

//�����Ϳ����� ���� �����ϰ� ����
[ExecuteInEditMode]
public class pixelate : MonoBehaviour
{
    [Range(1, 100)] public int pixelate_cut; //�ȼ� ����

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        source.filterMode = FilterMode.Point; //������ �Ǵ°� point�� ��ó�� �ϰڴٴ� ��

        //�ӽ� ������ ����
        RenderTexture result_texture = RenderTexture.GetTemporary(source.width / pixelate_cut, source.height / pixelate_cut, 0, source.format);
        result_texture.filterMode = FilterMode.Point;
        
        Graphics.Blit(source, result_texture); // �ҽ��� ����Ʈ �ý��Ŀ� �׸��ڴٴ� ��
        Graphics.Blit(result_texture, destination); //����Ʈ �ؽ��ĸ� destination�� �׸��ٴ�.

        //�ӽ� ������ ����
        RenderTexture.ReleaseTemporary(result_texture);
    }
}
