// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfLeatherGlovesCalfskinFixedArtifact : FixedArtifact
{
    private ItemFactory _baseItemCategory;
    private SetOfLeatherGlovesCalfskinFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<LeatherGlovesArmorItemFactory>();
    }


    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CloseBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "The Set of Leather Gloves 'Calfskin'";
    public override int Ac => 1;
    public override bool Con => true;
    public override int Cost => 36000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Calfskin'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 2;
    public override int Rarity => 6;
    public override bool ShowMods => true;
    public override bool Str => true;
    public override int ToA => 15;
    public override int ToD => 8;
    public override int ToH => 8;
    public override int Weight => 5;
}