// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class XtraFatPassiveMutation : Mutation
{
    private XtraFatPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You become sickeningly fat!";
    public override string HaveMessage => "You are extremely fat (+2 CON, -2 speed).";
    public override string LoseMessage => "You benefit from a miracle diet!";

    public override void OnGain()
    {
        Game.ConstitutionBonus += 2;
        Game.SpeedBonus -= 2;
    }

    public override void OnLose()
    {
        Game.ConstitutionBonus -= 2;
        Game.SpeedBonus += 2;
    }
}