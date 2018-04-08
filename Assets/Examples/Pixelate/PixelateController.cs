using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelateController : MonoBehaviour {

    [SerializeField]
    Material _material;

	void Update ()
    {
        float f = Time.time - Mathf.Floor(Time.time);
        float t = Mathf.Lerp(0, 128, f);

        _material.SetFloat("Ratio", t);
        _material.SetFloat("_Ratio", t);
        _material.SetVector("_Ratio", new Vector4(t, 0,0,0));
        _material.SetVector("Ratio", new Vector4(t, 0, 0, 0));
    }
}
