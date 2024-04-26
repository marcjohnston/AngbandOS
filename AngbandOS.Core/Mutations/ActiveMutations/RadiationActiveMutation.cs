// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class RadiationActiveMutation : Mutation
{
    private RadiationActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(15, 15, Ability.Constitution, 14))
        {
            return;
        }
        Game.MsgPrint("Radiation flows from your body!");
        Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(NukeProjectile)), 0, Game.ExperienceLevel.IntValue * 2, 3 + (Game.ExperienceLevel.IntValue / 20));
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 15
            ? "produce radiation   (unusable until level 15)"
            : "produce radiation   (cost 15, CON based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You start emitting hard radiation.";
    public override string HaveMessage => "You can emit hard radiation at will.";
    public override string LoseMessage => "You stop emitting hard radiation.";
}