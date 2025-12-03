class Osoba:
    def __init__(self, imie, nazwisko, wiek, pesel):
        self.imie = imie
        self.nazwisko = nazwisko
        self.wiek = wiek
        self.__pesel = pesel
        
    def pokaz(self):
        return f"osoba to: {self.imie} {self.nazwisko} i ma {self.wiek} lat."
    
    def zmienwiek(self, ile = 1):
        self.wiek += ile
    
class Uczen(Osoba):
    def __init__(self, imie, nazwisko, wiek, pesel, klasa):
        super().__init__(imie, nazwisko, wiek, pesel)
        self.klasa = klasa
        
    def pokaz(self):
        return f"Uczen to: {self.imie} {self.nazwisko} i ma {self.wiek} lat, z klasy {self.klasa}"
    
    
o1 = Osoba("Adam", "Nowak", 30, 25432352432)
print(o1.pokaz())
o1.zmienwiek(4)
print(o1.pokaz())

u1 = Uczen("Anna", "Kowalska", 12, 24525542244, "IIITPI")
print(u1.pokaz())
u1.zmienwiek()
print(u1.pokaz())

print(isinstance())