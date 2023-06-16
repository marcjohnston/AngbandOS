// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life;

[Serializable]
internal class LifeSpellHealingTrue : Spell
{
    private LifeSpellHealingTrue(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.Player.RestoreHealth(2000);
        SaveGame.Player.TimedStun.ResetTimer();
        SaveGame.Player.TimedBleeding.ResetTimer();
    }

    public override string Name => "Healing True";
    
    protected override string? Info()
    {
        return "heal 2000";
    }
}