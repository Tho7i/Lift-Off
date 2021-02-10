using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class Level : GameObject
{
    public Level() : base()
    {
        Player player = new Player();
        AddChild(player);
    }
}
