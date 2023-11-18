using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PauseMenuTest
{
    [UnityTest]
    public IEnumerator PauseAndResume()
    {
        GameUtils pauseMenu = new GameObject().AddComponent<GameUtils>();
        pauseMenu.pauseMenuUI = new GameObject();

        // Test pausing
        pauseMenu.Pause();
        yield return null;

        // Verify that the pause menu is active and timeScale is 0
        Assert.IsTrue(pauseMenu.pauseMenuUI.activeSelf);
        Assert.AreEqual(Time.timeScale, 0f);

        // Test resuming
        pauseMenu.Resume();
        yield return null;

        // Verify that the pause menu is inactive and timeScale is 1
        Assert.IsFalse(pauseMenu.pauseMenuUI.activeSelf);
        Assert.AreEqual(Time.timeScale, 1f);
    }

    [UnityTest]
    public IEnumerator Restart()
    {
        GameUtils pauseMenu = new GameObject().AddComponent<GameUtils>();
        pauseMenu.pauseMenuUI = new GameObject();

        // Load a test scene
        var initialScene = SceneManager.GetActiveScene().name;

        // Test restarting
        pauseMenu.Restart();

        // Verify that the current scene is the same as before
        Assert.AreEqual(initialScene, SceneManager.GetActiveScene().name);

        // Verify that the pause menu is inactive and timeScale is 1
        Assert.IsFalse(pauseMenu.pauseMenuUI.activeSelf);

        yield return null;

        Assert.AreEqual(Time.timeScale, 1f);
    }

}
