import random as rd

lista = [rd.randint(1,100) for i in range(100)]

try: 
    nazwa = "liczby.txt"
    with open(nazwa, "+wt") as file:
        for liczba in lista:
            tekst = file.write(str(liczba)+"\n")
        
        print(f"Tekst w pliku: {tekst}")
        
except FileNotFoundError:
    print(f"Nie znaleziono pliku {nazwa}")
except Exception as ex:
    print(f"Wystąpił nieoczekiwany błąd czytania pliku...")
finally:
    print("zakonczylem")
