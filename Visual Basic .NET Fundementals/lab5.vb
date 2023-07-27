'Dawit Alemu'
'CIS 265 Spring 2023'
'Lab 5'



Module Program


    Sub Main()
        ' Ask the user how many strings they will be entering
        Console.WriteLine("How many strings will you be entering?")
        Dim numStrings As Integer

        ' The user should provide a reasonable number. If they do not, continue to ask them until one is provided.
        While True
            If Integer.TryParse(Console.ReadLine(), numStrings) AndAlso numStrings > 0 Then
                Exit While
            Else
                Console.WriteLine("Please enter a valid number.")
            End If
        End While

        Dim queue As New Queue(Of String)

        ' Prompt the user to provide the strings
        For i As Integer = 1 To numStrings
            Dim str As String = ""
            ' The string must be more than 9 characters long, but less than 31 characters
            While str.Length < 10 OrElse str.Length > 30
                Console.WriteLine($"Please enter string #{i}:")
                str = Console.ReadLine()

                ' If the user provides an invalid string, continue to ask for correct input until a valid string is provided
                If str.Length < 10 OrElse str.Length > 30 Then
                    Console.WriteLine("Please enter a string between 10 and 30 characters long.")
                End If
            End While

            queue.Enqueue(str)
        Next

        Dim substring As String = ""
        ' Ask the user for a substring to search for
        While substring.Length < 3 OrElse substring.Length > 10
            Console.WriteLine("Please enter a substring to search for:")
            substring = Console.ReadLine()

            ' The substring must be more than 2 characters long but less than 11
            If substring.Length < 3 OrElse substring.Length > 10 Then
                Console.WriteLine("Please enter a substring between 3 and 10 characters long.")
            End If
        End While

        Dim substringCount As Integer = 0

        ' Use a for-each loop to count how many times the substring is found in queue
        For Each str As String In queue
            Dim index As Integer = str.IndexOf(substring, StringComparison.OrdinalIgnoreCase)
            If index >= 0 Then
                ' If the substring is found in the string, count how many times it appears
                Dim count As Integer = 0
                While index >= 0
                    count += 1
                    index = str.IndexOf(substring, index + 1, StringComparison.OrdinalIgnoreCase)
                End While

                ' Display the number of times the substring was found in the string
                Console.WriteLine($"The substring '{substring}' was found {count} time(s) in the string '{str}'.")
                substringCount += count
            Else
                ' If the substring was not found, display an appropriate message
                Console.WriteLine($"The substring '{substring}' was not found in the string '{str}'.")
            End If
        Next

        ' Display the total number of times the substring was found in the queue
        Console.WriteLine($"The substring '{substring}' was found {substringCount} time(s) in the queue.")



        Console.WriteLine("Lab 5 complete")
    End Sub
End Module
