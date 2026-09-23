// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class HellfireMutationAttackType : MutationAttackType
{
    private HellfireMutationAttackType(Game game) : base(game) { }

    public override string Title => "Hellfire";

    public override void ApplyToMonster(Monster monster, int damage, out bool fear, out bool monsterDies)
    {
        fear = false;
        monsterDies = false;

        Projectile projectile =
            Game.SingletonRepository.Get<Projectile>(
                nameof(HellfireProjectile));

        projectile.Fire(
            null, 0, monster.MapY, monster.MapX, damage,
            kill: true,
            jump: false,
            beam: false,
            thru: false,
            hide: false,
            grid: false,
            item: false,
            stop: false);
    }
}
