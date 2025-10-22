
class Kalkulator{
    public int dodawanie(int a, int b){
        return a + b;
    }
    public double dodawanie(double a, double b){
        return a + b;
    }
    public int dodawanie(String a, String b){
        return Integer.parseInt(a) + Integer.parseInt(b);
    }

    public int dzielenie(int a, int b){
        if(b != 0) {
            return a / b;
        }else{
            return 0;
        }
    }

    public double dzielenie(double a, double b){
        if(b != 0) {
            return a / b;
        }else{
            return 0;
        }
        
    }
}

public class Kod01 {
    public static void main(String[] args) {
        
        Kalkulator kalkulator = new Kalkulator();

        System.out.println(kalkulator.dodawanie(5, 10));
        System.out.println(kalkulator.dodawanie(5.5, 10.2));
        System.out.println(kalkulator.dodawanie("5", "10"));
        System.out.println(kalkulator.dzielenie(10, 2));
        System.out.println(kalkulator.dzielenie(10.0, 2.0));


    }
}
