using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class CannonTest : MonoBehaviour
    {
        Cannon cannon;
        Enemy enemy;
        Bullet bullet;
        [UnitySetUp]
        public IEnumerator SceneLoad()
        {
            SceneManager.LoadScene("1Lvl");
            yield return new WaitForSeconds(10f);
            cannon = FindObjectOfType<Cannon>();
            enemy = FindObjectOfType<Enemy>();
            bullet = FindObjectOfType<Bullet>();
        }
        [Test]
        public void Cannon_Can_Shoot()
        {
            cannon.Shoot();
          
            Assert.True(FindObjectOfType<Bullet>());
        }
        [Test]
        public void Cannon_Range()
        {
            Assert.AreEqual(10, cannon.Range);
        }
        [Test]
        public void Mortar_Range()
        {
            Assert.AreEqual(20, cannon.Range);
        }
        [Test]
        public void CannonUpDate_Range()
        {
            Assert.AreEqual(15, cannon.Range);
        }
        [Test]
        public void MortarUpDate_Range()
        {
            Assert.AreEqual(30, cannon.Range);
        }
        [Test]
        public void Cannon_Rate()
        {
            Assert.AreEqual(1, cannon.fireRate);
        }
        [Test]
        public void Mortar_Rate()
        {
            Assert.AreEqual(0.5, cannon.fireRate);
        }
        [Test]
        public void CannonUpDate_Rate()
        {
            Assert.AreEqual(2, cannon.fireRate);
        }
        [Test]
        public void MortarUpDate_Rate()
        {
            Assert.AreEqual(1, cannon.fireRate);
        }
        
    }
}
