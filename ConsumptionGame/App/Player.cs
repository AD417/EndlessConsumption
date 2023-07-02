using System;

using ConsumptionGame.App.Util;

namespace ConsumptionGame.App;

public class Player {
    private double size;
    public double Size { 
        get => size; 
        set {
            size = value;
            if (LargestSize < value) LargestSize = value;
        }
    }
    public double LargestSize { get; private set; }
    public Vector2 WorldPosition { get; private set; } = Vector2.Zero;
    public double EatMultiplier = 1.0;

    public Player(double size) {
        Size = size;
        LargestSize = size;
    }

    public void Move(double dx, double dy) => Move(new Vector2(dx, dy));
    public void Move(Vector2 displacement) {
        WorldPosition += displacement;
    }

    public bool Intersects(Edible edible) {
        double distance = (this.WorldPosition - edible.WorldPosition).Length();
        double sizeSum = (this.Size + edible.Size) * 0.5;
        return sizeSum > distance;
    }
}