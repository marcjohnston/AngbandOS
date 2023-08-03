// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PairOfMetalShodBootsOfTheBlackReaverFixedArtifact : FixedArtifact
{
    private ItemFactory _baseItemCategory;
    private PairOfMetalShodBootsOfTheBlackReaverFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<MetalShodBootsArmorItemFactory>();
    }


    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
    }
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CloseBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "The Pair of Metal Shod Boots of the Black Reaver";
    public override int Ac => 6;
    public override bool Aggravate => true;
    public override bool Con => true;
    public override int Cost => 15000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "of the Black Reaver";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 10;
    public override int Rarity => 25;
    public override bool Speed => true;
    public override bool Str => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 80;
}
