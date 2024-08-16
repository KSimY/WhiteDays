using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FadeOut : MonoBehaviour
{
    public float fadeDuration = 2.0f; // ������Ʈ�� ������ ���������� �ɸ��� �ð�
    private Material material;
    private Color initialColor;
    private bool isFadingOut = false;
    private float fadeTime = 0f;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isFadingOut = true;
            fadeTime = 0f; // Fade ���� �ð� �ʱ�ȭ
        }

        if (isFadingOut)
        {
            fadeTime += Time.deltaTime;
            float normalizedTime = fadeTime / fadeDuration;
            float alpha = Mathf.Clamp01(1 - normalizedTime); // ���� ���� 1���� 0���� ���ҽ�Ŵ
            SetMaterialAlpha(alpha);

            // Fade�� �����ٸ� ����
            if (alpha <= 0f)
            {
                isFadingOut = false;
            }
        }
    }

    private void SetMaterialAlpha(float alpha)
    {
        Color color = material.color;
        color.a = alpha;
        material.color = color;

        // Rendering Mode�� Transparent���� Ȯ��
        if (material.shader.name == "Universal Render Pipeline/Lit")
        {
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.EnableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        }
    }
}