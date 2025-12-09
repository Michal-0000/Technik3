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
    
    @staticmethod
    def deserialize(data):
        return Ksiazka(
            data["ID_ksiazki"],
            data["tytul"],
            data["wydawnictwo"],
            data["ID_autor"],
            data["rokwydania"]
        )
        
class Autor:
    def __init__(self, ID_autor, imie, nazwisko):
        self.ID_autor = ID_autor
        self.imie = imie
        self.nazwisko = nazwisko
    def pokaz(self):
        print(f"ID:{self.ID_autor}, {self.imie}, {self.nazwisko}")
    
    def serialize(self):
        return {
            "ID_autor": self.ID_autor,
            "imie": self.imie,
            "nazwisko": self.nazwisko
        }
    
    @staticmethod
    def deserialize(data):
        return Autor(
            data["ID_autor"],
            data["imie"],
            data["nazwisko"]
        )
        
class Wypozyczajacy:
    def __init__(self, ID_wypozyczajacy, imie, nazwisko, telefon):
        self.ID_wypozyczajacy = ID_wypozyczajacy
        self.imie = imie
        self.nazwisko = nazwisko
        self.telefon = telefon

    def pokaz(self):
        print(f"ID: {self.ID_wypozyczajacy}, {self.imie}, {self.nazwisko}, {self.telefon}")

    def serialize(self):
        return {
            "ID_wypozyczajacy": self.ID_wypozyczajacy,
            "imie": self.imie,
            "nazwisko": self.nazwisko,
            "telefon": self.telefon
        }
    
    @staticmethod
    def deserialize(data):
        return Wypozyczajacy(
            data["ID_wypozyczajacy"],
            data["imie"],
            data["nazwisko"],
            data["telefon"]
        )
        

class Wypozyczenie:
    def __init__(self,ID_wypozyczajacego, ID_ksiazki, data_wyp, data_odd):
        self.ID_wypozyczajacego = ID_wypozyczajacego
        self.ID_ksiazki = ID_ksiazki
        self.data_wyp = data_wyp
        self.data_odd = data_odd
    
    def pokaz(self):
        print(f"ID wypozyczajacego: {self.ID_wypozyczajacego}, ID ksiazki: {self.ID_ksiazki}, {self.data_wyp}, {self.data_odd}")

    def serialize(self):
        return {
            "ID_wypozyczajacego": self.ID_wypozyczajacego,
            "ID_ksiazki": self.ID_ksiazki,
            "data_wyp": self.data_wyp,
            "data_odd": self.data_odd
        }
    
    @staticmethod
    def deserialize(data):
        return Wypozyczenie(
            data["ID_wypozyczajacego"],
            data["ID_ksiazki"],
            data["data_wyp"],
            data["data_odd"]
        )
        
        
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

    def serialize(self):
        return {
            "ksiazki": [k.serialize() for k in self.ksiazki],
            "autorzy": [a.serialize() for a in self.autorzy],
            "wypozyczajacy": [w.serialize() for w in self.wypozyczajacy],
            "wypozyczenia": [w.serialize() for w in self.wypozyczenia]
        }

    def deserialize(self, data):
        self.ksiazki = [Ksiazka.deserialize(k) for k in data.get("ksiazki", [])]
        self.autorzy = [Autor.deserialize(a) for a in data.get("autorzy", [])]
        self.wypozyczajacy = [Wypozyczajacy.deserialize(w) for w in data.get("wypozyczajacy", [])]
        self.wypozyczenia = [Wypozyczenie.deserialize(w) for w in data.get("wypozyczenia", [])]
        
    def zapisz(self):
        try:
            with open("biblioteka.txt", "+wt", encoding="utf-8") as file:
                json.dump(self.serialize(), file, indent=4, ensure_ascii=False)
                print("Zapisano pomyslnie")
        except Exception as e:
            print(f"Blad przy zapisie: {e}")
            
    def wczytaj(self):
        try:
            with open("biblioteka.txt", "r", encoding="utf-8") as file:
                data = json.load(file)
                return Biblioteka.deserialize(self, data)
        except Exception as e:
            print(f"Błąd przy wczytaniu: {e}")
            return None

    
        
        
biblioteka = Biblioteka()

# biblioteka.wypozyczajacy.append(Wypozyczajacy(1, "Jan", "Kowalski", "123456789"))
# biblioteka.wypozyczajacy.append(Wypozyczajacy(2, "Maria", "Ann", "989898989"))
# biblioteka.wypozyczenia.append(Wypozyczenie(1, 1, "2025-01-2", "2025-04-13"))
# biblioteka.ksiazki.append(Ksiazka(1, "Calinka", "NOwa era", 1, 2024))
# biblioteka.zapisz()

biblioteka.wczytaj()
biblioteka.pokaz()