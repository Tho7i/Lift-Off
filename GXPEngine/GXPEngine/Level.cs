using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Level : GameObject
{
    private int _lastTimeSpawned = -5000;
    private int _enemiesToSpawn = 1;

    Enemy enemy;
    Player player;

    public Level() : base()
    {
        player = new Player();
        AddChild(player);
    }

    private void enemySpawning()
    {
        {
            if (Time.time - _lastTimeSpawned >= 5000)
            {
                for (int i = 0; i < _enemiesToSpawn; i++)
                {
                    enemy = new Enemy();
                    AddChild(enemy);
                    enemy.SetTargetPlayer(player);
                    _lastTimeSpawned = Time.time;
                }
                _enemiesToSpawn++;
            }
        }
    }

    void Update()
    {
        enemySpawning();
    }
}
