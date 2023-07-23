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
    private SpToHpRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 2;
    public override string GainMessage => "You are subject to fits of magical healing.";
    public override string HaveMessage => "Your blood sometimes rushes to your muscles.";
    public override string LoseMessage => "You are no longer subject to fits of magical healing.";

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (Program.Rng.DieRoll(2000) != 1)
        {
            return;
        }
        int wounds = saveGame.MaxHealth - saveGame.Health;
        if (wounds <= 0)
        {
            return;
        }
        int healing = saveGame.Mana;
        if (healing > wounds)
        {
            healing = wounds;
        }
        saveGame.RestoreHealth(healing);
        saveGame.Mana -= healing;
    }
}