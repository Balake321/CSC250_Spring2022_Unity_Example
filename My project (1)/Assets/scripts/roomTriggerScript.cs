using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomTriggerScript : MonoBehaviour
{
    private Room thisRoom;
    private Room currentRoom;


    // Start is called before the first frame update
    void Awake()
    {
        print("*************** Room trigger is awake *************");
    }

    void Start()
    {
        print("*************** Room trigger has started *************");
        this.thisRoom = new Room();
        CORE.addRoom(this.thisRoom);
        this.thisRoom = currentRoom();
        CORE.addRoom(this.thisRoom);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            this.thisRoom.setPlayer(CORE.getPlayer()); //lets the new room know about the player
            print("Player now in room: " + this.thisRoom);
        }
        else if (other.gameObject.tag.Equals("Enemy"))
        {
            this.thisRoom.setEnemy(CORE.getEnemy());
            print("Enemy Entered room " + this.gameObject.ToString());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            Player.setPreviousRoom(this.thisRoom);
            Destroy(CORE.getRoom);
        }
        else if (other.gameObject.tag.Equals("Enemy"))
        {
            Enemy.setPreviousRoom(this.thisRoom);
            Destroy(CORE.getRoom);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
