// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class RodItemFactory : ItemFactory, IFlavour
{
    public RodItemFactory(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns the rod flavours repository because rods have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour>? GetFlavorRepository() => SaveGame.SingletonRepository.RodFlavours;

    /// <inheritdoc/>
    public Flavour Flavor { get; set; }

    public abstract bool RequiresAiming { get; }
    public override bool EasyKnow => true;
    public override int PackSort => 13;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Rod;
    public override int BaseValue => 90;
    public override ColourEnum Colour => ColourEnum.Turquoise;
    public abstract void Execute(ZapRodEvent zapRodEvent);
}
