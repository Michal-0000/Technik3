import java.util.Scanner;
import java.util.HashSet;
import java.util.Set;

public class Zad5 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Podaj dlugosc tablicy 1: ");
        int n1 = scanner.nextInt();
        Set<Integer> tab1 = new HashSet<>();

        for(int i=0; i<n1; i++){
            System.out.println("Podaj wartosc do tab["+i+"]=");
            tab1.add(scanner.nextInt());
        }

        System.out.println("Podaj dlugosc tablicy 2: ");
        int n2 = scanner.nextInt();
        Set<Integer> tab2 = new HashSet<>();

        for(int i=0; i<n2; i++){
            System.out.println("Podaj wartosc do tab["+i+"]=");
            tab2.add(scanner.nextInt());
        }

        Set<Integer> przeciecie = new HashSet<>(tab1);
        przeciecie.retainAll(tab2);

        Set<Integer> suma = new HashSet<>(tab1);
        suma.addAll(tab2);

        System.out.println("Przeciecie to: "+przeciecie);
        System.out.println("Suma to: "+suma.stream().mapToInt(Integer::intValue).sum());

        scanner.close();
    }
}
