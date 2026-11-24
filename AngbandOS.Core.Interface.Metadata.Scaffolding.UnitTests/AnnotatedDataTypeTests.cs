using AngbandOS.Core.Interface.Metadata;

namespace AngbandOS.Core.Interface.Metadata.Scaffolding.UnitTests;

[TestClass]
public sealed class AnnotatedDataTypeTests
{
    [DataTestMethod]
    [DataRow("string")]
    [DataRow("bool")]
    [DataRow("string?")]
    [DataRow("int")]
    [DataRow("char")]
    [DataRow("ColorEnum")]
    [DataRow("string[]?")]
    [DataRow("(string AttributeKey, bool DesiredValue)[]?")]
    [DataRow("(string AttributeKey, bool?[] DesiredValue)[]?")]
    [DataRow("(string AttributeKey, int? StartingValue, int? EndingValue)[]?")]
    [DataRow("int[][]")]
    [DataRow("bool?")]
    [DataRow("string[]")]
    [DataRow("(string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[]")]
    [DataRow("int?")]
    [DataRow("(int? MaxExperienceLevel, string LearnedKnowledgeBindingKey)[]")]
    [DataRow("int[]")]
    [DataRow("(string AttributeName, string Expression)[]?")]
    [DataRow("(string AttributeName, string BooleanExpression)[]?")]
    [DataRow("(string AttributeName, string[] ScriptNames)[]?")]
    [DataRow("(string UseScriptBindingKey, string InitialChargesRollExpression, int PerChargeValue, int ManaEquivalent)?")]
    [DataRow("(string QuaffScriptName, string? SmashScriptName, int ManaEquivalent)?")]
    [DataRow("(string ActivationScriptName, string InitialChargesCountRollExpression, int PerChargeValue, int ManaValue)?")]
    [DataRow("(int count, string rollExpression)[]?")]
    [DataRow("(int[]? Powers, bool? StoreStock, string[] ScriptNames)[]?")]
    [DataRow("(string ScriptName, string TurnsToRecharge, bool RequiresAiming, int ManaEquivalent)?")]
    [DataRow("(int level, int chance)[]?")]
    [DataRow("(string ScriptName, int ManaValue)?")]
    [DataRow("(string Name, int Weight)[]")]
    [DataRow("(int percentage, string? text, ColorEnum color)[]")]
    [DataRow("(string MethodName, string? EffectName, int Dice, int Sides)[]?")]
    [DataRow("(string[] MatchValues, bool IsEqual)?")]
    [DataRow("(string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[]")]
    [DataRow("NonDirectionalProjectileModeEnum")]
    [DataRow("LearnedDetailsWeightedRandomEnum")]
    [DataRow("(string PhysicalAttributesBindingKey, int Weight)[]")]
    [DataRow("(int startValue, string textToRender, ColorEnum color)[]")]
    [DataRow("(string ItemFactoryName, int Weight)[]?")]
    [DataRow("(string Name, (int Value, bool Flag) Nested)")]
    [DataRow("char?")]
    [DataRow("TownGameConfiguration[]?")]
    public void ParseAndToString_ReturnsOriginalDataType(string dataType)
    {
        AnnotatedDataType annotatedDataType = AnnotatedDataType.Parse(dataType);

        Assert.AreEqual(dataType, annotatedDataType.ToString());
    }

    [DataTestMethod]
    [DataRow("(string, string)")]
    [DataRow("(string, int)[]")]
    [DataRow("(string?, int)[]")]
    public void Parse_ThrowsForUnnamedTupleElements(string dataType)
    {
        Assert.ThrowsException<FormatException>(() => AnnotatedDataType.Parse(dataType));
    }

    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow(" ")]
    public void Parse_ThrowsArgumentExceptionForEmptyDataType(string? dataType)
    {
        Assert.ThrowsException<ArgumentException>(() => AnnotatedDataType.Parse(dataType!));
    }
}
