using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ConsumptionGame.Render;

class Display {
    private static SpriteBatch Pen;

    public static void Initialize(SpriteBatch sb) {
        Pen = sb;
    }

    private static Vector2 ToScreenPos(Vector2 pos) {
        // TODO: determine how to fix scaling for larger screens.
        return new Vector2(pos.X + 210, pos.Y + 490);
    }

    public static void Player(Vector2 pos, int size) {
        pos = ToScreenPos(pos);
        Rectangle bounds = new Rectangle((int)pos.X - size / 2, (int)pos.Y - size / 2, size, size);
        Pen.Draw(Asset.Player, bounds, new Rectangle(0, 0, 400, 400), Color.White);
    }
}