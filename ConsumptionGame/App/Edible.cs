using System;
using Microsoft.Xna.Framework;

namespace ConsumptionGame.App;

public class Edible {
    public Vector2 WorldPosition {get; /*protected*/ set; }
    public float Rotation { get; protected set; }
    // TODO: figure out how we can use Doubles or larger with Vectors -- do we need to overload Vector2?
    public float Size {get; /*protected*/ set; }
    public float Density { get; protected set; }
    public TimeSpan AliveTime { get; protected set; }

    public float Mass {
            // TODO: Check balancing of using ^2 vs ^3. 
        get => Size * Size * Density;
    }

    public Edible(Vector2 pos, float size) {
        WorldPosition = pos;
        Size = size;
        Density = 1;
        AliveTime = TimeSpan.Zero;
        // Make sure that the blob is facing upwards.
        Rotation = MathHelper.PiOver2;
    }

    public void Update(GameTime gameTime) {
        AliveTime += gameTime.ElapsedGameTime;
    }

    public bool Intersects(Edible other) {
        float distanceSquared = (this.WorldPosition - other.WorldPosition).LengthSquared();
        float sizeSumSquared = (this.Size + other.Size) * (this.Size + other.Size) * 0.25f;
        return (distanceSquared >= sizeSumSquared);
    }
}