// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class AcidBallMonsterSpell : BallProjectileMonsterSpell
{
    private AcidBallMonsterSpell(Game game) : base(game) { }
    public override bool UsesAcid => true;
    public override bool IsAttack => true;
    protected override string ActionName => "casts an acid ball";
    protected override string ProjectileKey => nameof(AcidProjectile);
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Game.DieRoll(monsterLevel * 3) + 15;
    }
    protected override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(AcidSpellResistantDetection) };
}
