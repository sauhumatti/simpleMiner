using UnityEngine;
using System.Collections;

public class SmoothGridCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public CaveGridSystem gridSystem;

    private Vector2Int currentGridPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        currentGridPosition = new Vector2Int(gridSystem.gridWidth / 2, gridSystem.gridHeight / 2);
        transform.position = gridSystem.GridToWorldPosition(currentGridPosition.x, currentGridPosition.y);
        targetPosition = transform.position;
    }

    void Update()
    {
        if (!isMoving)
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        Vector2Int movement = Vector2Int.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow)) movement.y = 1;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) movement.y = -1;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) movement.x = -1;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) movement.x = 1;

        if (movement != Vector2Int.zero)
        {
            TryMove(movement);
        }
    }

    void TryMove(Vector2Int movement)
    {
        Vector2Int newPosition = currentGridPosition + movement;

        if (gridSystem.IsTileWalkable(newPosition.x, newPosition.y))
        {
            StartCoroutine(MoveCharacter(newPosition));
        }
    }

    IEnumerator MoveCharacter(Vector2Int newPosition)
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        targetPosition = gridSystem.GridToWorldPosition(newPosition.x, newPosition.y);
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (Time.time - startTime < journeyLength / moveSpeed)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            yield return null;
        }

        transform.position = targetPosition;
        currentGridPosition = newPosition;
        isMoving = false;

        Debug.Log($"Moved to grid position: {currentGridPosition}, world position: {transform.position}");
    }
}