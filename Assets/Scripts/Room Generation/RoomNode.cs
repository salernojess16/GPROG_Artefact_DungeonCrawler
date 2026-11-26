using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomNode
{ //this script represents a vertex
    public enum roomType //different types of room
    {
    Spawn,
    Normal,
    Healing,
    Boss
 
    }

    public LinkedList<RoomNode> connections; //list for connections . each room gets its own list of empty connections. 
    
    private roomType room;
    private int id;

    public roomType getRoom()
    {
        return room;   //get information of what room it is 
    }

    public RoomNode(roomType room, int id ) //a constructor 
    {

        this.room = room;   //set the room to be the specific room 
        this.id = id;
        connections = new LinkedList<RoomNode>(); //initalise  linked list 
    }


    public LinkedList<RoomNode> getConnections() //find out what connections a vertex 
    {
        return connections;

    }

    public int getId() //getter for id
    {
        return id;
    }

    /* public override string ToString()
    {
        return room;     // learnt how to block a section! in workshop i can see its used as its console based 
    }
    */
}
