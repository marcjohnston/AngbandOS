// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class MagicResPassiveMutation : Mutation
{
    private MagicResPassiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 2;
    public override string GainMessage => "You become resistant to magic.";
    public override string HaveMessage => "You are resistant to magic.";
    public override string LoseMessage => "You become susceptible to magic again.";

    public override void OnGain()
    {
        SaveGame.MagicResistance = true;
    }

    public override void OnLose()
    {
        SaveGame.MagicResistance = false;
    }
}