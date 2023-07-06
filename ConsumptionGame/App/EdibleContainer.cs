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
        PlayingEdible = new(100F);
        Edibles = new List<Edible>();

        // for (int i = 0; i < 25; i++) CreateRandomEdible();
    }

    public static void CheckPopulation() {
        if (Edibles.Count < 1000) {
            for (int i = 0; i < 10; i++) {
                CreateRandomEdible();
            }
        }
    }

    public static void CreateRandomEdible() {
        Vector2 position = new Vector2(
            1F - 2F * RNG.NextSingle(),
            1F - 2F * RNG.NextSingle()
        );
        position *= 100F * PlayingEdible.Size;
        position += PlayingEdible.WorldPosition;

        float size = RNG.NextSingle() * PlayingEdible.Size;
        if (RNG.Next() % 3 == 1) size *= 10;
        size += 1.0F;

        Edible e = new Edible(size, position);
        if (!PlayingEdible.Intersects(e)) Edibles.Add(e);
    }
}