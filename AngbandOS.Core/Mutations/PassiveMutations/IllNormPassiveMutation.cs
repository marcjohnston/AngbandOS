// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class IllNormPassiveMutation : Mutation
{
    private IllNormPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You start projecting a reassuring image.";
    public override string HaveMessage => "Your appearance is masked with illusion.";
    public override string LoseMessage => "You stop projecting a reassuring image.";

    public override void OnGain()
    {
        Game.CharismaAbility.Override = true;
    }

    public override void OnLose()
    {
        Game.CharismaAbility.Override = false;
    }
}