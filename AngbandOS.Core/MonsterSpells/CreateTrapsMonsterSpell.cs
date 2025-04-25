// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class CreateTrapsMonsterSpell : MonsterSpell
{
    private CreateTrapsMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "Someone mumbles and then cackles evilly.";
    public override string? VsPlayerActionMessage => "{0} casts a spell and cackles evilly.";

    public override void ExecuteOnPlayer(Monster monster)
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(MakeTrapProjectile));
        projectile.Fire(0, 1, Game.MapY.IntValue, Game.MapX.IntValue, 0, grid: true, item: true, hide: true, jump: false, beam: false, thru: false, kill: false, stop: false);
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(MakeTrapProjectile));
        projectile.Fire(0, 1, target.MapY, target.MapX, 0, grid: true, item: true, hide: true, jump: false, beam: false, thru: false, kill: false, stop: false);
    }
}
