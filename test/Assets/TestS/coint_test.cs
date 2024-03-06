using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine.TestTools;
using System.Text;
using System;


public class coint_test : MonoBehaviour
{



    public Text coin;


    [SetUp]
    public void Setup()
    {
        // Open the test scene
        EditorSceneManager.OpenScene("Assets/Scenes/GameScene.unity");

        // Find buttons in scene
        GameObject coin_GO = GameObject.FindGameObjectWithTag("coin_txt");


        if (coin_GO != null)
        {
           coin  = coin_GO.GetComponent<Text>();
        }
        else
        {
            Assert.Fail("Button 'Play' not found in scene!");
        }

    }

    [SetUp] //初始化被测对象的属性值
    public void SetUp()
    {
        coin.text = "1";
    }
    [UnityTest]
    public IEnumerator coin_Test()
    {
        Assert.IsNotNull(coin, "not null");

        coin.text = "2";

        int coin_numbr = Convert.ToInt32(coin.text);
        Debug.Log("coin.txt=" + coin.text);
        Assert.AreEqual(coin_numbr,2);

        yield return null;

   
    }




}
