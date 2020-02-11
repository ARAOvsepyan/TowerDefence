using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSuite
{
    Enemy enemy;

    [UnityTest]
    public IEnumerator Health()
    {
        GameObject EnemyGameObject =
    MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"));
        enemy = EnemyGameObject.GetComponent<Enemy>();

        int helth = enemy.health;
        int damage = 10;
        enemy.TakeDamage(damage);

        int helth_dmg = enemy.health;
        int dmg = helth - helth_dmg;

        yield return null;

        Assert.IsTrue(dmg == damage);

        Object.Destroy(enemy.gameObject);
    }



}