using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TransitionObjectMove : MonoBehaviour
{
    public MoveObjectData[] objectsToMove; // Array of objects to move
    public float moveDuration = 1f; // Duration of the move
    public float delayBetweenMoves = 0.5f; // Delay between each object's move

    private int currentIndex = 0; // Index of the current object being moved

    private void Start()
    {
        MoveNextObject(); // Move the first object
    }

    public void MoveNextObject()
    {
        // Check if all objects have been moved
        if (currentIndex >= objectsToMove.Length)
        {
            return;
        }

        // Get the current object and its end position
        MoveObjectData currentObjectData = objectsToMove[currentIndex];
        Transform currentObject = currentObjectData.objectToMove;
        Vector3 endPosition = currentObjectData.endPosition;

        // Move the current object to its end position using DOTween
        currentObject.DOMove(endPosition, moveDuration).SetEase(Ease.OutSine);

        // Increment the index and schedule the next object's move
        currentIndex++;
        Invoke("MoveNextObject", delayBetweenMoves + moveDuration);
    }
    public void MoveStartPosition()
    {
        // Check if all objects have been moved
        if (currentIndex >= objectsToMove.Length)
        {
            return;
        }

        // Get the current object and its end position
        MoveObjectData currentObjectData = objectsToMove[currentIndex];
        Transform currentObject = currentObjectData.objectToMove;

        // Move the current object to its end position using DOTween
        currentObject.DOMove(currentObjectData.startPosition, moveDuration).SetEase(Ease.OutSine);

        // Increment the index and schedule the next object's move
        currentIndex++;
        Invoke("MoveStartPosition", delayBetweenMoves + moveDuration);
    }

}

// Custom class to hold the game object, start position, and end position
[System.Serializable]
public class MoveObjectData
{
    public Transform objectToMove;
    public Vector3 startPosition;
    public Vector3 endPosition;
}
