using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Info", order = 1)]
public class MaterialsInfo : ScriptableObject
{

    [SerializeField]
    public List<Info> Infos;


    [System.Serializable]
    public struct Info
    {
        public Shader Shader;

        public string Name;

        public Texture Texture;

        public Color Color;
    }
}
