// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellEvocation : Spell
{
    private DeathSpellEvocation(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.DispelMonsters(SaveGame.Player.Level * 4);
        SaveGame.TurnMonsters(SaveGame.Player.Level * 4);
        SaveGame.BanishMonsters(SaveGame.Player.Level * 4);
    }

    public override void CastFailed()
    {
        DoWildDeathMagic(28, 3);
    }

    public override string Name => "Evocation";
    
    protected override string? Info()
    {
        return $"dam {SaveGame.Player.Level * 4}";
    }
}