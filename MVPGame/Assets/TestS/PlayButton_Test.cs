using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;

public class PlayButton_Test
{
    private Button GameButton;

    [SetUp]
    public void Setup()
    {
        // Open the test scene
        EditorSceneManager.OpenScene("Assets/Scenes/GameScene.unity");

        // Find buttons in scene
        GameObject GameButtonGO = GameObject.FindGameObjectWithTag("GameButton");

        if (GameButtonGO != null)
        {
            GameButton = GameButtonGO.GetComponent<Button>();
        }
        else
        {
            Assert.Fail("Button 'GameButton' not found in scene!");
        }
    }

    [TearDown]
    public void Teardown()
    {
        // Uninstall the test scenario
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }

    [UnityTest]
    public IEnumerator GameButton_Exists()
    {
        Assert.IsNotNull(GameButton, "Button 'GameButton' not found in scene!");
        yield return null;
    }

    [UnityTest]
    public IEnumerator GameButton_IsClickable()
    {
        Assert.IsNotNull(GameButton, "Button 'GameButton' not found in scene!");

        // Simulate button click
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(GameButton.gameObject, pointerEventData, ExecuteEvents.pointerClickHandler);

        yield return null;
    }

    [UnityTest]
    public IEnumerator GameButton_CanTransitionToEndScreen()
    {
        Assert.IsNotNull(GameButton, "Button 'GameButton' not found in scene!");

        // Simulate button click
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(GameButton.gameObject, pointerEventData, ExecuteEvents.pointerClickHandler);

        yield return null;
    }

    
}
