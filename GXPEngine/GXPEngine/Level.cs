using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using TiledMapParser;       //necessary to read the map

public class Level : GameObject
{
    private int _lastTimeSpawned = -5000;
    private int _enemiesToSpawn = 1;

    Enemy enemy;
    Player player;
    HUD hud;

    public Level() : base()
    {
        setupLevel();             
        player = new Player();
        AddChild(player);

        hud = new HUD();
        AddChild(hud);
        hud.SetTargetPlayer(player);
    }

    //level loading method
	public void setupLevel()
	{
		LoadMap("Project3MAP02.tmx");

	}

    //tiles loading(order matters depending on how the tiles are ordered)
    private void LoadMap(string filename)
    {
        TiledLoader loader = new TiledLoader(filename);



        loader.addColliders = false;    //disables collision
        loader.LoadTileLayers(0);

        loader.addColliders = false;    //disables collision
        loader.LoadTileLayers(1);

        loader.addColliders = true;     //enables collision
        loader.LoadTileLayers(2);





        loader.autoInstance = true;     //instantiates object layers
        loader.LoadObjectGroups();



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
