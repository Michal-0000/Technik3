
import java.util.ArrayList;
import java.util.Collections;

public class Zad2 {
    //ZADANIE 2, 3, 5, 7 - 11 lekcja
    public static void main(String[] args) {
        ArrayList<String> imiona = new ArrayList<>();
        imiona.add("Jan");
        imiona.add("Ola");
        imiona.add("Adam");
        imiona.add("Zenon");

        System.out.println("Przed:");
        for (String imie : imiona) {
            System.out.println(imie);
        }

        Collections.reverse(imiona);

        System.out.println("Po:");
        for (String imie : imiona) {
            System.out.println(imie);
        }
    }
}
