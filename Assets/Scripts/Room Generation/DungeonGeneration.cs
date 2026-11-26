using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    // this script creates the graph itsemf by generatung the roomms themselves annd connects them.
    //i want to spawn 8 rooms using insert() and addedge() and NO branching, linear simple

    //i want controlled randomness following the 8 rooms and how many i want per game 
    private DungeonGraph dungeonGraph = new DungeonGraph();  //instance of the graph 
    private List<RoomNode.roomType> roomTypes = new List<RoomNode.roomType>();  //list adds the enum to the lsit

    private void Awake()
    {//conditions, the amount of rooms we want everytime
        roomTypes.Add(RoomNode.roomType.Spawn);

        roomTypes.Add(RoomNode.roomType.Normal);
        roomTypes.Add(RoomNode.roomType.Normal);
        roomTypes.Add(RoomNode.roomType.Normal);

        roomTypes.Add(RoomNode.roomType.Healing);
        roomTypes.Add(RoomNode.roomType.Healing);

        roomTypes.Add(RoomNode.roomType.Boss);
        roomTypes.Add(RoomNode.roomType.Boss);

        shuffle();

        foreach (RoomNode.roomType room in roomTypes)
        {
            dungeonGraph.Insert(room); //insert rooms in graph using the list 
        }

        //now add the edges

        for (int i = 0; i < roomTypes.Count - 1; i++)
        {
            dungeonGraph.AddEdge(i, i + 1);


            //debug log to see
            RoomNode room = dungeonGraph.Find(i);
            Debug.Log("room id: " + room.getId() + " Room Type: " + room.getRoom());
        }
       
    }


    //randomness
    private void shuffle()
    {
        for (int i = 1; i < roomTypes.Count; i++) //start at 1, continuee until end of list then move onto the next 
        {
            RoomNode.roomType temp = roomTypes[i]; //temp = original room 
            int randomIndex = Random.Range(i, roomTypes.Count); //random position in index

            //now it switches the values
            roomTypes[i] = roomTypes[randomIndex];
            roomTypes[randomIndex] = temp;
        }
    }


   
}
