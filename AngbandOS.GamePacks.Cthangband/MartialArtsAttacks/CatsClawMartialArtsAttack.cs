// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CatsClawMartialArtsAttack : MartialArtsAttackGameConfiguration
{
    public override int Chance => 20;
    public override int Dd => 5;
    public override string Desc => "You hit {0} with a Cat's Claw.";
    public override int Ds => 5;
    public override string MartialArtsEffectBindingKey => nameof(MartialArtsEffectsEnum.Stun0MartialArtsEffect);
    public override int MinLevel => 20;
}
