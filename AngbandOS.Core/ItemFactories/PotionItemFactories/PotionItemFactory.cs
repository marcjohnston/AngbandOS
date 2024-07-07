// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class PotionItemFactory : ItemFactory
{
    public PotionItemFactory(Game game) : base(game) { }

    /// <summary>
    /// Returns true, because potions are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true; // TODO: This should be a built-in function depending on what the potion does

    protected override string ItemClassName => nameof(PotionsItemClass);

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (60, "3d5-3"),
        (240, "1d5-1")
    };

    public override int PercentageBreakageChance => 100;
    public override bool EasyKnow => true;
    public override int PackSort => 11;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="game"></param>
    /// <param name="who"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    public bool Smash(int who, int y, int x)
    {
        if (PotionDetails == null)
        {
            throw new Exception("Smash is not supported for a non-potion.");
        }
        IUnfriendlyScript? smashUnfriendlyScript = PotionDetails.Value.SmashScript;
        if (smashUnfriendlyScript == null)
        {
            return false;
        }
        return smashUnfriendlyScript.ExecuteUnfriendlyScript(who, y, x);
    }

    public override int BaseValue => 20;
    public override bool HatesCold => true;
    public override ColorEnum Color => ColorEnum.Blue;

}
