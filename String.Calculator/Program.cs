// See https://aka.ms/new-console-template for more information

using String.Calculator;

Console.WriteLine("Hello, enter input string to sum:");
var calculator = new CalculatorService();

var inputString = Console.ReadLine();
var inputSum = calculator.Add(inputString);

Console.WriteLine("Input sum total: " +  inputSum);

