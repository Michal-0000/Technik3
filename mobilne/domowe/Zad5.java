import java.util.Set;
import java.util.ArrayList;
import java.util.HashSet;
public class Zad5 {
    public static void main(String[] args) {
        ArrayList<Integer> lista = new ArrayList<>();
        lista.add(4);
        lista.add(5);
        lista.add(9);
        lista.add(5);
        lista.add(8);
        lista.add(4);

        System.out.println("Przed: "+lista);

        Set<Integer> unikalne = new HashSet<>(lista);
        lista = new ArrayList<>(unikalne);

        System.out.println("Po usunięciu duplikatów: "+lista);

    }
}
