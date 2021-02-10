using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Projectile : Sprite
{
    float mouseDirection;
    float mouseAngle;

    public Projectile() : base("triangle.png")
    {
        SetScaleXY(0.2f, 0.2f);
        SetOrigin(0, height / 2f);
    }

    public void SetRotation()
    {
        mouseDirection = Mathf.Atan2(Input.mouseY - this.y, Input.mouseX - this.x);
        mouseAngle = (mouseDirection * (180 / Mathf.PI));
        this.rotation = mouseAngle;
    }

    void Update()
    {
        Move(7.0f, 0.0f);
        if (this.x > game.width || this.x < 0 || this.y < 0 || this.y > game.height)
        {
            this.LateDestroy();
        }
    }
}
