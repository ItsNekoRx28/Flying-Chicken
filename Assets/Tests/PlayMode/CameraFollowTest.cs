using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraFollowTest
{
    [UnityTest]
    public IEnumerator CameraFollowsPollo_BeforeMovement()
    {
        // Create an object for "pollo"
        GameObject polloObject = new GameObject("Pollo");
        polloObject.transform.position = Vector3.zero;

        // Create an object for the camera
        GameObject cameraObject = new GameObject("Main Camera");
        CameraFollow cameraFollow = cameraObject.AddComponent<CameraFollow>();

        // Set the "pollo" as the camera's target
        cameraFollow.pollo = polloObject.transform;
        // Adjust the camera's offset
        cameraFollow.offset = new Vector3(0, 0, -2);

        // Wait for a frame to allow the camera to update
        yield return null;

        // Check if the camera's position follows "pollo's" position
        Assert.AreEqual(polloObject.transform.position + cameraFollow.offset, cameraObject.transform.position);
    }

    [UnityTest]
    public IEnumerator CameraFollowsPollo_AfterMovement()
    {
        // Create an object for "pollo"
        GameObject polloObject = new GameObject("Pollo");
        polloObject.transform.position = Vector3.zero;

        // Create an object for the camera
        GameObject cameraObject = new GameObject("Main Camera");
        CameraFollow cameraFollow = cameraObject.AddComponent<CameraFollow>();

        // Set the "pollo" as the camera's target
        cameraFollow.pollo = polloObject.transform;
        // Adjust the camera's offset
        cameraFollow.offset = new Vector3(0, 0, -2);

        // Wait for a frame to allow the camera to update
        yield return null;

        // Move "pollo"

        polloObject.transform.position = new Vector3(5f, 0f, 0f);

        // Wait for a frame to allow the camera to update
        yield return null;

        // Check if the camera's position follows "pollo's" position
        Assert.AreEqual(polloObject.transform.position + cameraFollow.offset, cameraObject.transform.position);
    }
}
