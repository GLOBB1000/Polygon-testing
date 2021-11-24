using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainCore : MonoBehaviour
{

    [SerializeField]
    private MaterialsInfo materialsInfo;

    [SerializeField]
    private InputField countOfModels;

    [SerializeField]
    private Button createButton;

    [SerializeField]
    private GameObject modelPrefab;

    [SerializeField]
    private Dropdown dropdown;

    [SerializeField]
    private Material defaultMat;

    [SerializeField]
    private Shader shader;

    [SerializeField]
    private MaterialsPool materialsPool;

    // Start is called before the first frame update
    void Start()
    {
        countOfModels.text = "10";

        defaultMat = new Material(shader);

        createButton.onClick.AddListener(Create);

        List<string> modelNames = new List<string>();
        foreach (var item in materialsInfo.Infos)
        {
            modelNames.Add(item.Name);
        }

        dropdown.AddOptions(modelNames);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Create()
    {
        List<Susan> susans = new List<Susan>(FindObjectsOfType<Susan>());

        materialsPool.SetPoolObjects(dropdown, countOfModels);

        int indexOfPool = 0;

        foreach (var item in susans)
        {
            Destroy(item.gameObject);
        }

        for (int y = 0; y < int.Parse(countOfModels.text); y++)
        {
            var ran = UnityEngine.Random.Range(0, 100);

            var model = Instantiate(modelPrefab);

            MeshRenderer meshRend = model.GetComponentInChildren<MeshRenderer>();

            //meshRend.material = defaultMat;

            Debug.Log($"Index of pool {Mathf.RoundToInt(y / 10f)}\n Size of pool {materialsPool.pooledMaterials.Count}");

            meshRend.material = materialsPool.pooledMaterials[Mathf.RoundToInt(y / 10f)];



            //meshRend.material = defaultMat;

            //var currentInfo = materialsInfo.Infos[dropdown.value];
            //Material mat = new Material(currentInfo.Shader);

            //meshRend.material = mat;

            //if (currentInfo.Texture != null)
            //    meshRend.material.mainTexture = currentInfo.Texture;

            //meshRend.material.color = currentInfo.Color;

        }
    }
}
