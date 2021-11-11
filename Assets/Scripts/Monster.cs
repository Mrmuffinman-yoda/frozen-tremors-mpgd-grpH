using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private static GameObject myMonster;
    private static GameObject myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myMonster = GameObject.Find("Monster(Clone)");
        myPlayer = GameObject.Find("playerBody");
        StartCoroutine(moveMonsterRandomly());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator moveMonsterRandomly()
    {
        
        yield return new WaitForSeconds(10);
        Vector3 test = myMonster.transform.position;
        
        test.x += 12;

        myMonster.transform.position = test;
    }
}
