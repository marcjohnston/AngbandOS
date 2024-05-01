// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class HalluRandomMutation : Mutation
{
    private HalluRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You are afflicted by a hallucinatory insanity!";
    public override string HaveMessage => "You have a hallucinatory insanity.";
    public override string LoseMessage => "You are no longer afflicted by a hallucinatory insanity!";

    public override void ProcessWorld()
    {
        if (base.Game.DieRoll(6400) != 42)
        {
            return;
        }
        if (Game.HasChaosResistance)
        {
            return;
        }
        Game.Disturb(false);
        Game.SingletonRepository.Get<FlaggedAction>(nameof(PrExtraRedrawActionGroupSetFlaggedAction)).Set();
        Game.HallucinationsTimer.AddTimer(base.Game.RandomLessThan(50) + 20);
    }
}