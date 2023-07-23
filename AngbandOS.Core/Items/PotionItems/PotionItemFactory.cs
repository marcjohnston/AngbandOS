// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class PotionItemFactory : ItemFactory, IFlavour
{
    public PotionItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Potions";

    /// <summary>
    /// Returns the potions flavours repository because potions have flavours that need to be identified.  The Apple Juice, Water and Slime-Mold
    /// potions override this
    /// </summary>
    public virtual IEnumerable<Flavour>? GetFlavorRepository() => SaveGame.SingletonRepository.PotionFlavours;

    /// <inheritdoc/>
    public Flavour Flavor { get; set; }

    public override bool EasyKnow => true;
    public override int PackSort => 11;
    /// <summary>
    /// Have a potion affect the player.  Activates the potion effect.
    /// </summary>
    /// <returns> True, if drinking the potion identified it; false, to keep the potion as unidentified.</returns>
    public abstract bool Quaff();

    /// <summary>
    /// Perform a smash effect for the potion.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <param name="who"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <returns>Returns whether or not the action causes pets to become angry and turn against their owner.  Returns false, by default.</returns>
    public virtual bool Smash(int who, int y, int x)
    {
        return false;
    }

    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Potion;
    public override int BaseValue => 20;
    public override bool HatesCold => true;
    public override ColourEnum Colour => ColourEnum.Blue;

}
