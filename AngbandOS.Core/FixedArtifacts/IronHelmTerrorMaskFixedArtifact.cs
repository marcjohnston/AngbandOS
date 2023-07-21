// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class IronHelmTerrorMaskFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private readonly ItemFactory _baseItemCategory;
    private IronHelmTerrorMaskFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<HelmIronHelm>();
    }

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        if (saveGame.Player.BaseCharacterClass.ID == CharacterClass.Warrior)
        {
            item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
            item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();

            IArtifactBias artifactBias = null;
            item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
        }
        else
        {
            item.RandartItemCharacteristics.Cursed = true;
            item.RandartItemCharacteristics.HeavyCurse = true;
            item.RandartItemCharacteristics.Aggravate = true;
            item.RandartItemCharacteristics.DreadCurse = true;
            item.IdentCursed = true;
            return;
        }
    }

    // Dragon Helm and Terror Mask cause fear
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.TurnMonsters(40 + saveGame.Player.ExperienceLevel);
        item.RechargeTimeLeft = 3 * (saveGame.Player.ExperienceLevel + 10);
    }
    public string DescribeActivationEffect() => "rays of fear in every direction";
    public override ItemFactory BaseItemCategory => _baseItemCategory;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CloseBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "The Iron Helm 'Terror Mask'";
    public override int Ac => 5;
    public override bool Activate => true;
    public override int Cost => 0;
    public override int Dd => 1;
    public override int Ds => 3;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Terror Mask'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImCold => true;
    public override bool Int => true;
    public override int Level => 20;
    public override bool NoMagic => true;
    public override int Pval => -1;
    public override int Rarity => 5;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDisen => true;
    public override bool ResFear => true;
    public override bool ResPois => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool Teleport => true;
    public override int ToA => 10;
    public override int ToD => 25;
    public override int ToH => 25;
    public override int Weight => 75;
    public override bool Wis => true;
}
