﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class EarthquakeActiveMutation : Mutation
{
    private EarthquakeActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(12, 12, Ability.Strength, 16))
        {
            return;
        }
        if (!saveGame.IsQuest(saveGame.CurrentDepth) && saveGame.CurrentDepth != 0)
        {
            saveGame.Earthquake(saveGame.MapY, saveGame.MapX, 10);
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 12 ? "earthquake       (unusable until level 12)" : "earthquake       (cost 12, STR based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You gain the ability to wreck the dungeon.";
    public override string HaveMessage => "You can bring down the dungeon around your ears.";
    public override string LoseMessage => "You lose the ability to wreck the dungeon.";
}