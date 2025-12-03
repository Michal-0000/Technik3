import json

class Ksiazka:
    def __init__(self, ID_ksiazki, tytul, wydawnictwo, ID_autor, rokwydania):
        self.ID_ksiazki = ID_ksiazki
        self.tytul = tytul
        self.wydawnictwo = wydawnictwo
        self.ID_autor = ID_autor
        self.rokwydania = rokwydania
    def pokaz(self):
        print(f"ID: {self.ID_ksiazki}, {self.tytul}, {self.wydawnictwo}, ID autora: {self.ID_autor}, {self.rokwydania}")

    def serialize(self):
        return{
            "ID_ksiazki": self.ID_ksiazki,
            "tytul": self.tytul,
            "wydawnictwo": self.wydawnictwo,
            "ID_autor": self.ID_autor,
            "rokwydania": self.rokwydania
        }
        
class Autor:
    def __init__(self, ID_autor, imie, nazwisko):
        self.ID_autor = ID_autor
        self.imie = imie
        self.nazwisko = nazwisko
    def pokaz(self):
        print(f"ID:{self.ID_autor}, {self.imie}, {self.nazwisko}")
    
    def serialize(self):
        
        
class Wypozyczajacy:
    def __init__(self, ID_wypozyczajacy, imie, nazwisko, telefon):
        self.ID_wypozyczajacy = ID_wypozyczajacy
        self.imie = imie
        self.nazwisko = nazwisko
        self.telefon = telefon
    def pokaz(self):
        print(f"ID: {self.ID_wypozyczajacy}, {self.imie}, {self.nazwisko}, {self.telefon}")
        
        
        
class Wypozyczenie:
    def __init__(self,ID_wypozyczajacego, ID_ksiazki, data_wyp, data_odd):
        self.ID_wypozyczajacego = ID_wypozyczajacego
        self.ID_ksiazki = ID_ksiazki
        self.data_wyp = data_wyp
        self.data_odd = data_odd
    
    def pokaz(self):
        print(f"ID wypozyczajacego: {self.ID_wypozyczajacego}, ID ksiazki: {self.ID_ksiazki}, {self.data_wyp}, {self.data_odd}")
        
        
class Biblioteka:
    def __init__(self):
        self.ksiazki = []
        self.autorzy = []
        self.wypozyczajacy = []
        self.wypozyczenia = []

    def pokaz(self):
        # for ksiazka in self.ksiazki:
        #     ksiazka.pokaz()
        # for autor in self.autorzy:
        #     autor.pokaz()
        # for wypozyczajacy in self.wypozyczajacy:
        #     wypozyczajacy.pokaz()
        # for wypozyczenie in self.wypozyczenia:
        #     wypozyczenie.pokaz()

        for wypozyczenie in self.wypozyczenia:
            wypozyczajacy = next(wypozyczajacy for wypozyczajacy in self.wypozyczajacy if wypozyczajacy.ID_wypozyczajacy == wypozyczenie.ID_wypozyczajacego)
            ksiazka = next(ksiazka for ksiazka in self.ksiazki if ksiazka.ID_ksiazki == wypozyczenie.ID_ksiazki)
            print("Dane wypozyczenia")
            wypozyczenie.pokaz()
            wypozyczajacy.pokaz()
            ksiazka.pokaz()


        
    def zapisz(self):
        try:
            with open("ksiazki.txt", "+wt", encoding="utf-8") as file:
                jsondata = ""
                for ksiazka in self.ksiazki:
                    jsondata += json.dumps(ksiazka.serialize(), indent=4, ensure_ascii=False)
                print(jsondata)
                #print(json.dumps(self.__dict__))
                #file.write(json.dumps(self.__dict__)) # albo self.__dict__ pozniej sprawdzic
        except Exception as e:
            print(f"Blad przy zapisie: {e}")
            
    def wczytaj(self):
        try:
            with open("biblioteka.txt", "+rt", encoding="utf-8") as file:
                jsondata = file.read()
                data = json.load(jsondata)
                print(data)
        except Exception as e:
            print(f"Blad przy wczytaniu: {e}")

    
        
        
biblioteka = Biblioteka()

biblioteka.wypozyczajacy.append(Wypozyczajacy(1, "Jan", "Kowalski", "123456789"))
biblioteka.wypozyczajacy.append(Wypozyczajacy(2, "Maria", "Ann", "989898989"))
biblioteka.wypozyczenia.append(Wypozyczenie(1, 1, "2025-01-2", "2025-04-13"))
biblioteka.ksiazki.append(Ksiazka(1, "Calinka", "NOwa era", 1, 2024))
biblioteka.pokaz()
biblioteka.zapisz()