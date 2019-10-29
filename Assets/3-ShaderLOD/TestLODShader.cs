using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLODShader : MonoBehaviour
{
    Shader shader;
    Transform MainCameraTr;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        MainCameraTr = Camera.main.gameObject.transform;
        tr = this.transform;
        Material mat= GetComponent<MeshRenderer>().material;
        shader = mat.shader;
        shader.maximumLOD = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,10*Mathf.Sin(Time.time)*Time.deltaTime);
        float ZDist = CalculateObjToCameraByZ();
        if (ZDist < 15)
        {
            shader.maximumLOD = 300;
        }
        else if (ZDist >= 15 && ZDist <= 25)
        {
            shader.maximumLOD = 200;
        }
        else {
            shader.maximumLOD = 100;
        }
    }

    float CalculateObjToCameraByZ() {
        return Mathf.Abs(tr.position.z-MainCameraTr.position.z);
    }
}
