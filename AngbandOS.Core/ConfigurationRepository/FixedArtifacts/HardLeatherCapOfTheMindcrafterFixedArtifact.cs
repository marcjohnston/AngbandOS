// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class HardLeatherCapOfTheMindcrafterFixedArtifact : FixedArtifact
{
    private ItemFactory _baseItemCategory;
    private HardLeatherCapOfTheMindcrafterFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<HelmHardLeatherCap>();
    }


    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
    }
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CloseBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "The Hard Leather Cap of the Mindcrafter";
    public override int Ac => 2;
    public override int Cost => 50000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override string FriendlyName => "of the Mindcrafter";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 20;
    public override int Pval => 2;
    public override int Rarity => 2;
    public override bool ResBlind => true;
    public override bool Telepathy => true;
    public override int ToA => 10;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 15;
    public override bool Wis => true;
}