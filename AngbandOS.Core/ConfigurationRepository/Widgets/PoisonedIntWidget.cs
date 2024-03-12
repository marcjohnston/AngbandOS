// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal class PoisonedIntWidget : IntWidget
{
    private PoisonedIntWidget(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override int X => 33;
    public override int Y => 44;
    public override int Width => 8;
    public override int Height => 1;
    public override ColorEnum Color => ColorEnum.Orange;
    public override string IntChangeTrackableName => nameof(PoisonedTimer);
    public override string IntPropertyFormatterName => nameof(PoisonedRangedIntFormatter);
}
