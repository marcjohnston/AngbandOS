// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class ShortLegPassiveMutation : Mutation
{
    private ShortLegPassiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 2;
    public override string GainMessage => "Your legs turn into short stubs!";
    public override string HaveMessage => "Your legs are short stubs (-3 speed).";
    public override string LoseMessage => "Your legs lengthen to normal.";

    public override void OnGain()
    {
        SaveGame.SpeedBonus -= 3;
    }

    public override void OnLose()
    {
        SaveGame.SpeedBonus += 3;
    }
}