using System;
using Microsoft.Xna.Framework;

using ConsumptionGame.App.Util;

namespace ConsumptionGame.App;

public class Edible {
    public BigVector WorldPosition {get; /*protected*/ set; }
    public float Rotation { get; protected set; }
    // TODO: figure out how we can use Doubles or larger with Vectors -- do we need to overload BigVector?
    public float Size {get; /*protected*/ set; }
    public float Density { get; protected set; }
    public TimeSpan AliveTime { get; protected set; }

    public Color RenderColor { get; }

    public float Mass {
            // TODO: Check balancing of using ^2 vs ^3. 
        get => Size * Size * Density;
    }

    public Edible(BigVector pos, float size, Color color) : this(pos, size) {
        RenderColor = color;
    }

    public Edible(BigVector pos, float size) {
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
        double distance = (this.WorldPosition - other.WorldPosition).Length();
        double sizeSum = MathF.Abs(this.Size + other.Size) * 0.5f;
        return (distance < sizeSum);
    }
}