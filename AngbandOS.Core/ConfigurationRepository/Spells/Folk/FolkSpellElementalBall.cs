// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Folk;

[Serializable]
internal class FolkSpellElementalBall : Spell
{
    private FolkSpellElementalBall(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Projectile dummy;
        switch (SaveGame.Rng.DieRoll(4))
        {
            case 1:
                dummy = SaveGame.SingletonRepository.Projectiles.Get<FireProjectile>();
                break;

            case 2:
                dummy = SaveGame.SingletonRepository.Projectiles.Get<ElecProjectile>();
                break;

            case 3:
                dummy = SaveGame.SingletonRepository.Projectiles.Get<ColdProjectile>();
                break;

            default:
                dummy = SaveGame.SingletonRepository.Projectiles.Get<AcidProjectile>();
                break;
        }
        SaveGame.FireBall(dummy, dir, 75 + SaveGame.ExperienceLevel, 2);
    }

    public override string Name => "Teleport Away";
    
    protected override string? Info()
    {
        return $"dam {75 + SaveGame.ExperienceLevel}";
    }
}