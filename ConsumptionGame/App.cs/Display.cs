using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ConsumptionGame.App;

class Display {
    private static SpriteBatch Pen;

    public static void Initialize(SpriteBatch sb) {
        Pen = sb;
    }

    public static void Player(Vector2 pos, int size) {
        Rectangle bounds = new Rectangle((int)pos.X - size / 2, (int)pos.Y - size / 2, size, size);
        Pen.Draw(Asset.Player, bounds, new Rectangle(0, 0, 400, 400), Color.White);
    }
}