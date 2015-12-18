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

