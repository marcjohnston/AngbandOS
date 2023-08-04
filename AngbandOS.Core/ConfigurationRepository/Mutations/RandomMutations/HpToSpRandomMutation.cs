// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class HpToSpRandomMutation : Mutation
{
    private HpToSpRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You are subject to fits of painful clarity.";
    public override string HaveMessage => "Your blood sometimes rushes to your head.";
    public override string LoseMessage => "You are no longer subject to fits of painful clarity.";

    public override void OnProcessWorld()
    {
        if (SaveGame.HasAntiMagic || base.SaveGame.Rng.DieRoll(4000) != 1)
        {
            return;
        }
        int wounds = SaveGame.MaxMana - SaveGame.Mana;
        if (wounds <= 0)
        {
            return;
        }
        int healing = SaveGame.Health;
        if (healing > wounds)
        {
            healing = wounds;
        }
        SaveGame.Mana += healing;
        SaveGame.TakeHit(healing, "blood rushing to the head");
    }
}