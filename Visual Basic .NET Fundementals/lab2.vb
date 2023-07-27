'Dawit Alemu'
'CIS 265 Spring 2023'
'Lab 2'

Imports System

Module Program
    'Calculate Circle Area of Rectangle'
    'Writes circle area of rectangle to console and other dimensions'
    Sub Main(args As String())
        Dim length, width, perimeter, area As Double

        length = 7.5
        width = 12.25

        perimeter = 2 * (length + width)

        area = length * width

        Console.WriteLine("Rectangle Dimensions:")
        Console.WriteLine("Length:  " & length)
        Console.WriteLine("Width:   " & width)
        Console.WriteLine("Perimeter: " & perimeter)
        Console.WriteLine("Area:      " & area)

        Const pi = 3.1415926535897931

        Console.WriteLine("Value of Pi: " & pi)

        Const pi1 As Double = 3.1415926535897931
        Const pi2 As Decimal = 3.1415926535897932384626433D


        Dim radius As Double = 6.56
        Dim circleArea1 As Double = pi1 * radius * radius
        Dim circleArea2 As Decimal = pi2 * CDec(radius) * CDec(radius)

        Console.WriteLine("Circle Area (using pi1): " & circleArea1)
        Console.WriteLine("Circle Area (using pi2): " & circleArea2)


        Console.WriteLine("Lab 2 complete")
    End Sub
End Module
