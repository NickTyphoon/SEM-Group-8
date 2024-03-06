using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine.TestTools;

public class ButtonTest
{
    private Button playButton;
    private Button optionsButton;
    private Button quitButton;
    private bool playButtonClicked;
    private bool optionsButtonClicked;
    private bool quitButtonClicked;

    [SetUp]
    public void Setup()
    {
        // Open the test scene
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenuScene.unity");

        // Find buttons in scene
        GameObject playButtonGO = GameObject.FindGameObjectWithTag("Play");
        GameObject optionsButtonGO = GameObject.FindGameObjectWithTag("Options");
        GameObject quitButtonGO = GameObject.FindGameObjectWithTag("Quit");

        if (playButtonGO != null)
        {
            playButton = playButtonGO.GetComponent<Button>();
            playButton.onClick.AddListener(OnPlayButtonClick);
        }
        else
        {
            Assert.Fail("Button 'Play' not found in scene!");
        }

        if (optionsButtonGO != null)
        {
            optionsButton = optionsButtonGO.GetComponent<Button>();
            optionsButton.onClick.AddListener(OnOptionsButtonClick);
        }
        else
        {
            Assert.Fail("Button 'Options' not found in scene!");
        }

        if (quitButtonGO != null)
        {
            quitButton = quitButtonGO.GetComponent<Button>();
            quitButton.onClick.AddListener(OnQuitButtonClick);
        }
        else
        {
            Assert.Fail("Button 'Quit' not found in scene!");
        }
    }

    [TearDown]
    public void Teardown()
    {
        // Remove button click event listener
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
        }

        if (optionsButton != null)
        {
            optionsButton.onClick.RemoveAllListeners();
        }

        if (quitButton != null)
        {
            quitButton.onClick.RemoveAllListeners();
        }

        // Uninstall the test scenario
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
    }

    [UnityTest]
    public IEnumerator PlayButtonClickTest()
    {
        Assert.IsNotNull(playButton, "Button 'Play' not found in scene!");

        playButtonClicked = false;
        playButton.onClick.Invoke();

        yield return null;

        Assert.IsTrue(playButtonClicked, "Play button click event not triggered!");
    }

    [UnityTest]
    public IEnumerator OptionsButtonClickTest()
    {
        Assert.IsNotNull(optionsButton, "Button 'Options' not found in scene!");

        optionsButtonClicked = false;
        optionsButton.onClick.Invoke();

        yield return null;

        Assert.IsTrue(optionsButtonClicked, "Options button click event not triggered!");
    }

    [UnityTest]
    public IEnumerator QuitButtonClickTest()
    {
        Assert.IsNotNull(quitButton, "Button 'Quit' not found in scene!");

        quitButtonClicked = false;
        quitButton.onClick.Invoke();

        yield return null;

        Assert.IsTrue(quitButtonClicked, "Quit button click event not triggered!");
    }

    private void OnPlayButtonClick()
    {
        playButtonClicked = true;
    }

    private void OnOptionsButtonClick()
    {
        optionsButtonClicked = true;
    }

    private void OnQuitButtonClick()
    {
        quitButtonClicked = true;
    }
}

