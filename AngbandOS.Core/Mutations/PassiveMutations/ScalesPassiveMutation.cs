// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class ScalesPassiveMutation : Mutation
{
    private ScalesPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 3;
    public override string GainMessage => "Your skin turns into black scales!";
    public override string HaveMessage => "Your skin has turned into scales (-1 CHR, +10 AC).";
    public override string LoseMessage => "Your scales vanish!";
    public override MutationGroupEnum Group => MutationGroupEnum.Skin;

    public override void OnGain()
    {
        Game.CharismaBonus -= 1;
        Game.GenomeArmorClassBonus += 10;
    }

    public override void OnLose()
    {
        Game.CharismaBonus += 1;
        Game.GenomeArmorClassBonus -= 10;
    }
}