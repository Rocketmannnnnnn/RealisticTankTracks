using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBuilder : MonoBehaviour
{
    public GameObject obj;
    public PathCreator pathCreator;
    public float speed = 0.2f;
    public int trackAmount = 10;
    List<GameObject> gameObjects = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < trackAmount; i++)
        {
            GameObject piece = Instantiate(obj);
            gameObjects.Add(piece);
            PathFollower flw = piece.AddComponent<PathFollower>();
            flw.pathCreator = this.pathCreator;
            flw.endOfPathInstruction = EndOfPathInstruction.Loop;
            flw.speed = this.speed;
            flw.distanceTravelled = (float)i / (float)trackAmount * pathCreator.path.length;
        }
    }
}
