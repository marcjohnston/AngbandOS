// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class RawChaosRandomMutation : Mutation
{
    private RawChaosRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You feel the universe is less stable around you.";
    public override string HaveMessage => "You occasionally are surrounded with raw chaos.";
    public override string LoseMessage => "You feel the universe is more stable around you.";

    public override void ProcessWorld()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(8000) != 1)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("You feel the world warping around you!");
        Game.MsgPrint(null);
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ChaosProjectile)), 0, Game.ExperienceLevel.IntValue, 8);
    }
}