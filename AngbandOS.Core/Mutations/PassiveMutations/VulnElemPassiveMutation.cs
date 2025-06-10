// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class VulnElemPassiveMutation : Mutation
{
    private VulnElemPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You feel strangely exposed.";
    public override string HaveMessage => "You are susceptible to damage from the elements.";
    public override string LoseMessage => "You feel less exposed.";

    public override void OnGain()
    {
        Game.Vulnerable = true;
    }

    public override void OnLose()
    {
        Game.Vulnerable = false;
    }
}