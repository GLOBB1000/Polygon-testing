using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialsPool : MonoBehaviour
{
    public static MaterialsPool PoolInstance;

    public List<Material> pooledMaterials;

    public int countOfMaterials;

    public MaterialsInfo materialsInfo;

    private void Awake()
    {
        if (PoolInstance == null)
            PoolInstance = this;
    }

    public void SetPoolObjects(Dropdown dropdown, InputField inputField)
    {
        pooledMaterials = new List<Material>();
        int count = Mathf.RoundToInt(int.Parse(inputField.text) / 10f) + 1;
        Material tmpMat;

        for (int i = 0; i < count; i++)
        {
            var curMatInfo = materialsInfo.Infos[dropdown.value];
            tmpMat = new Material(curMatInfo.Shader);

            if (curMatInfo.Texture != null)
                tmpMat.mainTexture = curMatInfo.Texture;

            tmpMat.color = curMatInfo.Color;
            pooledMaterials.Add(tmpMat);
        }
    }

    public Material GetMaterial(int index)
    {
        return pooledMaterials[index];
    }


}
