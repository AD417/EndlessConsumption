using System;

using Microsoft.Xna.Framework;

namespace ConsumptionGame.App;

public class Player {
    private float size;
    public float Size { 
        get => size; 
        set {
            size = value;
            if (LargestSize < value) LargestSize = value;
            if (value < 0) isDead = true;
        }
    }
    public float LargestSize { get; private set; }
    public Vector2 WorldPosition { get; private set; } = Vector2.Zero;
    public float EatMultiplier = 1.0F;
    public bool isDead = false;

    public Player(float size) {
        Size = size;
        LargestSize = size;
    }

    public void Move(float dx, float dy) => Move(new Vector2(dx, dy));
    public void Move(Vector2 displacement) {
        WorldPosition += displacement;
    }

    public bool Intersects(Edible edible) {
        float distance = (this.WorldPosition - edible.WorldPosition).Length();
        float sizeSum = (this.Size + edible.Size) * 0.5F;
        return sizeSum > distance;
    }
}