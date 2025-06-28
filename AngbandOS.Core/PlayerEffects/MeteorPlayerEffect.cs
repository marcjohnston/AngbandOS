// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class MeteorPlayerEffect : PlayerEffect
{
    private MeteorPlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "Something falls from the sky on you!";
    protected override IdentifiedResultEnum Apply(Monster mPtr, int y, int x, int dam)
    {
        string killer = mPtr.IndefiniteVisibleName;
        Game.TakeHit(dam, killer);
        if (!Game.HasShardResistance || Game.DieRoll(13) == 1)
        {
            if (!Game.HasFireImmunity)
            {
                Game.InvenDamage(Game.SetFireDestroy, 2);
            }
            Game.InvenDamage(Game.SetColdDestroy, 2);
        }
        return IdentifiedResultEnum.True;
    }
}
