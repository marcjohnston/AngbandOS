// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ManaBallMonsterSpell : BallProjectileMonsterSpell
{
    private ManaBallMonsterSpell(Game game) : base(game) { }
    public override bool IsAttack => true;

    /// <summary>
    /// Returns a message that the monster mumbles powerfully.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public override string? VsPlayerBlindMessage => "You hear someone mumble powerfully.";
    public override string? VsPlayerActionMessage => "{0} invokes a mana storm.";
    /// <summary>
    /// Returns a message that the player hears someone powerfully.  The player does not know either monster.
    /// </summary>
    public override string? VsMonsterUnseenMessage => "You hear someone mumble powerfully.";
    public override string? VsMonsterSeenMessage => "{0} invokes a mana storm at {3}";
    protected override string ProjectileKey => nameof(ManaProjectile);
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return (monsterLevel * 5) + Game.DiceRoll(10, 10);
    }
    protected override int Radius => 4;
}
