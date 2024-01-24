// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Animations;

[Serializable]
internal class PinkSparkleAnimation : Animation
{
    private PinkSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    protected override string ColorName => nameof(ColourEnum.Pink);
    public override string Name => "PinkSparkle";
    protected override string AlternateColorName => nameof(ColourEnum.Pink);
    public override string Sequence => @"·+·x·+·";
}
