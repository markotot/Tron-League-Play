using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject trail;
    public LevelManager levelManager;
    public Vector3 spawnPoint;
    public int player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnPoint;
        if(player == 1)
        {
            Renderer cubeRenderer = GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.red);
        } else
        {
            Renderer cubeRenderer = GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);
        }
        levelManager.updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y),  (int)Mathf.Floor(transform.position.x), TileType.Player1Head);
    }

    // Update is called once per frame
    void Update()
    {
        if(player == 1)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                createTrail();
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                levelManager.updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                createTrail();
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                levelManager.updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                createTrail();
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                levelManager.updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                createTrail();
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                levelManager.updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);

            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                createTrail();
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                levelManager.updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                createTrail();
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                levelManager.updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                createTrail();
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                levelManager.updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                createTrail();
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                levelManager.updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player1Head);

            }
        }
    }

    void createTrail()
    {
        if(player == 1)
        {
            GameObject go = Instantiate(trail, transform.position, Quaternion.identity);
            Renderer cubeRenderer = go.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.red);
        } else
        {
            GameObject go = Instantiate(trail, transform.position, Quaternion.identity);
            Renderer cubeRenderer = go.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);
        }
        levelManager.updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y),  (int)Mathf.Floor(transform.position.x), TileType.Player1Trail);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game over");
    }
}
