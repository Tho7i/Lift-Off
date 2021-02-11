﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Enemy : AnimSprite
{
    private Player _targetPlayer;
    private float _movSpeed = 0.5f;
    private int _health = 4;
    private int _randomise;
    private int _randomise2;
    private int _spawnX;
    private int _spawnY;

    public Enemy() : base("Enemy.png", 2, 1)
    {
        this.SetOrigin(this.width / 2, this.height / 2);
        SetFrame(0);
        randomizeEnemyPosition();
    }

    private void handleMovement()
    {
        if (_targetPlayer.x > this.x) { x += _movSpeed; } else { x -= _movSpeed; }
        if (_targetPlayer.y > this.y) { y += _movSpeed; } else { y -= _movSpeed; }
    }

    private void randomizeEnemyPosition()
    {
        _randomise = Utils.Random(1, 3);

        if (_randomise == 1)
        {
            x = Utils.Random(1, game.width + 1);


            if (x <= 64 || x >= 704)
            {
                y = Utils.Random(1, game.height + 1);
            }
            else
            {
                _randomise2 = Utils.Random(1, 3);
                if (_randomise2 == 1) { y = 0; }
                else { y = game.height; }
            }
        }
        else
        {
            y = Utils.Random(1, game.height + 1);


            if (y <= 64 || y >= 570)
            {
                x = Utils.Random(1, game.width + 1);
            }
            else
            {
                _randomise2 = Utils.Random(1, 3);
                if (_randomise2 == 1) { x = 0; }
                else { x = game.width; }
            }
        }
    }

    void Update()
    {
        handleMovement();

        if (_health <= 0)
        {
            LateDestroy();
        }
    }

    void OnCollision(GameObject other)
    {
        if (other is Melee)
        {
            _health -= 2;
            other.LateDestroy();
        }

        if (other is Player)
        {
            LateDestroy();
        }

        if (other is Projectile)
        {
            _health--;
            other.LateDestroy();
        }
    }

    public void SetTargetPlayer(Player player)
    {
        _targetPlayer = player;
    }
}
