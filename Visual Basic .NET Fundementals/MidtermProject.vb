'Dawit Alemu'
'CIS 265 Spring 2023'
'Midterm Project'



Module Program


    Sub Main()

        Dim numStrings As Integer
        Console.Write("How many strings would you like to provide (1-10)? ")
        While Not Integer.TryParse(Console.ReadLine(), numStrings) OrElse numStrings < 1 OrElse numStrings > 10
            Console.WriteLine("Invalid input. Please enter a number between 1 and 10.")
            Console.Write("How many strings would you like to provide (1-10)? ")
        End While

        Dim inputStrings(numStrings - 1) As String
        For i As Integer = 0 To numStrings - 1
            Console.Write("Enter string #" & (i + 1) & " (10-50 characters): ")
            Dim inputString As String = Console.ReadLine()

            While inputString.Length < 10 OrElse inputString.Length > 50
                If inputString.Length < 10 Then
                    Console.WriteLine("The input string is too short. You are missing " & (10 - inputString.Length) & " characters.")
                Else
                    Console.WriteLine("The input string is too long. You have gone over by " & (inputString.Length - 50) & " characters.")
                End If
                Console.Write("Please enter a string between 10 and 50 characters: ")
                inputString = Console.ReadLine()
            End While

            inputStrings(i) = inputString
        Next

        Console.Write("Enter text to search for (2-6 characters): ")
        Dim searchText As String = Console.ReadLine()

        While searchText Is Nothing OrElse Not (searchText.Length >= 2 AndAlso searchText.Length <= 6)
            Console.WriteLine("Invalid input. Please enter text between 2 and 6 characters.")
            Console.Write("Enter text to search for (2-6 characters): ")
            searchText = Console.ReadLine()
        End While

        For i As Integer = 0 To numStrings - 1
            Dim count As Integer = 0
            For j As Integer = 0 To inputStrings(i).Length - 1
                If inputStrings(i).Substring(j).ToLower().StartsWith(searchText.ToLower()) Then
                    count += 1
                End If
            Next
            Console.WriteLine("The text """ & searchText & """ was found " & count & " time(s) in string #" & (i + 1) & ".")
        Next

        Console.ReadLine()

        Console.WriteLine("Midterm Project complete")
    End Sub
End Module
