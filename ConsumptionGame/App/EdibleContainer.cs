using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using ConsumptionGame.App.Util;

namespace ConsumptionGame.App;

public static class EdibleContainer {
    public static Player PlayingEdible;
    public static List<Edible> Edibles;
    
    private static Random RNG = new();

    public static void Initialize() {
        PlayingEdible = new(1.0);
        Edibles = new List<Edible>();

        for (int i = 0; i < 25; i++) CreateRandomEdible();
    }

    private static void CreateRandomEdible() {
        Vector2 position = new Vector2(
            1 - 2 * RNG.NextDouble(),
            1 - 2 * RNG.NextDouble()
        );
        position *= 50 * PlayingEdible.Size;
        position += PlayingEdible.WorldPosition;

        double size = RNG.NextDouble() * 2.5 * PlayingEdible.Size;
        if (RNG.Next() % 2 == 1) size *= 10;

        Edibles.Add(new Edible(size, position));
    }

    public static void Update(GameTime _gameTime) {
        CheckIntersections();
    }

    public static void CheckIntersections() {
        for (int i = Edibles.Count - 1; i >= 0; i--) {
            Edible edible = Edibles[i];
            if (!PlayingEdible.Intersects(edible)) continue;
            PlayingEdible.Size += 1;
            Edibles.RemoveAt(i);
            CreateRandomEdible();
        }
    }
}