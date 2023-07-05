using System;
using Microsoft.Xna.Framework;

using ConsumptionGame.App.Util;

namespace ConsumptionGame.App;

public class Edible {
    private static Random RNG = new();
    public float Size { get; }
    public Vector2 WorldPosition { get; private set; }
    private TimeSpan AliveTime = new();
    // public string Name { get; }
    private Func<Vector2> MovementBehavior = Vector2() => Vector2.Zero;
    public float Nutrition { get; } = 1F;
    public float Damage { get; private set; } = 1;
    private Color InternalColor { get; }

    public Edible(float size, Vector2 pos) {
        WorldPosition = pos;
        Size = size;
        InternalColor = new Color((uint)(0x80000000 + RNG.Next(0x7FFFFF)));

    }
    
    public void Move(float dx, float dy) => Move(new Vector2(dx, dy));
    public void Move(Vector2 displacement) {
        WorldPosition += displacement;
    }

    public void Update(GameTime gameTime) {
        AliveTime += gameTime.ElapsedGameTime;
    }

}


/*
public class Edible {
    public Vector2 WorldPosition {get; protected set; }
    public float Rotation { get; protected set; }
    // TODO: figure out how we can use Doubles or larger with Vectors -- do we need to overload Vector2?
    public float Size {get; protected set; }
    public float Density { get; protected set; }
    public TimeSpan AliveTime { get; protected set; }

    public Color RenderColor { get; }

    public float Mass {
            // TODO: Check balancing of using ^2 vs ^3. 
        get => Size * Size * Density;
    }

    public Edible(Vector2 pos, float size, Color color) : this(pos, size) {
        RenderColor = color;
    }

    public Edible(Vector2 pos, float size) {
        RenderColor = Color.White;
        WorldPosition = pos;
        Size = size;
        Density = 1;
        AliveTime = TimeSpan.Zero;
        // Make sure that the blob is facing upwards.
        Rotation = MathHelper.PiOver2;
    }

    public virtual void Update(GameTime gameTime) {
        AliveTime += gameTime.ElapsedGameTime;
    }

    public bool Intersects(Edible other) {
        float distance = (this.WorldPosition - other.WorldPosition).Length();
        float sizeSum = MathF.Abs(this.Size + other.Size) * 0.5f;
        return (distance < sizeSum);
    }
}*/