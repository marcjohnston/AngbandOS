// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class PoisonBallMonsterSpell : BallProjectileMonsterSpell
{
    private PoisonBallMonsterSpell(Game game) : base(game) { }
    public override bool UsesPoison => true;
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} casts a stinking cloud at {3}";
    public override string? VsPlayerActionMessage => "{0} casts a stinking cloud.";
    protected override string ProjectileKey => nameof(ProjectileNamesEnum.PoisonGasProjectile);
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Game.DiceRoll(12, 2);
    }
    protected override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(PoisSpellResistantDetection) };
}
