using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private int updateCount=1;
    [SerializeField] protected Player p;
    [SerializeField] protected int sensitivityVal = 20; //The higher val is, the more sensitive monster will be
    [SerializeField] protected int monsterMovementSpeed = 3; //The higher val is, the faster the monster will move around the map
    [SerializeField] protected float monsterCatchup = 0.25f; //Higher the val us, the quicker monster will catchup to the player
    [SerializeField] private GameObject snowball;
    [SerializeField] private float snowballSpeed = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Update 100no./s regardless of fps
    private void FixedUpdate()
    {
        updateCount += 1;
        if (updateCount == 2) //Trigger event every 1/4 second approx
        {
            updateCount = 1; //Reset back to original, otherwise won't trigger every 1/4 sec
            if (isPlayerNearby())
            {
                if (fireSnowball())
                {
                    Debug.Log("Snowball fired");
                }
            }
        }
    }

    private bool fireSnowball() //Fires a dagger than inflicts damage on the player
    {
        Vector3 playerPos = p.transform.position;

        GameObject newSnowball = GameObject.Instantiate(snowball); //Init new snowball to fire at player
        newSnowball.transform.position = this.transform.position; //Put snowball inside monster ready to fire

        newSnowball.transform.position += Vector3.left * 1 * Time.deltaTime;

        return true;
    }

    private void followPlayer() //Follows the player around the map 'ominously'
    {
        Vector3 playerPos = p.transform.position;
        Vector3 movement = new Vector3(1*monsterCatchup, 1*monsterCatchup, 1*monsterCatchup);

        moveMonster(Vector3.Scale(playerPos, movement));
    }

    private bool moveMonster(int x, int y, int z) //Moves the monster object by the specified x,y,z direction values
    {
        Vector3 newPos = new Vector3(
            this.transform.position.x+x,
            this.transform.position.y+y,
            this.transform.position.z+z
            );

        this.transform.position = Vector3.Lerp(this.transform.position, newPos, Time.deltaTime * monsterMovementSpeed);

        return true;
    }

    private bool moveMonster(Vector3 v) //Moves the monster object by the specified vector3 value
    {
        Vector3 currentPos = this.transform.position;
        //Vector3 newPos = currentPos + v;

        this.transform.position = Vector3.Lerp(currentPos, v, Time.deltaTime * monsterMovementSpeed);

        return true;
    }

    private bool isPlayerNearby()
    {

        Vector3 playerPos = p.transform.position;
        Vector3 monsterPos = this.transform.position;
        
        
        if (withinBounds(playerPos.x+sensitivityVal, playerPos.x - sensitivityVal, monsterPos.x)
            && withinBounds(playerPos.y+sensitivityVal, playerPos.y-sensitivityVal, monsterPos.y)
            && withinBounds(playerPos.z+sensitivityVal, playerPos.z-sensitivityVal, monsterPos.z))
        {
            return true;
        } else { return false; }
    }

    private bool withinBounds(double max, double min, double val) //is 'val' within max and min inclusive?
    {
        if (val>=min && val <= max) { return true; }
        return false;
    }

    private bool isNeg(double val) //Checks whether val is a negative number or not
    {
        if (val < 0) { return true; }
        return false;
    }
}
