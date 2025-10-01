public class Zad3 {
    public static void main(String[] args){
        for(int i = 0; i < 1000000; i++){
            if(czyDoskonala(i)){
                System.out.println(i);
            }
        }
    }

    public static boolean czyDoskonala(int liczba){
        if(liczba < 3){
            return false;
        }
        int suma = 0;
        for(int i = 1; i < liczba / 2 + 1; i++){
            if(liczba % i == 0){
                suma += i;
            }
        }
        return liczba == suma;
    }
}
