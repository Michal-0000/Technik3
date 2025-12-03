class Samochod:
    def __init__(self, marka, model, rocznik, pojemnosc_silnika, przebieg, wlasciciel):
        self.marka = marka
        self.model = model
        self.rocznik = rocznik
        self.pojemnosc_silnika = pojemnosc_silnika
        self.przebieg = przebieg
        self.wlasciciel = wlasciciel
    
    def pokaz_samochod(self):
        return f"{self.marka} {self.model} {self.rocznik}, pojemnosc: {self.pojemnosc_silnika}, przebieg: {self.przebieg}, wlasciciel: {self.wlasciciel}"
    
    def zmien_przebieg(self, ile):
        self.przebieg += ile
        
    def zmien_wlasciciela(self, nowy):
        self.wlasciciel = nowy
        
    def zapisz_samochod(self):
        try:
            with open("pojazdy.txt", "+wt") as file:
                file.write(self.pokaz_samochod())
        except Exception as e:
            print(f"Blad zapisu: {e}")
    
    def zapisz_pojazd(self):
        plik = "samochod.txt"
        if(isinstance(self, Osobowy)): plik = "osobowy.txt"
        
        try:
            with open(plik, "+wt") as file:
                file.write(self.pokaz_samochod())
        except Exception as e:
            print(f"Blad zapisu: {e}")
            
class Osobowy(Samochod):
    def __init__(self, marka, model, rocznik, pojemnosc_silnika, przebieg, wlasciciel, liczba_miejsc):
        super().__init__(marka, model, rocznik, pojemnosc_silnika, przebieg, wlasciciel)
        self.liczba_miejsc = liczba_miejsc
            
    def pokaz_samochod(self):
        return f"{self.marka} {self.model} {self.rocznik}, pojemnosc: {self.pojemnosc_silnika}, przebieg: {self.przebieg}, wlasciciel: {self.wlasciciel}, liczba miejsc: {self.liczba_miejsc}"
    
    def zmien_liczbe_miejsc(self, liczba):
        self.liczba_miejsc = liczba
    
s1 = Samochod("Kia", "Ferrea", 2011, 3, 167009, "Mariusz B")
print(s1.pokaz_samochod())
s1.zmien_przebieg(20010)
s1.zmien_wlasciciela("Ryszard W")
s1.zapisz_pojazd()
s1.zapisz_samochod()

o1 = Osobowy("Mazda", "CX5", 2020, 6, 30105, "Krystyna P", 4)
print(o1.pokaz_samochod())
o1.zmien_liczbe_miejsc(6)
o1.zmien_wlasciciela("Jadzia W")
o1.zmien_przebieg(123123123)
o1.zapisz_pojazd()
