import java.util.Scanner;

public class lab4
{
    public static void main(String[] args)
    {
        Scanner input = new Scanner(System.in);
        
        System.out.print("Enter radius: ");
double radius = input.nextDouble();
while (radius != 0) {
double pi = 3.14159265;
double diameter = radius * 2;
double circum = (radius * pi) * 2;
System.out.println("Enter diameter: " + diameter);
System.out.println("Enter circumfrence: " + circum);
System.out.println("Enter 0 to end or enter radius again: ");
radius = input.nextDouble();
}

System.out.println("Do you want to enter a radius?");
char userinput;
userinput = input.next().charAt(0);
if (userinput == 'y') {
System.out.print("Enter radius: ");
radius = input.nextDouble();
while (radius != 0) {
double pi = 3.14159265;
double diameter = radius * 2;
double circum = (radius * pi) * 2;
System.out.println("Enter diameter: " + diameter);
System.out.println("Enter circumfrence: " + circum);
System.out.println("Enter 0 to end or enter radius again: ");
radius = input.nextDouble();
}
}
else {
System.out.println("say y");
}

System.out.print("Enter temp: ");
double temp = input.nextDouble();
while (temp != 999 ) {
if (temp > 32){System.out.println("Temp is above freezing point ");
System.out.println("Enter 999 to end or enter temp again: ");}
if (temp < 32){
System.out.println("Temp is below freezing point ");
System.out.println("Enter 999 to end or enter temp again: ");}
temp = input.nextDouble();
}

System.out.print("Enter temp: ");
temp = input.nextDouble();
double diff = temp % 32;
while (temp != 999 ) {
if (temp > 32){
System.out.println("Temp is " + diff + " above freezing point ");
System.out.println("Enter 999 to end or enter temp again: ");}
if (temp < 32){
System.out.println("Temp is " + diff + " below freezing point ");
System.out.println("Enter 999 to end or enter temp again: ");}
temp = input.nextDouble();
}

double avg, sum, count = 0;
System.out.println("Enter temps for avg and press 999 to end: ");
temp = input.nextDouble();
sum = temp;
count++;
while (temp != 999 ) {
temp = input.nextDouble();
if (temp != 999){
count++;
sum = sum + temp;
}
}
avg = sum / count;
System.out.println("The avg temp is " + avg);
}
}

char userinput;
System.out.println("Do you want to enter a radius?");
userinput = input.next().charAt(0);
if (userinput == 'y') {
System.out.print("Enter temp: ");
double temp = input.nextDouble();
double diff = temp % 32;
while (temp != 999 ) {
if (temp > 32){
System.out.println("Temp is " + diff + " above freezing point ");
System.out.println("Enter 999 to end or enter temp again: ");}
if (temp < 32){
System.out.println("Temp is " + diff + " below freezing point ");
System.out.println("Enter 999 to end or enter temp again: ");}
temp = input.nextDouble();
}
}

int grade = 0, a = 0, b = 0 , c = 0, d = 0, f = 0, avg = 0;
System.out.println("Enter score1 ");
int grade1 = input.nextInt();
System.out.println("Enter score2 ");
int grade2 = input.nextInt();
System.out.println("Enter score3 ");
int grade3 = input.nextInt();
System.out.println("Enter score4 ");
int grade4 = input.nextInt();
System.out.println("Enter score5 ");
int grade5 = input.nextInt();
avg = (grade1 + grade2 + grade3 + grade4 + grade5) /
5;
while (grade != -1)
{
System.out.println("Enter -1 to end, Enter score ");
grade = input.nextInt();
if (grade >= 90 && grade <= 100){a++;}
else if (grade >= 80 && grade < 90){b++;}
else if (grade >= 70 && grade < 80){c++;}
else if (grade >= 60 && grade < 70){d++;}
else if (grade < 60 && grade != -1){f++;}
}
System.out.println("Number of A's " + a);
System.out.println("Number of B's " + b);
System.out.println("Number of C's " + c);
System.out.println("Number of D's " + d);
System.out.println("Number of F's " + f);
System.out.println("Average: " + avg);

int grade = 0;
while (grade < 10)
{
grade++;
System.out.println(grade);
}

int grade = 10;
while (grade > 1)
{
grade--;
System.out.println(grade);
}

int grade = 0;
while (grade < 20 )
{
grade++;
if (grade % 2 == 0) {System.out.println(grade);}
}

int grade = 0;
while (grade < 50 )
{
grade++;
System.out.println("I love java");
}

char ch ;
for (ch = 'A'; ch <= 'Z'; ch++) {
System.out.println(ch + " ");}

System.out.println("Enter a number: ");
int num = input.nextInt();
int x = 0;
x++;
for (x = 0 ; x < num; x++){
System.out.println("I love java");
}

int num = 0;
int track = 0;
System.out.println("Enter number: ");
num = input.nextInt();
track++;
while(num < 100){
track++;
System.out.println("Enter number: ");
num = num + input.nextInt();
}
System.out.println("You took " + track + " to reach 100.");
        
    }
}
