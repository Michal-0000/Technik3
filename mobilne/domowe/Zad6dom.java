import java.util.Arrays;
import java.util.Scanner;
import java.util.Random;

public class Zad6dom {
    public static void main(String[] args) {

        Random random = new Random();
        Scanner scanner = new Scanner(System.in);
        System.out.print("Podaj ilość liczb: ");
        int n = scanner.nextInt();

        int[] liczby  = new int[n];
        for (int i = 0; i < n; i++) {
            liczby[i] = random.nextInt(100);
        }

        System.out.println("Wylosowane liczby: " + Arrays.toString(liczby));
        System.out.println("Parzyste: " + parzyste(liczby));
        System.out.println("Nieparzyste: " + nieparzyste(liczby));
        System.out.println("Pierwsze: " + pierwsze(liczby));

        scanner.close();
    }

    public static int parzyste(int[] tab) {
        int count = 0;
        for (int liczba : tab) {
            if (liczba % 2 == 0) {
                count++;
            }
        }
        return count;
    }

    public static int nieparzyste(int[] tab) {
        int count = 0;
        for (int liczba : tab) {
            if (liczba % 2 != 0) {
                count++;
            }
        }
        return count;
    }

    public static int pierwsze(int[] tab) {
        int count = 0;
        for (int n : tab) {
            if(czyPierwsza(n)){
                count++;
            }
        }
        return count;
    }

    public static boolean czyPierwsza(int n) {
        if(n < 2) return false;
        if(n == 2) return true;
        if(n % 2 == 0) return false;
        for(int i = 3; i <= Math.sqrt(n); i += 2) {
            if(n % i == 0) {
                return false;
            }
        }
        return true;
    }
}
