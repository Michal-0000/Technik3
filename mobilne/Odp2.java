
public class Odp2 {
    public static void main(String[] args) {
        int[] arr = {5, 3, 8, 1, 2};
        int druga = szukaj(arr);
        System.out.println("Druga najwieksza liczba to: " + druga);

    }

    public static int szukaj(int[] arr) {
        int najwieksza = Integer.MIN_VALUE;
        int druga = Integer.MIN_VALUE;

        for (int num : arr) {
            if (num > najwieksza) {
                druga = najwieksza;
                najwieksza = num;
            } else if (num > druga && num != najwieksza) {
                druga = num;
            }
        }

        return druga;
    }

}
