﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class NetherBallMonsterSpell : BallProjectileMonsterSpell
{
    private NetherBallMonsterSpell(Game game) : base(game) { }
    public override bool UsesNether => true;
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} casts an nether ball at {3}";
    public override string? VsPlayerActionMessage => "{0} casts an nether ball.";
    protected override string ProjectileKey => nameof(NetherProjectile);
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return 50 + Game.DiceRoll(10, 10) + monsterLevel;
    }
    protected override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(NethSpellResistantDetection) };
}
