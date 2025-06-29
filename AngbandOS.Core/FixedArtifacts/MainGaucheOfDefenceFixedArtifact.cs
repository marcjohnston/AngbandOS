// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MainGaucheOfDefenceFixedArtifact : FixedArtifact
{
    private MainGaucheOfDefenceFixedArtifact(Game game) : base(game) { }
    public override string? ItemEnhancementBindingKey => nameof(MainGaucheOfDefenceFixedArtifactItemEnhancement);

    protected override string BaseItemFactoryName => nameof(MainGaucheWeaponItemFactory);


    public override void ApplyResistances(Item item)
    {
        if (Game.DieRoll(2) == 1)
        {
            item.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(FixedArtifactItemEnhancementWeightedRandom)));
        }
        else
        {
            item.RandomPower = Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(AbilityItemEnhancementWeightedRandom)).Choose();
        }
    }
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Main Gauche of Defence";
    public override int Ac => 0;
    public override int Cost => 22500;
    public override int Dd => 2;
    public override int Ds => 5;
    public override int Level => 15;
    public override int Rarity => 30;
    public override int ToA => 0;
    public override int ToD => 15;
    public override int ToH => 12;
    public override int Weight => 30;
}
