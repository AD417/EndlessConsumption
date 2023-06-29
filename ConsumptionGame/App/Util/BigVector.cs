using System;
using System.Text;

namespace ConsumptionGame.App.Util;

public struct BigVector : IEquatable<BigVector> {

    // TODO: determine if we should use Break Infinity. Unlikely. 
    public double X;
    public double Y;

    public BigVector(double value) : this(value, value) {}
    public BigVector(double x, double y) {
        X = x;
        Y = y;
    }
    
    public static BigVector One { get; } = new(1.0, 1.0);
    public static BigVector Zero { get; } = new(0.0, 0.0);
    public static BigVector UnitX { get; } = new(1.0, 0.0);
    public static BigVector UnitY { get; } = new(0.0, 1.0);

    public static BigVector Add(BigVector value1, BigVector value2) {
        return new BigVector(value1.X + value2.X, value1.Y + value2.Y);
    }
    public static BigVector Clamp(BigVector value, BigVector min, BigVector max) {
        return new BigVector(
            Math.Clamp(value.X, min.X, max.X),
            Math.Clamp(value.Y, min.Y, max.Y)
        );
    }
    public static double Distance(BigVector value1, BigVector value2) {
        return Math.Sqrt(DistanceSquared(value1, value2));
    }
    public static double DistanceSquared(BigVector value1, BigVector value2) {
        double dx = value1.X - value2.X;
        double dy = value1.Y - value2.Y;
        return dx * dx + dy * dy;
    }
    public static BigVector Divide(BigVector value, double divider) {
        return new BigVector(value.X / divider, value.Y / divider);
    }
    public static double Dot(BigVector value1, BigVector value2) {
        return value1.X * value2.X + value1.Y * value2.Y;
    }
    public static BigVector Multiply(BigVector value, double scaleFactor) {
        return new BigVector(value.X * scaleFactor, value.Y * scaleFactor);
    }
    public static BigVector Negate(BigVector value) {
        return new BigVector(-value.X, -value.Y);
    }
    public static BigVector Normalize(BigVector value) {
        double length = value.Length();
        return new BigVector(value.X / length, value.Y / length);
    }
    public static BigVector Subtract(BigVector value1, BigVector value2) {
        return new BigVector(value1.X - value2.X, value1.Y - value2.Y);
    }

    public bool CanBeXna() {
        return Math.Max(X, Y) < float.MaxValue && Math.Min(X, Y) > float.MinValue;
    }
    public void Deconstruct(out double x, out double y) {
        x = X;
        y = Y;
    }
    public bool Equals(BigVector other) {
        return (this.X == other.X && this.Y == other.Y);
    }
    public override bool Equals(object obj) {
        if (obj is BigVector) return this.Equals(obj);
        return false;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public double Length() {
        return Math.Sqrt(LengthSquared());
    }
    public double LengthSquared() {
        return X * X + Y * Y;
    }
    public void Normalize() {
        double length = Length();
        X /= length;
        Y /= length;
    }
    public Microsoft.Xna.Framework.Vector2 ToXna() {
        return new Microsoft.Xna.Framework.Vector2((float)X, (float)Y);
    }
    public override string ToString() => ToString("G");
    public string ToString(string format)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append('<');
        sb.Append(X.ToString(format));
        sb.Append(", ");
        sb.Append(Y.ToString(format));
        sb.Append('>');
        return sb.ToString();
    }

    public static BigVector operator +(BigVector value1, BigVector value2) {
        return new BigVector(value1.X + value2.X, value1.Y + value2.Y);
    }
    public static BigVector operator -(BigVector value) {
        return new BigVector(-value.X, -value.Y);
    }
    public static BigVector operator -(BigVector value1, BigVector value2) {
        return new BigVector(value1.X - value2.X, value1.Y - value2.Y);
    }
    public static BigVector operator *(double scaleFactor, BigVector value) {
        return new BigVector(value.X * scaleFactor, value.Y * scaleFactor);
    }
    public static BigVector operator *(BigVector value, double scaleFactor) {
        return new BigVector(value.X * scaleFactor, value.Y * scaleFactor);
    }
    public static BigVector operator /(BigVector value, double divisor) {
        double inverse = 1 / divisor;
        return new BigVector(value.X * inverse, value.Y * inverse);
    }
    public static bool operator ==(BigVector value1, BigVector value2) {
        return (value1.X == value2.X && value1.Y == value2.Y);
    }
    public static bool operator !=(BigVector value1, BigVector value2) {
        return (value1.X != value2.X || value1.Y != value2.Y);
    }

    public static implicit operator BigVector(Microsoft.Xna.Framework.Vector2 value) {
        return new BigVector(value.X, value.Y);
    }
    public static implicit operator Microsoft.Xna.Framework.Vector2(BigVector value) {
        return new Microsoft.Xna.Framework.Vector2((float)value.X, (float)value.Y);
    }
}