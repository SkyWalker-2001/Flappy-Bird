using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    // mesh render of background materiaal
    private MeshRenderer meshRenderer;

    // speed in which our background move
    public float animatioSpeed = 1f;
 
    // get Componemt of mesh render by using Awake() FN

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Chsnge Screen per frame
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animatioSpeed * Time.deltaTime, 0f);
    }

}
