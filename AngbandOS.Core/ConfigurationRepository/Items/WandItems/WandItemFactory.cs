// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class WandItemFactory : ItemFactory, IFlavour
{
    public WandItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(WandsItemClass));

    /// <summary>
    /// Returns the want flavours repository because wands have flavours that need to be identified.
    /// </summary>
    public IEnumerable<Flavour>? GetFlavorRepository() => SaveGame.SingletonRepository.WandFlavours;

    /// <inheritdoc/>
    public Flavour Flavor { get; set; }
    public override bool IsRechargable => true;

    public override int PackSort => 14;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Wand;
    public abstract bool ExecuteActivation(SaveGame saveGame, int dir);
    public override int BaseValue => 50;
    public override bool CanBeAimed => true;
    public override bool HatesElectricity => true;

    //public override bool IsCharged => true;
    public override ColorEnum Color => ColorEnum.Chartreuse;
}
