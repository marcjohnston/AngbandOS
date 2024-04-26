// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class SpToHpRandomMutation : Mutation
{
    private SpToHpRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You are subject to fits of magical healing.";
    public override string HaveMessage => "Your blood sometimes rushes to your muscles.";
    public override string LoseMessage => "You are no longer subject to fits of magical healing.";

    public override void OnProcessWorld()
    {
        if (base.Game.DieRoll(2000) != 1)
        {
            return;
        }
        int wounds = Game.MaxHealth.IntValue - Game.Health.IntValue;
        if (wounds <= 0)
        {
            return;
        }
        int healing = Game.Mana.IntValue;
        if (healing > wounds)
        {
            healing = wounds;
        }
        Game.RestoreHealth(healing);
        Game.Mana.IntValue -= healing;
    }
}