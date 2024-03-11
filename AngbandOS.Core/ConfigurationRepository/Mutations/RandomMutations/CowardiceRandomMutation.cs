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
    private CowardiceRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You become an incredible coward!";
    public override string HaveMessage => "You are subject to cowardice.";
    public override string LoseMessage => "You are no longer an incredible coward!";
    public override MutationGroup Group => MutationGroup.Bravery;

    public override void OnProcessWorld()
    {
        if (base.SaveGame.DieRoll(3000) != 13)
        {
            return;
        }
        if (SaveGame.HasFearResistance || SaveGame.TimedHeroism.Value != 0 || SaveGame.TimedSuperheroism.Value != 0)
        {
            return;
        }
        SaveGame.Disturb(false);
        SaveGame.MsgPrint("It's so dark... so scary!");
        base.SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawAfraidFlaggedAction)).Set();
        SaveGame.TimedFear.AddTimer(13 + base.SaveGame.DieRoll(26));
    }
}