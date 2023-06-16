// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Folk;

[Serializable]
internal class FolkSpellZap : Spell
{
    private FolkSpellZap(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        int beam;
        switch (SaveGame.Player.BaseCharacterClass.ID)
        {
            case CharacterClass.Mage:
                beam = SaveGame.Player.Level;
                break;

            case CharacterClass.HighMage:
                beam = SaveGame.Player.Level + 10;
                break;

            default:
                beam = SaveGame.Player.Level / 2;
                break;
        }
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBoltOrBeam(beam - 10, SaveGame.SingletonRepository.Projectiles.Get<ElecProjectile>(), dir, Program.Rng.DiceRoll(3 + ((SaveGame.Player.Level - 1) / 5), 3));
    }

    public override string Name => "Zap";
    
    protected override string? Info()
    {
        return $"dam {3 + ((SaveGame.Player.Level - 1) / 5)}d3";
    }
}