// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class EarthquakeActiveMutation : Mutation
{
    private EarthquakeActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(12, 12, AbilityEnum.Strength, 16))
        {
            return;
        }
        if (!Game.IsQuest(Game.CurrentDepth) && Game.CurrentDepth != 0)
        {
            Game.Earthquake(Game.MapY.IntValue, Game.MapX.IntValue, 10);
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