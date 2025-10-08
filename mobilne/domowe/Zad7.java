import java.util.Scanner;
import java.util.Arrays;
public class Zad7 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9};

        System.out.print("Podaj liczbę przesunięcia: ");
        int k = scanner.nextInt();

        System.out.println("Przed przesunięciem: " + Arrays.toString(arr));
        przesun(arr, k);
        System.out.println("Po przesunięciu: " + Arrays.toString(arr));

        scanner.close();
    }

    public static void przesun(int[] arr, int k) {
        int n = arr.length;
        k %= n;
        if(k<0) k+=n;

        reverse(arr, 0, n - 1);
        reverse(arr, 0, k - 1);
        reverse(arr, k, n - 1);
    }

    public static void reverse(int[] arr, int start, int end) {
        while (start < end) {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++;
            end--;
        }
    }
}
