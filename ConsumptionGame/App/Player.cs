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
    public BigVector WorldPosition { get; private set; } = BigVector.Zero;
    public double EatMultiplier = 1.0;

    public Player(double size) {
        Size = size;
        LargestSize = size;
    }

    public void Move(double dx, double dy) => Move(new BigVector(dx, dy));
    public void Move(BigVector displacement) {
        WorldPosition += displacement;
    }

    public bool Intersects(Edible edible) {
        double distance = (this.WorldPosition - edible.WorldPosition).Length();
        double sizeSum = (this.Size + edible.Size) * 0.5;
        return sizeSum > distance;
    }
}