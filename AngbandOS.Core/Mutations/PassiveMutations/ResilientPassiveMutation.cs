// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class ResilientPassiveMutation : Mutation
{
    private ResilientPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You become extraordinarily resilient.";
    public override string HaveMessage => "You are very resilient (+4 CON).";
    public override string LoseMessage => "You become ordinarily resilient again.";

    public override void OnGain()
    {
        Game.ConstitutionBonus += 4;
    }

    public override void OnLose()
    {
        Game.ConstitutionBonus -= 4;
    }
}