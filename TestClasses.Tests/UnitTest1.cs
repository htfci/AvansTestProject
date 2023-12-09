namespace TestClasses.Tests;

public class Tests
{
    private ClassAssignmentAvans? _classAssignmentAvans;

    [SetUp]
    public void Setup()
    {
        _classAssignmentAvans = new ClassAssignmentAvans();
    }


    // Test Failed. it means when you get input in lowercase, method will not work properly. This can be fixed!
    [Test]
    public void CheckWheaterMethodWorks_WhenUsing_LowerCaseLetterForTypeOfShippingCost_Ground()
    {
        double expectedCost = 100;

        double value = _classAssignmentAvans.ShippingCosts(true, "ground", 350);

        Assert.That(value, Is.EqualTo(expectedCost));
    }


    // Test Passed. When calculation is not set, method returns 0 value.
    [Test]
    public void MethodReturnsZero_WhenCalculation_IsSetToFalse()
    {
        double value = _classAssignmentAvans.ShippingCosts(false, "NextDayAir", 250);

        Assert.Zero(value);
    }


    // Test Passed. it means conditional statement works well when passing larger number as totalprice.
    [Test]
    public void CheckWheater_TypeOfShippingCostInStore_IsNotFifty_WhenTotalPrice_IsAbove1500() {

        double InStoreCost = 50;

        double value = _classAssignmentAvans.ShippingCosts(true, "InStore", 1525);

        Assert.That(value, Is.Not.EqualTo(InStoreCost));
    }


    // Test Passed. No issue occured when passing negative number to totalprice. (must be fixed)
    [Test]
    public void ResultIsSame_WhenTotalPriceIsNegative() {

        double value = _classAssignmentAvans.ShippingCosts(true, "SecondDayAir", -5);

        Assert.That(value, Is.EqualTo(125));
    }


    // Test Passed. Passing empty string to typeOfShippingCosts will return default value 0 within the switch statement. (Must be handled correctly)
    [Test]
    public void ResultIsZero_WhenUserInputIsEmptyString()
    {
        double value = _classAssignmentAvans.ShippingCosts(true, String.Empty, 250);

        Assert.Zero(value);
    }


    // Test Passed.
    [Test]
    public void CheckDifferent_typesOfShippingCosts_For_VariousShippingMethods_ReturnsAValueMatchesAnyOfTheExpectedValues()
    {

        string[] anyTypeOfShippingCosts = { "Ground", "InStore", "NextDayAir", "SecondDayAir" };

        for(int i = 0; i < anyTypeOfShippingCosts.Length; i++) {
            string nameOfType = anyTypeOfShippingCosts[i];

            double value = _classAssignmentAvans.ShippingCosts(true, nameOfType, 250);

            Assert.That(value, Is.AnyOf(100, 50, 250, 125));
        }
    }
}
