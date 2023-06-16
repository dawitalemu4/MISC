import java.util.Random;

public class final
{
    public static void main(String[] args) throws Exception {
        Random random = new Random();

        // Random length of 1 - 10.
        // The next int bound means top end of ten, + 1 makes it a min of 1
        Car[] cars = new Car[random.nextInt(10) + 1];

        for (int x = 0; x < cars.length; x++)
        {
            Car car = new Car();

            car.weight = random.nextInt(4000) + 1;
            
            // If the weight is even double it, if its odd triple it.
            if (car.weight % 2 == 0)
            {
                car.length = car.weight * 2;
            }
            else
            {
                car.length = car.weight * 3;
            }
            // Height is length / weight.
            car.height = car.length / car.weight;

            cars[x] = car;
        }

        HeaviestCar(cars);
        LightestCar(cars);
    }

    public static void HeaviestCar(Car[] cars)
    {
        int largestWeight = 0;
        int position = 0;

        for (int x = 0; x < cars.length; x++)
        {
            // positions
            // 0 1 2 3 4 5
            if (cars[x].weight > largestWeight)
            {
                largestWeight = cars[x].weight;
                position = x;
            }
        }

        System.out.println(largestWeight);
        System.out.println(position);
    }

    public static void LightestCar(Car[] cars)
    {
        int LightestCar = cars[0].weight;
        int position = 0;

        for (int x = 0; x < cars.length; x++)
        {
            // positions
            // 0 1 2 3 4 5
            if (cars[x].weight < LightestCar)
            {
                LightestCar = cars[x].weight;
                position = x;
            }
        }

        System.out.println(LightestCar);
        System.out.println(position);
    }
}


public class Car {
    int weight;
    int length;
    int height;
}


