import java.util.Random;

public class Zad1 {
    public static void main(String[] args) {

        int[] liczby = new int[5];
        Random random = new Random();
        for (int i = 0; i < 5; i++) {
            liczby[i] = random.nextInt(20);
        }

        for (int i = 0; i < liczby.length; i++) {
            System.out.println("Element " + (i+1) + " " + liczby[i]);
        }

    }
}


//ZADANIE 2, 3, 5, 7