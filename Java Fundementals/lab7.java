// **********************************************
// COSC 236
// Dawit Alemu Fall 2022
// PROGRAM-NAME: Lab
//**********************************************
import java.util.Scanner;
public class lab7 {
public static void main(String[] args) {
Scanner input = new Scanner(System.in);
String[] name = new String[5];
double[] gpa = new double[5];
int[] id = new int[5];
lab7[] print = new lab7[5];
for (int x = 0; x < name.length; x++)
{
System.out.println("Enter your name: ");
name[x] = input.nextLine();
}
for (int x = 0; x < gpa.length; x++)
{
System.out.println("Enter your GPA: ");
gpa[x] = input.nextDouble();
}
for (int x = 0; x < id.length; x++)
{
System.out.println("Enter your student ID: ");
id[x] = input.nextInt();
}
for (int x = 0; x < print.length; x++)
{
System.out.println(name[x] + " is a currently a student at Towson University, their GPA is " + gpa[x] + ", and their student ID is " + id[x] + ".");
}
double highestgpa = 0.0;
for (int x = 0; x < gpa.length; x++)
{
if (gpa[x] > highestgpa)
{
highestgpa = gpa[x];
}
}
System.out.println("The highest gpa is: " + highestgpa);
double lowestgpa = 0.0;
for (int x = 0; x < gpa.length; x++)
{
if (gpa[x] < lowestgpa)
{
lowestgpa = gpa[x];
}
}
System.out.println("The lowest gpa is: " + lowestgpa);
double sum = 0;
double average = 0;
for (int x = 0; x < gpa.length; x++)
{
sum += gpa[x];
}
average = sum / 5;
System.out.println("The avg gpa is: " + average);
}
}