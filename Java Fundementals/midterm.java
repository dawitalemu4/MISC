import java.util.Scanner;

import javax.lang.model.util.ElementScanner6;

public class midterm {
    public static void main(String[] args) throws Exception {
        Scanner input = new Scanner(System.in);
        int userInput;
        double tempInput;
        double temp;

        // Question 4
        int counter = 1;
        System.out.println("Please enter a number");
        userInput = input.nextInt();

        while (userInput < 100)
        {
            counter++;
            System.out.println("Please enter a number");
            userInput = userInput + input.nextInt();
        }

        System.out.println(userInput + " " + counter);

        // Question 5
        userInput = input.nextInt();
        for (int x = 0; x < userInput; x++)
        {
            System.out.println("programming is fun");
        }

        // Question 6
        tempInput = input.nextDouble();
        temp = (userInput - 32) / 1.8;

        // Question 7
        userInput = input.nextInt();

        while(userInput != 4)
        {
            userInput = input.nextInt();
        }

        // Question 8
        int x = 10;
        int y = 15;

        x = x + y / 4;
        x = x / y;
        x = x * y + 10;

        // Question 9
        int xx = 10;
        double yy = 15;
        int z;

        z = x + y;

        // Question 10 -- true FREEBIE
        int num = 0;
        num = num + 1;
        num = num++;

        // Question 11
        double height;
        double weight;
        double bmi;

        weight = input.nextDouble();
        height = input.nextDouble();

        bmi = BMI(height, weight);

        // Question 12
        for (int x1 = 0; x1 <= 100; x1++)
        {
            if (x1 % 2 == 0)
            {
                System.out.println(x1);
            }
        }

        // Question 13
        for (int x1 = 0; x1 <= 100; x1++)
        {
            if (x1 % 2 != 0)
            {
                System.out.println(x1);
            }
        }
    }

    // Question 1
    public static boolean isEven(int num1)
    {
        return num1 % 2 == 0;
    }

    // Question 2
    public static String findGrade(double num1)
    {
        String grade = "";

        if (num1 <= 100 && num1 >= 90)
        {
            grade = "A";
        }
        else if (num1 <= 89 && num1 >= 80)
        {
            grade = "B";
        }
        return grade;
    }

    // Question 3
    public static void biggerNumber(int num1, int num2)
    {
        if (num1 > num2)
        {
            System.out.println("Number 1 is bigger");
        }
        else if (num2 > num1)
        {
            System.out.println("Number 2 is bigger");
        }
        else 
        {
            System.out.println("Both numbers are equal");
        }
    }

    // Question 11
    public static double BMI(double height, double weight)
    {
        return (weight * 703) / (height * height);
    }
}



