# JCalc, Calculator Emulator and REPL

JCalc attempts to emulate a Ti-83 style calculator, although has very large
distinctions between it. JCalc when ran by itself is an all purpose scientific
calculator, where calculations can be executed by entering them in. JCalc also
has a BASIC-style language builtin that can be entered on the REPL or in a file
and being executed with:
```
./JCalc.exe <code.jc>
```

## REPL and Expressions

To start the REPL, double click or execute the JCalc.exe assembly. You should
see a prompt on the screen that looks like this:
```
>>>
```

This is where you can enter your calculations. Take this "Hello World" example:
```
>>> 2 + 2
4

>>>
```

JCalc has support for all common binary operators. Here is a table showing them:

Operator		|  Description
----------------------  |  -----------
+			|  Adds the left and right side.
-			|  Subtracts the right side from the left.
*			|  Multiplies the left and right side.
/			|  Divides the left side by the right side.
%			|  Determines the modulus of the left side with the right side.
^			|  Raises the left side to the power of the right side.
->			|  Assigns the value of the left to the variable on the right.
=			|  Returns true if the left side equals the right.
!=			|  Returns true if the left side is not equal to the right.
>			|  Returns true if the left side is greater than the right.
<			|  Returns true if the left side is less than the right.
>=			|  Returns true if the left side is greater than or equal to the right.
<=			|  Returns true if the left side is lesser than or equal to the right.

Just like a pocket calculator, JCalc follows the PEMDAS operator precedence. Take this:
```
>>> 4 + 5 * 8
44

>>> (4 + 5) * 8
72

>>>
```

The ()s take precedence over other operations and the * operator takes precedence over the + operator.

## Built in Functions

Just like the Ti-83s we all know and love, JCalc has functions built in to it that make
it easy to do advanced mathematical computation. Here is an example showing the Square
Root function being used on the constant 64 and to calculate the Pythagorean Theorem:
```
>>> Sqrt(64)
8

>>> Sqrt(4^2 + 3^2)
5
```

Here is a documentation style table of the built in functions in JCalc:

Function			|  Description
------------------------------  |  -----------
Sqrt(x)				|  Returns the square root of x.
Abs(x)				|  Returns the absolute value of x.
Tan(x)				|  Returns the tangent of x.
ATan(x)				|  Returns the arctangent of x.
Cos(x)				|  Returns the cosine of x.
ACos(x)				|  Returns the arccosine of x.
Sin(x)				|  Returns the sine of x.
ASin(x)				|  Returns the arcsin of x.
Exp(x)				|  Returns e to the power of x.
Log(x)				|  Returns the logarithmic value of x.
Log10(x)			|  Returns the natural logarithmic value of x.
Rand()				|  Returns the next double from the random generator.
Rand(x)				|  Returns the next double from the random generator with an uppper bound of x.
Rand(x, y)			|  Returns a random number between x and y.

## Variables

You can assign values to any variable you would like to. Variables can be any series of
letters and numbers that does not start with a number. The syntax for assigning variables
is:
```
<value> -> <variable>
```

On the REPL let's assign some variables and then use them.
```
>>> Sqrt(64) -> x
8

>>> x + 5 -> x
13

>>> 3 -> y
3

>>> y * x
39

>>>
```
