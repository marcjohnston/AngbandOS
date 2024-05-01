// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfCestiOfCombatFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private SetOfCestiOfCombatFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(CestiGlovesArmorItemFactory);

    // Cesti shoot arrows
    public void ActivateItem(Item item)
    {
        Game.MsgPrint("Your cesti grows magical spikes...");
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(ArrowProjectile)), dir, 150);
        item.RingsArmorActivationAndFixedArtifactsRechargeTimeLeft = base.Game.RandomLessThan(90) + 90;
    }
    public override void ApplyResistances(Item item)
    {
        item.RandomPower = Game.SingletonRepository.ToWeightedRandom<Power>(_power => _power.IsAbility == true).Choose();
    }
    public string DescribeActivationEffect => "a magical arrow (150) every 90+d90 turns";

    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Set of Cesti of Combat";
    public override int Ac => 5;
    public override bool Activate => true;
    public override int Cost => 110000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Combat";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int InitialTypeSpecificValue => 4;
    public override int Rarity => 15;
    public override bool ResAcid => true;
    public override bool ShowMods => true;
    public override int ToA => 20;
    public override int ToD => 10;
    public override int ToH => 10;
    public override int Weight => 40;
}
