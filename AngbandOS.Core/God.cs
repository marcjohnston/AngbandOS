﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core;

[Serializable]
internal abstract class God : IGetKey
{
    protected readonly Game Game;
    protected God(Game game)
    {
        Game = game;
    }

    public abstract string LongName { get; }
    public abstract string ShortName { get; }
    private const int PatronMultiplier = 2;

    public int AdjustedFavour
    {
        get
        {
            if (Favor <= 0)
            {
                return 0;
            }
            var adjusted = IsPatron ? Favor * PatronMultiplier : Favor;
            return Math.Min(adjusted.ToString().Length, 10);
        }
    }

    public int Favor { get; set; }
    public bool IsPatron { get; set; }
    public int RestingFavor { get; set; }

    public abstract string FavorDescription { get; }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
    }

    public string ToJson()
    {
        GodGameConfiguration definition = new GodGameConfiguration()
        {
            LongName = LongName,
            ShortName = ShortName,
            Key = Key,
            FavorDescription = FavorDescription
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }
}