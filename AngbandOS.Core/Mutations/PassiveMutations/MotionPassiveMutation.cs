// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class MotionPassiveMutation : Mutation
{
    private MotionPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 3;
    public override string GainMessage => "You move with new assurance.";
    public override string HaveMessage => "Your movements are precise and forceful (+1 STL).";
    public override string LoseMessage => "You move with less assurance.";

    public override void OnGain()
    {
        Game.StealthBonus += 1;
        Game.MutationFreeAction = true;
    }

    public override void OnLose()
    {
        Game.StealthBonus -= 1;
        Game.MutationFreeAction = false;
    }
}