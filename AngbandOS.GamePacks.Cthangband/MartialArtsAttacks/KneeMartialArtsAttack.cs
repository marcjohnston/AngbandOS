// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KneeMartialArtsAttack : MartialArtsAttackGameConfiguration
{
    public override int Chance => 5;
    public override int Dd => 2;
    public override string Desc => "You hit {0} with your knee.";
    public override int Ds => 3;
    public override string MartialArtsEffectBindingKey => nameof(MartialArtsEffectsEnum.KneeMartialArtsEffect);
    public override int MinLevel => 5;
}
