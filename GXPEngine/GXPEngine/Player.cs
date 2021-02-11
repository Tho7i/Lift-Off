using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Player : AnimSprite
{

    private int _xSpawn = 200;
    private int _ySpawn = 200;
    private float _speed = 1.25f;
    private bool _shiva = true;
    private bool _ganesh = false;
    private bool _krishna = false;

    public int score;
    private int _karma;
    private int _health = 3;


    public Player() : base("Sprite.png", 4, 1)
    {
        this.x = _xSpawn;
        this.y = _ySpawn;
        this.SetOrigin(this.width / 2, this.height / 2);
        SetFrame(0);
        SetScaleXY(2.0f, 2.0f);
    }

    private void handleMovement()
    {
        //-------------------------------------------------------------------------------------------------------------------------------------------
        //                                                         Handling the controls
        //-------------------------------------------------------------------------------------------------------------------------------------------
        if (Input.GetKey(Key.A))
        {
            Move(-_speed, 0.0f);
        }
        if (Input.GetKey(Key.D))
        {
            MoveUntilCollision(_speed, 0.0f);
        }
        if (Input.GetKey(Key.S))
        {
            Move(0.0f, _speed);
        }
        if (Input.GetKey(Key.W))
        {
            Move(0.0f, -_speed);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------
        //                                                 Phasing (Teleporting a short distance)
        //-------------------------------------------------------------------------------------------------------------------------------------------
        if (Input.GetKeyUp(Key.SPACE) && Input.GetKey(Key.A))
        {
            Move(-150.0f, 0.0f);
        }
        if (Input.GetKeyUp(Key.SPACE) && Input.GetKey(Key.D))
        {
            Move(150.0f, 0.0f);
        }
        if (Input.GetKeyUp(Key.SPACE) && Input.GetKey(Key.W))
        {
            Move(0.0f, -150.0f);
        }
        if (Input.GetKeyUp(Key.SPACE) && Input.GetKey(Key.S))
        {
            Move(0.0f, 150.0f);
        }
    }

    private void handleShooting()
    {
        if (Input.GetMouseButtonDown(0) && _shiva)
        {
            Projectile projectile = new Projectile();
            game.AddChild(projectile);
            projectile.SetXY(this.x, this.y - this.height / 2 + 20);
            projectile.SetRotation();
            Console.WriteLine(_shiva.ToString());
            Console.WriteLine(_krishna.ToString());
            Console.WriteLine(_ganesh.ToString());
        }

        else if (Input.GetMouseButtonDown(0) && _ganesh)
        {
            Melee melee = new Melee();
            melee.SetTargetPlayer(this);
            game.AddChild(melee);
            melee.SetXY(this.x, this.y);
            melee.SetRotation();
        }

        else if (Input.GetMouseButtonDown(0) && _krishna)
        {
            Explosive explosive = new Explosive();
            game.AddChild(explosive);
            explosive.SetXY(this.x, this.y - this.height / 2 + 20);
            explosive.SetRotation();
        }
    }

    private void handleShifting()
    {
        if (Input.GetKeyUp(Key.LEFT_SHIFT) && _shiva)
        {
            _ganesh = true;
            _shiva = false;
            SetFrame(1);
        }

        else if (Input.GetKeyUp(Key.LEFT_SHIFT) && _ganesh)
        {
            _krishna = true;
            _ganesh = false;
            SetFrame(2);
        }

        else if (Input.GetKeyUp(Key.LEFT_SHIFT) && _krishna)
        {
            _shiva = true;
            _krishna = false;
            SetFrame(0);
        }
    }

    void Update()
    {
        handleShifting();
        handleMovement();
        handleShooting();
    }
    void OnCollision(GameObject other)
    {
        if (other is Enemy)
        {
            _health--;
            other.Destroy();
        }
    }

    public int GetKarma()
    {
        return _karma;
    }
}