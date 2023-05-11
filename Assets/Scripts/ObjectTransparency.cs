using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransparency : MonoBehaviour
{
    private float transparency = 0.1f;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Material material =  renderer.material;
            
            material.SetFloat("_Mode", 2);
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.EnableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = 3000;

            Color color = material.color;
            color.a = transparency;
            material.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
