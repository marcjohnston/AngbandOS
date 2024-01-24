// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightWhiteExpandAnimation : Animation
{
    private BrightWhiteExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    protected override string ColorName => nameof(ColourEnum.BrightWhite);
    public override string Name => "BrightWhiteExpand";
    protected override string AlternateColorName => nameof(ColourEnum.BrightWhite);
    public override string Sequence => @"·oO";
}
