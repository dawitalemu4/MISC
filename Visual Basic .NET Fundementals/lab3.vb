'Dawit Alemu'
'CIS 265 Spring 2023'
'Lab 3'

Imports System

Module Program

    Sub Main(args As String())

        ' Problem 1: Create a loop that counts down from 10 to 0 by 1 value.

        ' Set the initial value of the loop variable to 10.
        Dim num1 As Integer = 10

        ' Use a For loop to count down from 10 to 0 by 1 value.
        For i As Integer = num1 To 0 Step -1
            ' Display the value of the loop variable on the console.
            Console.Write(i & " ")
        Next
        Console.WriteLine(" ") 'Just to seperate each output'



        ' Problem 2: Create a loop that counts from 5 to 15 and displays the odd numbers only.

        ' Set the initial value of the loop variable to 5.
        Dim num2 As Integer = 5

        ' Use a While loop to count from 5 to 15.
        While num2 <= 15
            ' Check if the value of the loop variable is odd.
            If num2 Mod 2 <> 0 Then
                ' If the value is odd, display it on the console.
                Console.Write(num2 & " ")
            End If
            ' Increment the value of the loop variable by 1.
            num2 += 1
        End While
        Console.WriteLine(" ")




        ' Problem 3: Create a loop that counts backwards from 16 to 0 and decrements by 4s and displays the values.

        ' Set the initial value of the loop variable to 16.
        Dim num3 As Integer = 16

        ' Use a Do While loop to count backwards from 16 to 0 by 4s.
        Do While num3 >= 0
            ' Display the value of the loop variable on the console.
            Console.Write(num3 & " ")
            ' Decrement the value of the loop variable by 4.
            num3 -= 4
        Loop
        Console.WriteLine(" ")


        Console.WriteLine("Lab 3 complete")
    End Sub
End Module
