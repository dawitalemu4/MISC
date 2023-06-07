import java.util.Scanner;

public class lab5
{
    public static void main(String[] args)
    {
        Scanner input = new Scanner(System.in);
        
        for(int x = 0; x < 100; x++) {
            if(x % 2 > 0){
            System.out.println(x);
            }
        }

        int x = 100;

        while(x >= 0) {
                if(x % 2 == 0){
                    System.out.println(x);
                }
            x--;
        }

        System.out.println("Enter the limit: ");

        int limit = input.nextInt();

        for( x = 0; x < limit; x++) {
            System.out.println("Coding is fun");
        }

        for( x = 0; x <= 100; x++) {
            if(x % 5 == 0){
                System.out.println(x);
            }
        }

        for( x = 100; x >= 0; x--) {
            if(x % 3 == 0){
                System.out.println(x);
            }
        }

        int sum = 0;

        for( x = 0; x <= 20; x++) {
            System.out.println(x);
            sum += x;
        }

        System.out.println("The sum is " + sum);

    }
}