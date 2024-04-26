// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class SpitAcidActiveMutation : Mutation
{
    private SpitAcidActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(9, 9, Ability.Dexterity, 15))
        {
            return;
        }
        Game.MsgPrint("You spit acid...");
        if (Game.GetDirectionWithAim(out int dir))
        {
            Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)), dir, Game.ExperienceLevel.IntValue, 1 + (Game.ExperienceLevel.IntValue / 30));
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 9
            ? "spit acid        (unusable until level 9)"
            : $"spit acid        (cost 9, dam {lvl}, DEX based)";
    }

    public override int Frequency => 4;
    public override string GainMessage => "You gain the ability to spit acid.";
    public override string HaveMessage => "You can spit acid (dam lvl).";
    public override string LoseMessage => "You lose the ability to spit acid.";
}