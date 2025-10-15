import java.util.ArrayList;
public class K1 {
    public static void main(String[] args) {
        int[] numer = {5,4,4,3,2};
        for (int i = 0; i < numer.length; i++) {
            System.out.println("Element "+ i +" "+ numer[i]);
        }

        //arraylist
        ArrayList<String> imiona = new ArrayList<>();
        imiona.add("Jan");
        imiona.add("Ola");
        imiona.add("Adam");

        for(String imie : imiona) {
            System.out.println(imie);
        }
        imiona.remove(1);
        for(String imie : imiona) {
            System.out.println(imie);
        }
        imiona.remove("Adam");
        for(String imie : imiona) {
            System.out.println(imie);
        }
        imiona.add("Zenon");
        imiona.set(1, "Genofewa");
        for(String imie : imiona) {
            System.out.println(imie);
        }
        int idx = imiona.indexOf("Jan");
        System.out.println(Integer.toString(idx));
    }
}