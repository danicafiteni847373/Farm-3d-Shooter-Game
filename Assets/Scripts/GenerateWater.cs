using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWater : MonoBehaviour
{
    private Terrain terrain;
    private TerrainData terrainData;
    [Header("Water")]
    [SerializeField] private GameObject water;
    [SerializeField] private float waterHeight = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        if (terrain == null)
        {
            terrain = this.GetComponent<Terrain>();
        }
        if (terrainData == null)
        {
            terrainData = Terrain.activeTerrain.terrainData;
        }
        AddWater();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AddWater()
    {
        GameObject waterGameObject = Instantiate(water, this.transform.position, this.transform.rotation);
        waterGameObject.name = "Water";
        waterGameObject.transform.position = this.transform.position + new Vector3(terrainData.size.x / 2, waterHeight * terrainData.size.y,
        terrainData.size.z / 2);
        waterGameObject.transform.localScale = new Vector3(terrainData.size.z, 1, terrainData.size.z);
    }
}
