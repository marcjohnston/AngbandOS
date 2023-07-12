// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MainGaucheOfDefenceFixedArtifact : FixedArtifact
{
    private readonly ItemFactory _baseItemCategory;
    private MainGaucheOfDefenceFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<SwordMainGauche>();
    }

    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        if (Program.Rng.DieRoll(2) == 1)
        {
            IArtifactBias artifactBias = null;
            item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
        }
        else
        {
            item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
            item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();
        }
    }
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<VerticalBarSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "The Main Gauche of Defence";
    public override int Ac => 0;
    public override int Cost => 22500;
    public override int Dd => 2;
    public override bool Dex => true;
    public override int Ds => 5;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Defence";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 15;
    public override int Pval => 3;
    public override int Rarity => 30;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayGiant => true;
    public override bool SlayTroll => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 15;
    public override int ToH => 12;
    public override int Weight => 30;
}
