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

    // Start is called before the first frame update
    void Start()
    {
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

        foreach (var item in susans)
        {
            Destroy(item.gameObject);
        }

        for (int y = 0; y < int.Parse(countOfModels.text); y++)
        {
            var ran = UnityEngine.Random.Range(0, 100);

            var model = Instantiate(modelPrefab);

            var meshRend = model.GetComponentInChildren<MeshRenderer>();
            var currentInfo = materialsInfo.Infos[dropdown.value];
            meshRend.material = new Material(currentInfo.Shader);

            if (currentInfo.Texture != null)
                meshRend.material.mainTexture = currentInfo.Texture;

            meshRend.material.color = currentInfo.Color;

        }
    }
}
