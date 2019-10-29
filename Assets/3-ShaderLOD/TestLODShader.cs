using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLODShader : MonoBehaviour
{
    Shader shader;
    // Start is called before the first frame update
    void Start()
    {
        Material mat= GetComponent<MeshRenderer>().material;
        shader = mat.shader;
        shader.maximumLOD = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
