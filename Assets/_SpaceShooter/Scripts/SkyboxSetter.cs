using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Skybox))]
public class SkyboxSetter : MonoBehaviour
{
    [SerializeField] List<Material> _skyboxMaterials;
    private Skybox _skybox;
    private void Awake()
    {
        _skybox = GetComponent<Skybox>();    
    }
    private void OnEnable()
    {
        ChangeSkyBox(0);
    }

    private void ChangeSkyBox(int skyboxIndex)
    {
        if(_skybox != null && skyboxIndex <= _skyboxMaterials.Count) {
        _skybox.material = _skyboxMaterials[skyboxIndex];
        }
    }
}
