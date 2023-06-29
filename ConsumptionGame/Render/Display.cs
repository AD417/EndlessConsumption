using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using ConsumptionGame.App;

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

    public static void Player(Player player) {
        Vector2 pos = ToScreenPos(player.WorldPosition);
        Rectangle bounds = new Rectangle(
            (int)(pos.X - player.Size / 2), 
            (int)(pos.Y - player.Size / 2), 
            (int)player.Size, 
            (int)player.Size
        );
        Pen.Draw(Asset.Player, bounds, new Rectangle(0, 0, 400, 400), Color.White);
    }

    public static void Edible(Edible edible) {
        Vector2 pos = ToScreenPos(edible.WorldPosition);
        Rectangle bounds = new Rectangle(
            (int)(pos.X - edible.Size / 2), 
            (int)(pos.Y - edible.Size / 2), 
            (int)edible.Size, 
            (int)edible.Size
        );
        Pen.Draw(Asset.Edible, bounds, new Rectangle(0, 0, 400, 400), edible.RenderColor);
    }
}