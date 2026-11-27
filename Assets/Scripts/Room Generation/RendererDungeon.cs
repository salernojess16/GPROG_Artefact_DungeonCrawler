using UnityEngine;

public class RendererDungeon : MonoBehaviour
{
    // this script im going to -
    // assign a prefab for each node 
    // spawn in prefabs and edges as hallways following the information from the generator 
    // when its the last node (id 7) add a prefab that blocks the hole for the door 

    //need to make sure it spawns it downwards 

    public GameObject spawnPrefab;
    public GameObject NormalPrefab;
    public GameObject HealingPrefab;
    public GameObject BossPrefab;

    public GameObject HallwayPrefab;
    public GameObject doorBlocker;

    //need to make it so i can make the room types connect with the prefanbs 
}
