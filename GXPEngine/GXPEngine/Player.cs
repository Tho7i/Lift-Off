using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Player : Sprite
{

    private int _xSpawn = 200;
    private int _ySpawn = 200;


    public Player() : base("colors.png")
    {
        this.x = _xSpawn;
        this.y = _ySpawn;
        this.SetOrigin(this.width / 2, this.height / 2);
    }

    private void handleMovement()
    {
        //-------------------------------------------------------------------------------------------------------------------------------------------
        //                                                         Handling the controls
        //-------------------------------------------------------------------------------------------------------------------------------------------
        if (Input.GetKey(Key.A))
        {
            MoveUntilCollision(-1.25f, 0.0f);
        }
        if (Input.GetKey(Key.D))
        {
            MoveUntilCollision(1.25f, 0.0f);
        }
        if (Input.GetKey(Key.S))
        {
            MoveUntilCollision(0.0f, 1.25f);
        }
        if (Input.GetKey(Key.W))
        {
            MoveUntilCollision(0.0f, -1.25f);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------
        //                                                 Phasing (Teleporting a short distance)
        //-------------------------------------------------------------------------------------------------------------------------------------------
        if (Input.GetKeyUp(Key.LEFT_SHIFT) && Input.GetKey(Key.A))
        {
            Move(-150.0f, 0.0f);
        }
        if (Input.GetKeyUp(Key.LEFT_SHIFT) && Input.GetKey(Key.D))
        {
            Move(150.0f, 0.0f);
        }
        if (Input.GetKeyUp(Key.LEFT_SHIFT) && Input.GetKey(Key.W))
        {
            Move(0.0f, -150.0f);
        }
        if (Input.GetKeyUp(Key.LEFT_SHIFT) && Input.GetKey(Key.S))
        {
            Move(0.0f, 150.0f);
        }
    }

    private void handleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Projectile projectile = new Projectile();
            game.AddChild(projectile);
            projectile.SetXY(this.x, this.y - this.height / 2 + 20);
            projectile.SetRotation();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Explosive explosive = new Explosive();
            game.AddChild(explosive);
            explosive.SetXY(this.x, this.y - this.height / 2 + 20);
            explosive.SetRotation();
        }
    }

    void Update()
    {
        handleMovement();
        handleShooting();
    }
}