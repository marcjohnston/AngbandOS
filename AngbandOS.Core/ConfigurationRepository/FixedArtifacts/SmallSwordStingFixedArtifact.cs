// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SmallSwordStingFixedArtifact : FixedArtifact
{
    private ItemFactory _baseItemCategory;
    private SmallSwordStingFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<SwordShortSword>();
    }


    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
    }
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<VerticalBarSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "The Small Sword 'Sting'";
    public override int Ac => 0;
    public override bool Blows => true;
    public override bool Con => true;
    public override int Cost => 100000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 6;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Sting'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 2;
    public override int Rarity => 15;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayUndead => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 8;
    public override int ToH => 7;
    public override int Weight => 75;
}