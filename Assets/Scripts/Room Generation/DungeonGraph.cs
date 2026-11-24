using System.Collections.Generic;
using UnityEngine;

public class DungeonGraph 
{
    private LinkedList<LinkedList<RoomNode>> graph = new LinkedList<LinkedList<RoomNode>>();
    // a variable that stores a rooms linked lists

    private int size = 0;

    public void Insert(string room)   //insert a room
    {
        RoomNode node = new RoomNode(room);
        var newList = new LinkedList<RoomNode>();
        newList.AddLast(node);
        graph.AddLast(newList);
        size++;
    }

    public void AddEdge(string from, string to) //add an edge (hallway) between rooms
    {
        var FromList = Find(from);
        var toNode = Find(to)?.First;

        if (FromList != null && toNode != null)
        {
            FromList.AddLast(toNode.Value);
        }
    }

    public LinkedList<RoomNode> Find(string room) // find what rooms connect via edges
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
