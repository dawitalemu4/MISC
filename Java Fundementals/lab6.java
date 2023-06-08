// **********************************************
// COSC 236                                
// Dawit Alemu                             Fall 2022
// PROGRAM-NAME: Lab
//**********************************************

import java.util.Scanner;
public class lab6 {
    public static void main(String[] args) throws Exception {
        Scanner input = new Scanner(System.in);
   
//Part 1: (10) Write a program that creates an array of at most 10 (use a constant) int temperatures.
//Input 10 temperatures from the user. (40.3 35.8 29.6 45 17.8 19.2 38.6 31.5 27.8 39.9) these are example numbers do not hard code them, you must ask the user for the temperatures.
//Print the temperatures.
//Compute the average temperature.
//Count the number of days below freezing (32) and the number of days above.
//Find the highest temperature.
//Find the lowest temperature.
//Change each of the above to methods. Add a menu and a loop to call each method. Also add methods for each of the following:
//Write a search function that returns the corresponding index for any value you search for.

int[] nums = new int[10];

for (int x = 0; x < nums.length; x++)
    {
        System.out.println("Enter a temp: ");
        nums[x] = input.nextInt();
        System.out.println("You entered: " + nums[x]);
    }

    System.out.println("Enter a number for index: ");
    int ind = input.nextInt();

    System.out.println("Enter 1 for largest num, 2 for smallest num, 3 for average, 4 for freezing days, 5 for index, and 0 to end");
    int loop = input.nextInt();
    while (loop != 0)
    {
 
        if (loop == 1) {largestNum(nums); }
        if (loop == 2) {smallestNum(nums); }
        if (loop == 3) {average(nums); }
        if (loop == 4) {below(nums); }
        if (loop == 5) {index(nums, ind);}
        System.out.println("Enter 1 for largest num, 2 for smallest num, 3 for average, 4 for freezing days, 5 for index, and 0 to end");
        loop = input.nextInt();
    }  
}

    public static void largestNum(int[] nums)
    {
 
    int largestNum = 0;

    for (int x = 0; x < nums.length; x++)
    {
        if (nums[x] > largestNum)
        {
            largestNum = nums[x];
        }
    }

    System.out.println("The largest num is: " + largestNum);
   
    }
   


    public static void smallestNum(int[] nums)
    {
 
 
    int smallestNum = 0;

 

    for (int x = 0; x < nums.length; x++)
    {
        if (nums[x] < smallestNum)
        {
            smallestNum = nums[x];
        }
    }

    System.out.println("The smallest num is:" + smallestNum);

    }
   

    public static void average(int[] nums)
    {
        int sum = 0;
        int average = 0;
   
        for (int x = 0; x < nums.length; x++)
        {
            sum = sum + nums[x];
        }

    average = sum / nums.length;

    System.out.println("The avg is: " + average);
}


public static void below(int[] nums)
{
 
    int freeze = 0;

    for (int x = 0; x < nums.length; x++)
    {
        if (nums[x] < 32)
        {
           freeze = nums[x];
        }
    }
    System.out.println("The amount of days that were freezing was : " + freeze);

}
   

public static void index(int[] nums, int ind)
{
    for (int x = 0; x < nums.length; x++)
    {
        if (nums[x] == ind)
        {
            System.out.println("Number is in the list");
        }
    }
}

}