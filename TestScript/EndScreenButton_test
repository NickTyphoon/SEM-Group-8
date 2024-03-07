using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;

public class EndScreenButton_test
{
    private Button EndScreenButton;

    [SetUp]
    public void Setup()
    {
        // Open the test scene
        EditorSceneManager.OpenScene("Assets/Scenes/EndScreen.unity");

        // Find buttons in scene
        GameObject EndScreenButtonGO = GameObject.FindGameObjectWithTag("EndScreenButton");

        if (EndScreenButtonGO != null)
        {
            EndScreenButton = EndScreenButtonGO.GetComponent<Button>();
        }
        else
        {
            Assert.Fail("Button 'EndScreenButton' not found in scene!");
        }
    }

    [TearDown]
    public void Teardown()
    {
        // Uninstall the test scenario
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }

    [UnityTest]
    public IEnumerator EndScreenButton_Exists()
    {
        Assert.IsNotNull(EndScreenButton, "Button 'EndScreenButton' not found in scene!");
        yield return null;
    }

    [UnityTest]
    public IEnumerator EndScreenButton_IsClickable()
    {
        Assert.IsNotNull(EndScreenButton, "Button 'EndScreenButton' not found in scene!");

        // Simulate button click
        EndScreenButton.onClick.Invoke();

        yield return null;
    }

    [UnityTest]
    public IEnumerator EndScreenButton_CanTransitionToGameScene()
    {
        Assert.IsNotNull(EndScreenButton, "Button 'EndScreenButton' not found in scene!");

        // Add a scene loaded event handler
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Simulate button click
        EndScreenButton.onClick.Invoke();

        // Wait for one frame
        yield return null;

        // Wait for scene to load
        while (SceneManager.GetActiveScene().name == "EndScreen")
        {
            yield return null;
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;  // Remove the event handler

        Assert.AreEqual("GameScene", SceneManager.GetActiveScene().name);

        yield return null;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Do something when the scene is loaded
    }
}
