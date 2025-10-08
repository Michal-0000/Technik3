import java.util.Map;
import java.util.HashMap;

public class Zad9 {
    public static void main(String[] args) {
         Map<String, Integer> mapa = new HashMap<>();
        mapa.put("A", 1);
        mapa.put("B", 2);
        mapa.put("C", 3);

        System.out.println("Zawartość mapy: " + mapa);
        Map<Integer, String> odwroconaMapa = odwroc(mapa);
        System.out.println("Odwrócona mapa: " + odwroconaMapa);

    }

    public static Map<Integer, String> odwroc(Map<String, Integer> mapa) {
        Map<Integer, String> odwroconaMapa = new HashMap<>();
        for (Map.Entry<String, Integer> entry : mapa.entrySet()) {
            odwroconaMapa.put(entry.getValue(), entry.getKey());
        }
        return odwroconaMapa;
    }
}
