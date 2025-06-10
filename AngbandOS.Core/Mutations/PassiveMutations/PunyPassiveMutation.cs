// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class PunyPassiveMutation : Mutation
{
    private PunyPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 3;
    public override string GainMessage => "Your muscles wither away...";
    public override string HaveMessage => "You are puny (-4 STR).";
    public override string LoseMessage => "Your muscles revert to normal.";
    public override MutationGroupEnum Group => MutationGroupEnum.Strength;

    public override void OnGain()
    {
        Game.StrengthBonus -= 4;
    }

    public override void OnLose()
    {
        Game.StrengthBonus += 4;
    }
}