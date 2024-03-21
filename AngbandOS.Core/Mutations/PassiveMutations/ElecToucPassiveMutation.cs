// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class ElecToucPassiveMutation : Mutation
{
    private ElecToucPassiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 2;
    public override string GainMessage => "Electricity starts running through you!";
    public override string HaveMessage => "Electricity is running through your veins.";
    public override string LoseMessage => "Electricity stops running through you.";

    public override void OnGain()
    {
        SaveGame.ElecHit = true;
    }

    public override void OnLose()
    {
        SaveGame.ElecHit = false;
    }
}