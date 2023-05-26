import java.util.Scanner;

public class lab1
{
    public static void main(String[] args)
    {
        Scanner input = new Scanner(System.in);
        
        double price, tax, total;

        System.out.print("Enter the price of the item: ");
        price = input.nextDouble();

        tax = price * 0.06;
        total = price + tax;

        System.out.printf("Your total is $" + total);
    }
}