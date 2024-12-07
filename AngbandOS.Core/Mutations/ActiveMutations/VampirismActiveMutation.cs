// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class VampirismActiveMutation : Mutation
{
    private VampirismActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(13, Game.ExperienceLevel.IntValue, AbilityEnum.Constitution, 14))
        {
            return;
        }
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        if (Game.DrainLife(dir, Game.ExperienceLevel.IntValue * 2))
        {
            Game.RestoreHealth(Game.ExperienceLevel.IntValue + base.Game.DieRoll(Game.ExperienceLevel.IntValue));
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 13
            ? "vampiric drain   (unusable until level 13)"
            : $"vampiric drain   (cost {lvl}, CON based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You become vampiric.";
    public override string HaveMessage => "You can drain life from a foe like a vampire.";
    public override string LoseMessage => "You are no longer vampiric.";
}