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
        PlayingEdible = new();
        Edibles = new List<Edible>();

        for (int i = 0; i < 25; i++) CreateRandomEdible();
    }

    private static void CreateRandomEdible() {
        int x = RNG.Next(-210, 210);
        int y = RNG.Next(-490, 490);
        int size = RNG.Next(50);
        Color c = new(RNG.Next(127, 255), RNG.Next(255), RNG.Next(255));
        Edibles.Add(new Edible(new BigVector(x, y), size, c));
    }

    public static void Update(GameTime _gameTime) {
        CheckIntersections();
    }

    public static void CheckIntersections() {
        for (int i = Edibles.Count - 1; i >= 0; i--) {
            Edible edible = Edibles[i];
            if (!PlayingEdible.Intersects(edible)) continue;
            PlayingEdible.Eat(edible);
            Edibles.RemoveAt(i);
            CreateRandomEdible();
        }
    }
}