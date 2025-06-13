// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlyingKickMartialArtsAttack : MartialArtsAttackGameConfiguration
{
    public override int Chance => 35;
    public override int Dd => 8;
    public override string Desc => "You hit {0} with a flying kick.";
    public override int Ds => 10;
    public override string MartialArtsEffectBindingKey => nameof(MartialArtsEffectsEnum.Stun6p1d6MartialArtsEffect);
    public override int MinLevel => 41;
}
