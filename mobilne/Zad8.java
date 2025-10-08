import java.util.Arrays;
import java.util.List;
import java.util.Set;
import java.util.HashSet;
import java.util.ArrayList;

public class Zad8 {
    public static void main(String[] args) {
        List<Integer> lista1 = Arrays.asList(1, 2, 3, 4);
        List<Integer> lista2 = Arrays.asList(3, 4, 5, 6);

        List<Integer> wynik = zlacz(lista1, lista2);
        System.out.println("Połączona lista bez duplikatów: " + wynik);
    }

    public static List<Integer> zlacz(List<Integer> lista1, List<Integer> lista2) {
        Set<Integer> zbior = new HashSet<>(lista1);
        zbior.addAll(lista2);
        return new ArrayList<>(zbior);
    }
}
