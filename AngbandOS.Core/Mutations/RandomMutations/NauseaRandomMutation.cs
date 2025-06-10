// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class NauseaRandomMutation : Mutation
{
    private NauseaRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "Your stomach starts to roil nauseously.";
    public override string HaveMessage => "You have a seriously upset stomach.";
    public override string LoseMessage => "Your stomach stops roiling.";

    public override void ProcessWorld()
    {
        if (Game.HasSlowDigestion || base.Game.DieRoll(9000) != 1)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("Your stomach roils, and you lose your lunch!");
        Game.MsgPrint(null);
        Game.SetFood(Constants.PyFoodWeak);
    }
}