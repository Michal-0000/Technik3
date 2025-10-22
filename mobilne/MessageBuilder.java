public class MessageBuilder {
    String buildMessage(String imie){
        return "Witaj, " + imie + "!";
    }
    String buildMessage(String imie, String nazwisko){
        return "Witaj, " + imie + " " + nazwisko + "!";
    }

    String buildMessage(String imie, int wiek){
        return "Witaj, " + imie + "! Masz " + wiek + " lat.";
    }

    public static void main(String[] args) {
        MessageBuilder mb = new MessageBuilder();
        System.out.println(mb.buildMessage("Aniu"));
        System.out.println(mb.buildMessage("Janie", "Kowalski"));
        System.out.println(mb.buildMessage("Aniu", 17));
    }
}
