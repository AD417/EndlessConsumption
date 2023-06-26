using System;
using Microsoft.Xna.Framework;

namespace ConsumptionGame.App;

public class Player : Edible {
    public Player() : base(Vector2.Zero, 1) {}

    public void Eat(Edible other) {
        float newMass = this.Mass + other.Mass;
        this.Size = MathF.Sqrt(newMass / Density);
    }
}