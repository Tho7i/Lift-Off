using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Explosive : Sprite
{
    private float _explosiveSpeed;
    private float _mouseDirection;
    private float _mouseAngle;
    private float _mouseX;
    private float _mouseY;

    public Explosive() : base("circle.png")
    {
        SetScaleXY(0.5f, 0.5f);
        SetOrigin(this.width / 2, this.height / 2);
        _mouseX = Input.mouseX;
        _mouseY = Input.mouseY;
        _explosiveSpeed = 5.0f;
    }

    public void SetRotation()
    {
        _mouseDirection = Mathf.Atan2(Input.mouseY - this.y, Input.mouseX - this.x);
        _mouseAngle = (_mouseDirection * (180 / Mathf.PI));
        this.rotation = _mouseAngle;
    }

    void Update()
    {
        Move(_explosiveSpeed, 0.0f);
        if (Mathf.Abs(this.x - _mouseX) < 2)
        {
            _explosiveSpeed = 0.0f;

        }
        if (x < 0 || x > game.width || y < 0 || y > game.width)
        {
            LateDestroy();
        }
    }
}