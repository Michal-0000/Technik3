public class Kod02 {

    void show(String text){
        System.out.println("Tekst: "+text);
    }
    void show(String text, String text2){
        System.out.println("Tekst: "+text+" "+text2);
    }

    void show(int number){
        System.out.println("Liczba: "+number);
    }

    void show(String[] linie){
        for(String line : linie){
            System.out.println(line);
        }
    }

    public static void main(String[] args) {
        
        Kod02 st = new Kod02();
        st.show("Ala ma kota");
        st.show(123);   
        String[] lines = {"Ala ma kota", "Kot ma Ale", "Ala ma psa", "Pies ma Ale"};
        st.show(lines);
        st.show("Ala ma kota", "Kot ma Ale");

    }
}
