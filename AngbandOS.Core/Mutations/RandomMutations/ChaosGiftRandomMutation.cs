// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class ChaosGiftRandomMutation : Mutation
{
    private ChaosGiftRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You attract the notice of a chaos deity!";
    public override string HaveMessage => "Chaos deities give you gifts.";
    public override string LoseMessage => "You lose the attention of the chaos deities.";

    public override void OnGain()
    {
        Game.ChaosGift = true;
    }

    public override void OnLose()
    {
        Game.ChaosGift = false;
    }
}