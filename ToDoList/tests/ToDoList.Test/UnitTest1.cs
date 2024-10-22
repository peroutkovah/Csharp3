
namespace ToDoList.Test;
using System;
public class UnitTest1
{
    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(2, 2, 1)]

    public void DivideInt_byProperNumber_Succeeded(int Dividend, int Divisor, int ExpectedResult)
    {
        // Arange
        var calculator = new Calculator();

        // Act
        var result = calculator.DivideInteger(Dividend, Divisor);

        // Assert
        Assert.Equal(ExpectedResult, result);

    }
    [Fact]
    //pokud mam float, tak mi to exceptionu nehodi
    public void DivideFloat_byZero_ThrowZeroExc_Failed()
    {
        // Arange
        var calculator = new Calculator();

        // Act
        var divideAction = () => calculator.DivideFloat(10, 0);

        // Assert
        Assert.Throws<DivideByZeroException>(() => calculator.DivideFloat(10, 0));

    }
    [Fact]
    //pokud mam float, ocekavam, ze mi vyjde 0. ale ono vyjde nekonecno
    public void DivideFloat_byZero_Failed()
    {
        // Arange
        var calculator = new Calculator();

        // Act
        var divideAction = () => calculator.DivideFloat(10, 0);

        // Assert
        Assert.Equal(0, calculator.DivideFloat(10, 0));

    }
    [Fact]
    //pokud mam float, ocekavam, ze mi vyjdenekonecno
    public void DivideFloat_byZero_Infinity_Succeeded()
    {
        // Arange
        var calculator = new Calculator();

        // Act
        var divideAction = () => calculator.DivideFloat(10, 0);

        // Assert
        Assert.Equal(float.PositiveInfinity, calculator.DivideFloat(10, 0));

    }
    [Fact]
    //pokud mam integer, tak test uspeje - integer musim zmenit v divide
    public void DivideInt_byZero_ThrowZeroExc_Succeedded()

    {
        // Arange
        var calculator = new Calculator();

        // Act
        var divideAction = () => calculator.DivideInteger(10, 0);

        // Assert
        Assert.Throws<DivideByZeroException>(() => calculator.DivideInteger(10, 0));

    }

}

public class Calculator
{
    public float DivideFloat(float dividend, float divisor)
    {
        return dividend / divisor;
    }

    public int DivideInteger(int dividend, int divisor)
    {
        return dividend / divisor;
    }
}