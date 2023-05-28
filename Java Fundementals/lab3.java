import java.util.Scanner;

public class lab3
{
    public static void main(String[] args)
    {
        Scanner input = new Scanner(System.in);
        
        System.out.print("Enter a letter grade: ");

        char letterGrade = input.next().charAt(0);

        if(letterGrade == 'A' || letterGrade == 'B' || letterGrade == 'C' || letterGrade == 'D'){
            letterGrade = Character.toLowerCase(letterGrade);
            System.out.println(letterGrade);
        }
    }
}