using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : BasicEnemy
{
    private void Awake()
    {
        enemySpeed = 0.5f;
        enemyDamage = 20;
        enemyHp = 2f;
    }
}
