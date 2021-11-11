using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject playerGO;
    private Vector3 monsSpawnv3;
    [SerializeField] GameObject prefab;

    void Start()
    {
        
        //prefab = Resources.Load("Assets/Monster") as GameObject;

        playerGO = GameObject.Find("Player");
        //GameObject testGO = Instantiate(prefab) as GameObject;
        GameObject testGO =  Instantiate(prefab, playerGO.transform.position, Quaternion.identity) as GameObject;

        Debug.Log(testGO.transform.position);
    }

    private void Update()
    {
        
    }
}
