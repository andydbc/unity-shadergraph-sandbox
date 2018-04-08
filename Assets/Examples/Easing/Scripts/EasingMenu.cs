using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class EasingMenu : MonoBehaviour
{
    [SerializeField]
    Renderer _renderer;
    [SerializeField]
    Text _label;
    [SerializeField]
    List<Shader> _shaders;

    Material _material = null;
    int _index = 0;

    void OnEnable()
    {
        SetCurrent(0);
        _renderer.sharedMaterial = _material;
    }

    public void OnPrevious()
    {
        _index--;
        SetCurrent(_index);
    }

    public void OnNext()
    {
        _index++;
        SetCurrent(_index);
    }

    public void SetCurrent(int i)
    {
        if (_index < 0)
            _index = _shaders.Count - 1;

        if (_index > _shaders.Count - 1)
            _index = 0;

        if(_material == null)
            _material = new Material(_shaders[_index]);
        else
            _material.shader = _shaders[_index];

        _label.text = _shaders[_index].name.Substring("graphs/".Length);
    }
}
