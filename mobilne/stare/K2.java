import java.util.Map;
import java.util.HashMap;
public class K2 {
    public static void main(String[] args) {
        
        HashMap<String, Integer> wiek = new HashMap<String, Integer>();
        wiek.put("Anna", 20);
        wiek.put("Joanna", 50);
        wiek.put("Krzysztof", 78);

        for(String w : wiek.keySet()) {
            System.out.println(w + " ma lat: " + wiek.get(w));
        }

        wiek.remove("Krzysztof");
        for(String w : wiek.keySet()) {
            System.out.println(w + " ma lat: " + wiek.get(w));
        }

        System.out.println("Czy jest tam Krzysztof? " + wiek.containsKey("Krzysztof"));

        for (Map.Entry<String, Integer> entry : wiek.entrySet()) {
            System.err.println(entry.getKey() + " ma lat: " + entry.getValue());
        }
        System.err.println("----");
        wiek.clear();
        for (Map.Entry<String, Integer> entry : wiek.entrySet()) {
            System.err.println(entry.getKey() + " ma lat: " + entry.getValue());
        }
    }
}
