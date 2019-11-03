using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorInstancing : MonoBehaviour
{
    GameObject[] objs;
    // Start is called before the first frame update
    void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("GPUInstancing");
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        MeshRenderer renderer;

        foreach(GameObject obj in objs)
        {
            float r = Random.Range(0.0f,1.0f);
            float g = Random.Range(0.0f, 1.0f);
            float b = Random.Range(0.0f, 1.0f);
            props.SetColor("_Color",new Color(r,g,b));

            renderer = obj.GetComponent<MeshRenderer>();
            renderer.SetPropertyBlock(props);
        }
    }
}
