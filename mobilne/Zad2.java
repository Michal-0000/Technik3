import java.util.Scanner;
public class Zad2{

    public static void main(String[] args){
        Scanner scanner = new Scanner(System.in);

        System.out.println("Podaj wartosc x (T/F):");
        boolean x = scanner.nextBoolean();
        System.out.println("Podaj wartosc y (T/F):");
        boolean y = scanner.nextBoolean();
        System.out.println("Podaj wartosc z (T/F):");
        boolean z = scanner.nextBoolean();

        boolean w = ((x || y) && !z) || (x && y);

        System.err.println("Wynik to: "+ w);
        scanner.close();
    }

    
}