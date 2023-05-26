import java.util.Scanner;

public class lab0
{
    public static void main(String[] args)
    {
        Scanner input = new Scanner(System.in);
        
        double weight, height, bmi;

        System.out.print("Enter your weight in pounds: ");
        weight = input.nextDouble();

        System.out.print("Enter your height in inches: ");
        height = input.nextDouble();

        bmi = (weight * 703) / (height * height);

        System.out.printf("Your BMI is %.2f\n", bmi);

        System.out.println("BMI VALUES");
        System.out.println("Underweight: less than 18.5");
        System.out.println("Normal: between 18.5 and 24.9");
        System.out.println("Overweight: between 25 and 29.9");
        System.out.println("Obese: 30 or greater");
            
    }
}