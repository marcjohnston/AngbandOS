// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class AlbinoPassiveMutation : Mutation
{
    private AlbinoPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You turn into an albino! You feel frail...";
    public override string HaveMessage => "You are albino (-4 CON).";
    public override string LoseMessage => "You are no longer an albino!";

    public override void OnGain()
    {
        Game.ConstitutionBonus -= 4;
    }

    public override void OnLose()
    {
        Game.ConstitutionBonus += 4;
    }
}