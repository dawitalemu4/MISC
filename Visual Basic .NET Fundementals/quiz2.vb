Module Quiz2

    Sub Main()
        Dim numbers(9) As Integer
        Dim oddQueue As New Queue(Of Integer)
        Dim evenStack As New Stack(Of Integer)

        Console.WriteLine("Enter 10 positive numbers less than 100:")
        For i As Integer = 0 To 9
            Do
                Console.Write("Number " & (i + 1) & ": ")
                numbers(i) = Integer.Parse(Console.ReadLine())
                If numbers(i) <= 0 Or numbers(i) >= 100 Then
                    Console.WriteLine("Invalid number. Please try again.")
                ElseIf numbers(i) Mod 2 = 0 Then
                    evenStack.Push(numbers(i))
                Else
                    oddQueue.Enqueue(numbers(i))
                End If
            Loop Until numbers(i) > 0 And numbers(i) < 100
        Next

        Console.WriteLine()
        Console.WriteLine("Odd numbers in the queue:")
        For Each n As Integer In oddQueue
            Console.WriteLine(n)
        Next

        Console.WriteLine()
        Console.WriteLine("Even numbers in the stack:")
        For Each n As Integer In evenStack
            Console.WriteLine(n)
        Next

        Console.ReadLine()
    End Sub

End Module
