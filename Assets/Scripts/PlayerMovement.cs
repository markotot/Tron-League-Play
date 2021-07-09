using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;
using Unity.MLAgents.Actuators;
public class PlayerMovement : Agent
{
    public GameObject trail;
    public LevelManager levelManager;
    public Vector3 spawnPoint;
    public Color trailColor;
    public Color headColor;
    public GameObject trails;
    public PlayerMovement opponent;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnPoint;
        renderObjectColor(GetComponent<Renderer>(), headColor);
        updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);
    }

    // Update is called once per frame
    void Update()
    {
        handleKeyPress(KeyCode.S, 0f, -1f, 0f);
        handleKeyPress(KeyCode.W, 0f, 1f, 0f);
        handleKeyPress(KeyCode.A, -1f, 0f, 0f);
        handleKeyPress(KeyCode.D, 1f, 0f, 0f);
    }
    private void handleKeyPress(KeyCode keyPressed, float xModifier, float yModifier, float zModifier)
    {
        if (Input.GetKeyDown(keyPressed))
        {
            createTrail();
            transform.position = new Vector3(transform.position.x + xModifier, transform.position.y + yModifier, transform.position.z + zModifier);
            updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);
        }
    }

    private void handleAgentAction(float xModifier, float yModifier, float zModifier)
    {
        createTrail();
        transform.position = new Vector3(transform.position.x + xModifier, transform.position.y + yModifier, transform.position.z + zModifier);
        updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);
    }
    private void createTrail()
    {
        GameObject trailObject = Instantiate(trail, transform.position, Quaternion.identity);
        trailObject.transform.parent = trails.transform;
        renderObjectColor(trailObject.GetComponent<Renderer>(), trailColor);
        updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Trail);
    }

    private void updateLevelTrail(int x, int y, TileType tileType)
    {
        levelManager.updateLevelTrail(x, y, tileType);
    }

    private void renderObjectColor(Renderer renderer, Color color)
    {
        renderer.material.SetColor("_Color", color);
    }

    private void OnTriggerEnter(Collider other)
    {
        SetReward(-1.0f);
        opponent.SetReward(1.0f);
        opponent.EndEpisode();
        EndEpisode();
    }

    // ML-Agents methods
    public override void OnEpisodeBegin()
    {
        
        transform.position = new Vector3(Random.Range(0,9) + 0.5f, Random.Range(0,9) + 0.5f, 0f);
        levelManager.Level = new TileType[10, 10];
        updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);
        int children = trails.transform.childCount;
        for (int i = children - 1; i >= 0; i--)
            Destroy(trails.transform.GetChild(i).gameObject);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        /*
        List<float> observations = new List<float>();
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                observations.Add((float)levelManager.Level[i, j]);
            }
        }

        sensor.AddObservation(observations);
        */
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        if(actionBuffers.DiscreteActions[0] == 0)
            handleAgentAction(0f, -1f, 0f);
        if (actionBuffers.DiscreteActions[0] == 1)
            handleAgentAction(0f, 1f, 0f);
        if (actionBuffers.DiscreteActions[0] == 2)
            handleAgentAction(-1f, 0f, 0f);
        if (actionBuffers.DiscreteActions[0] == 3)
            handleAgentAction(1f, 0f, 0f);

    }
}
