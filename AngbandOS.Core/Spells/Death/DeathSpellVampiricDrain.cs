// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellVampiricDrain : Spell
{
    private DeathSpellVampiricDrain(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int dummy = SaveGame.Player.Level + (Program.Rng.DieRoll(SaveGame.Player.Level) * Math.Max(1, SaveGame.Player.Level / 10));
        if (!SaveGame.DrainLife(dir, dummy))
        {
            return;
        }
        SaveGame.Player.RestoreHealth(dummy);
        dummy = SaveGame.Player.Food + Math.Min(5000, 100 * dummy);
        if (SaveGame.Player.Food < Constants.PyFoodMax)
        {
            SaveGame.Player.SetFood(dummy >= Constants.PyFoodMax ? Constants.PyFoodMax - 1 : dummy);
        }
    }

    public override string Name => "Vampiric Drain";
    
    protected override string? Info()
    {
        return $"dam {Math.Max(1, SaveGame.Player.Level / 10)}d{SaveGame.Player.Level}+{SaveGame.Player.Level}";
    }
}