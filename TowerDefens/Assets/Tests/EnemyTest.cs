using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class EnemtTest : MonoBehaviour
    {
        Enemy enemy;
        WaveSpawner spawner;
        Stats PlayerStats;

        [UnitySetUp]
        public IEnumerator SceneLoad()
        {
            SceneManager.LoadScene("1Lvl");
            yield return new WaitForSeconds(5f);
            enemy = FindObjectOfType<Enemy>();
        }
        

        [UnityTest]
        public IEnumerator Enemy_Take_Damage()
        {
            enemy.TakeDamage(50);

            yield return null;

            Assert.AreEqual(150, enemy.health);
        }
        [UnityTest]
        public IEnumerator Player_Take_Damage()
        {
            enemy.ReachTheEnd();

            yield return null;

            Assert.AreEqual(15, Stats.Lives);
        }

        [UnityTest]
        public IEnumerator Player_Take_Value()
        {
            enemy.TestForDie();

            yield return null;

            Assert.AreEqual(250, Stats.Money);
        }
    }
}