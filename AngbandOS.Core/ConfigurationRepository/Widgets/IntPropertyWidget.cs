// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class IntPropertyWidget : Widget
{
    protected IntPropertyWidget(SaveGame saveGame) : base(saveGame) { }
    public abstract string IntPropertyName { get; }
    public IntFlaggedProperty IntProperty { get; private set; }
    public abstract string IntPropertyFormatterName { get; }
    public IntPropertyFormatter IntPropertyFormatter { get; private set; }
    public abstract ColorEnum Color { get; }
    public override void Bind()
    {
        IntProperty = (IntFlaggedProperty)SaveGame.SingletonRepository.Properties.Get(IntPropertyName);
        IntPropertyFormatter = (IntPropertyFormatter)SaveGame.SingletonRepository.PropertyFormatters.Get(IntPropertyFormatterName);
    }

    /// <summary>
    /// Returns true, if the base IntProperty was updated.
    /// </summary>
    protected override bool QueryRedraw => IntProperty.IsSet;

    protected override void Paint()
    {
        string value = IntPropertyFormatter.Format(IntProperty.Value, Width);
        SaveGame.Screen.Print(Color, value, Y, X);
    }
}
