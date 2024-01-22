// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class IronCrownOfMiseryFixedArtifact : FixedArtifact
{
    private ItemFactory _baseItemCategory;
    private IronCrownOfMiseryFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Bind()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(IronCrownArmorItemFactory));
    }


    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
        item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
    }
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "The Iron Crown of Misery";
    public override int Ac => 0;
    public override bool Con => true;
    public override int Cost => 0;
    public override bool Cursed => true;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Misery";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => -25;
    public override int Rarity => 12;
    public override bool SeeInvis => true;
    public override bool Str => true;
    public override bool Telepathy => true;
    public override int ToA => 25;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 20;
}
