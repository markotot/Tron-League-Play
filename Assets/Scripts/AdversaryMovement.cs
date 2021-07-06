using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryMovement : MonoBehaviour
{
    public GameObject trail;
    public LevelManager levelManager;
    public Vector3 spawnPoint;
    public Color trailColor;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnPoint;
        renderObjectColor(GetComponent<Renderer>(), trailColor);
        updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y),  (int)Mathf.Floor(transform.position.x), TileType.Player2Head);
    }

    // Update is called once per frame
    void Update()
    {
        handleKeyPress(KeyCode.DownArrow, 0f, -1f, 0f);
        handleKeyPress(KeyCode.UpArrow, 0f, 1f, 0f);
        handleKeyPress(KeyCode.LeftArrow, -1f, 0f, 0f);
        handleKeyPress(KeyCode.RightArrow, 1f, 0f, 0f);
    }

    private void handleKeyPress(KeyCode keyPressed, float xModifier, float yModifier, float zModifier)
    {
        if (Input.GetKeyDown(keyPressed))
        {
            createTrail();
            transform.position = new Vector3(transform.position.x + xModifier, transform.position.y + yModifier, transform.position.z + zModifier);
            updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y), (int)Mathf.Floor(transform.position.x), TileType.Player2Head);
        }
    }
    private void createTrail()
    {
        GameObject trailObject = Instantiate(trail, transform.position, Quaternion.identity);
        renderObjectColor(trailObject.GetComponent<Renderer>(), trailColor);
        updateLevelTrail(9 - (int)Mathf.Floor(transform.position.y),  (int)Mathf.Floor(transform.position.x), TileType.Player2Trail);
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
        Debug.Log("Game over");
    }
}
