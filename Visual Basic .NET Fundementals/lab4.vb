'Dawit Alemu'
'CIS 265 Spring 2023'
'Lab 4'

Imports System
Imports System.Drawing

Module Program
    Const SIZE As Integer = 5 'define the size of the array using a constant

    Sub Main(args As String())

        Dim arr(Size - 1, Size - 1) As Char
        For i As Integer = 0 To Size - 1
            For j As Integer = 0 To Size - 1
                arr(i, j) = "O"
            Next
        Next

        'Display the contents of the 2D array
        Console.WriteLine("Before drawing X:")
        For i As Integer = 0 To Size - 1
            For j As Integer = 0 To Size - 1
                Console.Write(arr(i, j) & " ")
            Next
            Console.WriteLine()
        Next

        'Draw X inside the array
        For i As Integer = 0 To Size - 1
            arr(i, i) = "X"
            arr(i, Size - 1 - i) = "X"
        Next

        'Display the contents of the updated 2D array
        Console.WriteLine("After drawing X:")
        For i As Integer = 0 To Size - 1
            For j As Integer = 0 To Size - 1
                Console.Write(arr(i, j) & " ")
            Next
            Console.WriteLine()
        Next




        Console.WriteLine("Lab 4 complete")
    End Sub
End Module
