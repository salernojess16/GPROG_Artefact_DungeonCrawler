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

    public void AddEdge(int from, int to) //add an edge (hallway) between rooms    //need to figure out how to use id to find the roomconnections
    {
        var FromList = Find(from);
        var toNode = Find(to)?.First;

        if (FromList != null && toNode != null)
        {
            FromList.AddLast(toNode.Value);
        }

    }

   

    public LinkedList<RoomNode> Find(RoomNode.roomType room) // find what rooms connect via edges
    {
        
        foreach (var list in graph)
        {
            if (list.First.Value.getRoom() == room)
            {
                return list;
            }
        }

        return null;
    }

}
