using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class GameMasterTest : MonoBehaviour
    {
        Cannon cannon;
        [UnitySetUp]
        public IEnumerator SceneLoad()
        {
            SceneManager.LoadScene("1Lvl");
            yield return new WaitForSeconds(10f);
            cannon = FindObjectOfType<Cannon>();
        }
        [Test]
        public void Player_Stats_Money()
        { 
            Assert.AreEqual(2000, Stats.Money);
        }
        [Test]
        public void Player_Stats_Lives()
        {
            Assert.AreEqual(20, Stats.Lives);
        }
        [Test]
        public void Give_Mone_After_Sell_Cannon()
        {   
            Assert.AreEqual(1950, Stats.Money);
        }
        [Test]
        public void Take_Mone_After_Buy_Cannon()
        {
            Assert.AreEqual(1900, Stats.Money);
        }
    }
}
