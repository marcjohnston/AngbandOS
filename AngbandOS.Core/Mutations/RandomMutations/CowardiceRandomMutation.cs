// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class CowardiceRandomMutation : Mutation
{
    private CowardiceRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You become an incredible coward!";
    public override string HaveMessage => "You are subject to cowardice.";
    public override string LoseMessage => "You are no longer an incredible coward!";
    public override MutationGroup Group => MutationGroup.Bravery;

    public override void ProcessWorld()
    {
        if (base.Game.DieRoll(3000) != 13)
        {
            return;
        }
        if (Game.HasFearResistance || Game.HeroismTimer.Value != 0 || Game.SuperheroismTimer.Value != 0)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("It's so dark... so scary!");
        Game.FearTimer.AddTimer(13 + base.Game.DieRoll(26));
    }
}