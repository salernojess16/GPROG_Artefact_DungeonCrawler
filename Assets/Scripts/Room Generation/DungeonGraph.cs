using System.Collections.Generic;
using UnityEngine;

public class DungeonGraph 
{
    private LinkedList<LinkedList<RoomNode>> graph = new LinkedList<LinkedList<RoomNode>>();
    // a variable that stores a rooms linked lists

    private int size = 0;

    public void Insert(RoomNode.roomType room)   //insert a room using the enum  as a parameter 
    {
        RoomNode node = new RoomNode(room, size);
        var newList = new LinkedList<RoomNode>();
        newList.AddLast(node);
        graph.AddLast(newList); //new linked list with node inside it
        size++;
       //increases the rooms
    }

    public void AddEdge(int from, int to) //add an edge (hallway) between rooms 
    {
        var FromRoom = Find(from);
        var toRoom = Find(to);

        if (FromRoom != null && toRoom != null)
        {
            FromRoom.connections.AddLast(toRoom); //a one way connection from room to another room  add edge adds a connection between the two rooms
        }

    }

   

    public RoomNode Find(int id) // find what roomnode is when we give it id
    {
        
        foreach (var list in graph) //search throgh each list
        {
            if (list.First.Value.getId() == id) //checks if this room is the one we r looking for 
            {
                return list.First.Value; //the room 
            }
        }

        return null;
    }

}
