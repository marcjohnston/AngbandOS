// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class WarHammerMjolnirFixedArtifact : FixedArtifact
{
    private WarHammerMjolnirFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(WarHammerHaftedWeaponItemFactory);
    public override string Name => "The War Hammer 'Mjolnir'";
    public override int Level => 40;
    public override int Rarity => 75;
}
