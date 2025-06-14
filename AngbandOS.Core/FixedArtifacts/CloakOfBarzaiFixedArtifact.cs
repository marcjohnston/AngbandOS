// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CloakOfBarzaiFixedArtifact : FixedArtifact
{
    private CloakOfBarzaiFixedArtifact(Game game) : base(game) { }

    protected override string BaseItemFactoryName => nameof(ClothCloakItemFactory);

    // Cloak of Barzai gives resistances
    protected override string? ActivationName => nameof(ResistAll20p1d20Activation);

    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "The Cloak of Barzai";
    public override int Ac => 1;
    public override int Cost => 10000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override string FriendlyName => "of Barzai";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 5;
    public override int Rarity => 45;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResPois => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 10;
}
