using Unity.VisualScripting;
using UnityEngine;

public class RoomNode
{
    private string room;

    public string getRoom()
    {
        return room;   //get information of what room it is 
    }

    public RoomNode(string room)
    {

        this.room = room;   //set the room to be the specific room 
    }

    /* public override string ToString()
    {
        return room;     // learnt how to block a section! in workshop i can see its used as its console based 
    }
    */
}
