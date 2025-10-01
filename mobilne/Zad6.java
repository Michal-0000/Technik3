import java.util.Scanner;

public class Zad6 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Podaj rozmiar planszy: ");
        int n = scanner.nextInt();
        int poz = n/2;

        int x = poz;
        int y = poz;

        System.out.println("Pozycja początkowa ("+poz+"/"+poz+")");
        

        while(true){
            System.out.println("Podaj komende g/d/d/p / e-exit");
            String komenda = scanner.nextLine().toLowerCase();

            if(komenda.equals("e")){
                System.out.println("Koniec gry");
                break;
            }

            if(komenda.equals("g")){
                if(x>0) x--;
            }else if(komenda.equals("d")){
                if(x<n) x++;
            }else if(komenda.equals("l")){
                if(y>0) y--;
            }else if(komenda.equals("p")){
                if(y<n) y++;
            }else{
                System.out.println("Nieznana komenda. Podej jeszcz raz");
                continue;
            }

            System.out.println("Twoja pozycja to"+y+"/"+x);
        }
    }
}
