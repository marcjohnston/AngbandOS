// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class WalkShadRandomMutation : Mutation
{
    private WalkShadRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You feel like reality is as thin as paper.";
    public override string HaveMessage => "You occasionally stumble into other shadows.";
    public override string LoseMessage => "You feel like you're trapped in reality.";

    public override void OnProcessWorld()
    {
        if (!SaveGame.HasAntiMagic && base.SaveGame.Rng.DieRoll(12000) == 1)
        {
            SaveGame.AlterReality();
        }
    }
}