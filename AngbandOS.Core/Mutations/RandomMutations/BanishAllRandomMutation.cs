// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class BanishAllRandomMutation : Mutation
{
    private BanishAllRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You feel a terrifying power lurking behind you.";
    public override string HaveMessage => "You sometimes cause nearby creatures to vanish.";
    public override string LoseMessage => "You no longer feel a terrifying power lurking behind you.";

    public override void ProcessWorld()
    {
        if (base.Game.DieRoll(9000) != 1)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("You suddenly feel almost lonely.");
        Game.RunScriptInt(nameof(BanishMonsters4xScript), 100);
        Game.MsgPrint(null);
    }
}