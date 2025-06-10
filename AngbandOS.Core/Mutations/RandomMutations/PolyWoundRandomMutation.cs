// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class PolyWoundRandomMutation : Mutation
{
    private PolyWoundRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You feel forces of chaos entering your old scars.";
    public override string HaveMessage => "Your health is subject to chaotic forces.";
    public override string LoseMessage => "You feel forces of chaos departing your old scars.";

    public override void ProcessWorld()
    {
        if (base.Game.DieRoll(3000) == 1)
        {
            Game.RunScript(nameof(PolymorphWoundsScript));
        }
    }
}