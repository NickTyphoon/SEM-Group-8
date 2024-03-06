using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.UI;

public class testmove
{

    public GameObject player;
    public GameObject coin;


    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(1);

     
   

        coin = Resources.Load<GameObject>("coin");
        coin.tag = "coin";

        player = Resources.Load<GameObject>("whiteCircle");
    }

    // A Test behaves as an ordinary method
    [Test]
    public void testmoveSimplePasses()
    {
        // Use the Assert class to test conditions

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator player_move_WithEnumeratorPasses()
    {
        // Use "Resources/Prefabs/Game" to create an instance of the "Game(GameObject)".


        // Get "Game(Script)" as a component of "Game(GameObject)".
        if (player != null)
        {
            movement m = player.GetComponent<movement>();
       
            if (m != null)
            {
               
                float initialYPos = player.transform.position.y;

              
                yield return new WaitForSeconds(0.5f);

                //mis
                Assert.AreNotEqual(m.moveInput, 1);
                //right
                Assert.AreEqual(m.moveInput, 0);


                Assert.AreEqual(initialYPos, player.transform.position.y);
                if (Input.GetKeyDown(KeyCode.W))
                {
                    Assert.AreEqual(m.rb.velocity.y, 10);
             
                }

            }
            else
            {
                Assert.Fail("m  null");

            }
          
        }
        else
        {
            Assert.Fail("object 'Play' not found in scene!");
        }




        yield return null;
    }
    [UnityTest]
    public IEnumerator coin_WithEnumeratorPasses()
    {
        // Use "Resources/Prefabs/Game" to create an instance of the "Game(GameObject)".


        // Get "Game(Script)" as a component of "Game(GameObject)".
        if (player != null)
        {
            movement m = player.GetComponent<movement>();

            if (m != null)
            {

       

                yield return new WaitForSeconds(0.5f);

                Assert.AreEqual(m.coinCount, 0);
                m.coinCount += 1;
                Debug.Log("m.coincount=" + m.coinCount);
             
                Assert.AreEqual(m.coinCount, 1);

               

            }
            else
            {
                Assert.Fail("m  null");

            }

        }
        else
        {
            Assert.Fail("object 'Play' not found in scene!");
        }




        yield return null;
    }
}
