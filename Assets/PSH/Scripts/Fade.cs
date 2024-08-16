using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Fade : MonoBehaviour
{
    public float fadeDuration = 2.0f; // ������Ʈ�� ������ ��Ÿ������� �ɸ��� �ð�
    private Material material;
    private Color initialColor;
    private bool isFadingIn = false;
    private float fadeTime = 0f;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
            initialColor = material.color;
            // �ʱ⿡�� ������ �����ϰ� ����
            SetMaterialAlpha(0f);
        }
        else
        {
            Debug.LogError("Renderer component not found on this GameObject.");
        }
    }

    void Update()
    {
        if (isFadingIn)
        {
            fadeTime += Time.deltaTime;
            float normalizedTime = fadeTime / fadeDuration;
            float alpha = Mathf.Clamp01(normalizedTime);
            SetMaterialAlpha(alpha);

            // Fade�� �����ٸ� ����
            if (alpha >= 1f)
            {
                isFadingIn = false;
            }
        }
    }

    public void StartFading()
    {
        isFadingIn = true;
        fadeTime = 0f; // Fade ���� �ð� �ʱ�ȭ
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