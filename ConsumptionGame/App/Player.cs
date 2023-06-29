using System;
using Microsoft.Xna.Framework;

using ConsumptionGame.App.Util;

namespace ConsumptionGame.App;

public class Player : Edible {
    public float Speed { get => Size / 50; }

    public Player() : base(BigVector.Zero, 50) {}

    public void Eat(Edible other) {
        float newMass = this.Mass + other.Mass;
        this.Size = MathF.Sqrt(newMass / Density);
    }
}