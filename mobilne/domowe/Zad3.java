import java.util.HashMap;
import java.util.Map;
public class Zad3 {
    public static void main(String[] args) {
        HashMap<String, Integer> wiek = new HashMap<String, Integer>();
        wiek.put("Anna", 20);
        wiek.put("Joanna", 50);
        wiek.put("Krzysztof", 78);

        for(Map.Entry<String, Integer> w : wiek.entrySet()) {
            System.out.println(w.getKey() + " ma " + w.getValue() + " lat");
        }   
    }
}
