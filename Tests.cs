using NUnit.Framework;
using NUnit;
using System;
using NUnit.Framework.Legacy;
using static Employee;

[TestFixture]
public class EmployeeTests

{
    public Employee employee { get; set; }
    [OneTimeSetUp]
    public void SetUp ()
    {
         employee = new Employee("milovan", 30, 5);
    }
	[Test]
    public void InitialTest()
	{
        ClassicAssert.AreEqual(200000, employee.BankovniRacun);
	}
    [Test]
    public void TestSpend()
    {        

        employee.Spend(200001);
        ClassicAssert.AreEqual(200000,employee.BankovniRacun);

    }

    [Test]
    public void TestSpend2() {
        
        var spendamount = 23453;
        employee.Spend(spendamount);
        var expected = 200000 - 23453;
        ClassicAssert.AreEqual(expected, employee.BankovniRacun);
    }

    [Test]    
    public void TestDbCount()
    {
        //arrange
        EmployeeDbFake.employeeList = [];

        //act
        var employe0 = new Employee("milovan", 30, 5);    
        var employe1 = new Employee("ivana", 30, 5);
        var employe2 = new Employee("marko", 30, 5);

        //assert
        ClassicAssert.AreEqual(3, EmployeeDbFake.employeeList.Count);
       
    }



}
