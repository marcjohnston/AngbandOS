// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfElementalPowerIceFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private RingOfElementalPowerIceFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<NenyaRingItemFactory>();
    }


    // Ring of Elemental Ice casts a coldball
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("The ring glows bright white...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), dir, 200, 3);
        item.RechargeTimeLeft = SaveGame.Rng.RandomLessThan(325) + 325;
    }
    public string DescribeActivationEffect() => "large frost ball (200) every 325+d325 turns";

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
        item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
    }

    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<EqualSignSymbol>();
    public override string Name => "The Ring of Elemental Power (Ice)";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 200000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override bool Feather => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Elemental Power (Ice)";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImCold => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 80;
    public override int Pval => 2;
    public override int Rarity => 40;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool SustInt => true;
    public override bool SustWis => true;
    public override int ToA => 0;
    public override int ToD => 11;
    public override int ToH => 11;
    public override int Weight => 2;
    public override bool Wis => true;
}