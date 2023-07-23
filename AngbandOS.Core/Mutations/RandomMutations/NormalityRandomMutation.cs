// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class NormalityRandomMutation : Mutation
{
    private NormalityRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 3;
    public override string GainMessage => "You feel strangely normal.";
    public override string HaveMessage => "You may be chaotic, but you're recovering.";
    public override string LoseMessage => "You feel normally strange.";

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (Program.Rng.DieRoll(5000) == 1)
        {
            saveGame.Dna.LoseMutation();
        }
    }
}