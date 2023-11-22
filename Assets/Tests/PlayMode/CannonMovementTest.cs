using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CannonMovementScriptTest
{
    [UnityTest]
    public IEnumerator RotateRightArrow_ShouldChangeRotation()
    {
        CannonMovementScript cannonObject = new GameObject().AddComponent<CannonMovementScript>();

        // Set an initial rotation
        cannonObject.rotationZ = 0;

        // Simulate pressing the right arrow key (increase rotation)

        updateRightRotation(cannonObject);

        var rotation1 = cannonObject.rotationZ;

        for(int i = 0; i < 5; i++)
        {
            updateRightRotation(cannonObject);
        }

        var rotation2 = cannonObject.rotationZ;

        // Wait for a frame to ensure the rotation is updated
        yield return null;

        // Assert that the rotation has changed (rotated to the left)
        Assert.Less(rotation2, rotation1);
    }

    private void updateRightRotation(CannonMovementScript cannonObject)
    {
        cannonObject.rotationZ -= cannonObject.rotationSpeed * Time.deltaTime;
        cannonObject.rotationZ = Mathf.Clamp(cannonObject.rotationZ, -80, -20);
        cannonObject.transform.rotation = Quaternion.Euler(0, 0, cannonObject.rotationZ);
    }


    [UnityTest]
    public IEnumerator RotateLeftArrow_ShouldChangeRotation()
    {
        CannonMovementScript cannonObject = new GameObject().AddComponent<CannonMovementScript>();

        // Set an initial rotation
        cannonObject.rotationZ = 0;

        // Simulate pressing the left arrow key (decrease rotation)
        updateLeftRotation(cannonObject);

        for (int i = 0; i < 10; i++)
        {
            updateRightRotation(cannonObject);
        }

        var rotation1 = cannonObject.rotationZ;

        for (int i = 0; i < 2; i++)
        {
            updateLeftRotation(cannonObject);
        }

        var rotation2 = cannonObject.rotationZ;

        // Wait for a frame to ensure the rotation is updated
        yield return null;

        // Assert that the rotation has changed (rotated to the left)
        Assert.Greater(rotation2, rotation1);
    }

    private void updateLeftRotation(CannonMovementScript cannonObject)
    {
        cannonObject.rotationZ += cannonObject.rotationSpeed * Time.deltaTime;
        cannonObject.rotationZ = Mathf.Clamp(cannonObject.rotationZ, -80, -20);
        cannonObject.transform.rotation = Quaternion.Euler(0, 0, cannonObject.rotationZ);
    }
}
