// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellMalediction : Spell
{
    private DeathSpellMalediction(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<HellFireProjectile>(), dir,
            Program.Rng.DiceRoll(3 + ((SaveGame.Player.Level - 1) / 5), 3), 0);
        if (Program.Rng.DieRoll(5) != 1)
        {
            return;
        }
        int dummy = Program.Rng.DieRoll(1000);
        if (dummy == 666)
        {
            SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get<DeathRayProjectile>(), dir, SaveGame.Player.Level);
        }
        if (dummy < 500)
        {
            SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get<TurnAllProjectile>(), dir, SaveGame.Player.Level);
        }
        if (dummy < 800)
        {
            SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get<OldConfProjectile>(), dir, SaveGame.Player.Level);
        }
        SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get<StunProjectile>(), dir, SaveGame.Player.Level);
    }

    public override string Name => "Malediction";
    
    protected override string? Info()
    {
        return $"dam {3 + ((SaveGame.Player.Level - 1) / 5)}d3";
    }
}