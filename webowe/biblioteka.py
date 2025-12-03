import json

class Ksiazka:
    def __init__(self, ID_ksiazki, tytul, wydawnictwo, ID_autor, rokwydania):
        self.ID_ksiazki = ID_ksiazki
        self.tytul = tytul
        self.wydawnictwo = wydawnictwo
        self.ID_autor = ID_autor
        self.rokwydania = rokwydania
        
class Autor:
    def __init__(self, ID_autor, imie, nazwisko):
        self.ID_autor = ID_autor
        self.imie = imie
        self.nazwisko = nazwisko
        
class Wypozyczajacy:
    def __init__(self, ID_wypozyczajacy, imie, nazwisko, telefon):
        self.ID_wypozyczajacy = ID_wypozyczajacy
        self.imie = imie
        self.nazwisko = nazwisko
        self.telefon = telefon
        self.wypozyczenia = []
        
        
        
class Wypozyczenie:
    def __init__(self, ID_ksiazki, data_wyp, data_odd):
        self.ID_ksiazki = ID_ksiazki
        self.data_wyp = data_wyp
        self.data_odd = data_odd
        
        
class Biblioteka:
    def __init__(self):
        self.ksiazki = []
        self.autorzy = []
        self.wypozyczajacy = []
        
    def zapisz(self):
        try:
            with open("biblioteka.txt", "+wt") as file:
                file.write(json.dumps(self.__dict__)) # albo self.__dict__ pozniej sprawdzic
        except Exception as e:
            print(f"Blad przy zapisie: {e}")
            
    def wczytaj(self):
        try:
            with open("biblioteka.txt", "+rt") as file:
                jsondata = file.read()
                data = json.load(jsondata)
                print(data)
        except Exception as e:
            print(f"Blad przy wczytaniu: {e}")
        
        
biblioteka = Biblioteka()
biblioteka.zapisz()
biblioteka.wczytaj()