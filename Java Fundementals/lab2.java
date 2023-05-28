import java.util.Scanner;

public class lab2
{
    public static void main(String[] args)
    {
        Scanner input = new Scanner(System.in);
        
        System.out.print("Enter time in seconds: ");
        int inputTime = input.nextInt();
        int hours = inputTime / 3600;
        int minutes = (inputTime % 3600) / 60;
        int seconds = inputTime % 60;

        System.out.printf("Hours: " + hours + "\nMinutes: " + minutes + "\nSeconds: " + seconds);
    }
}