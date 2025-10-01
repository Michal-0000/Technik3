
#with open("plik.txt", "+rt") as file:
#    zawartoscpliku = file.read()
#   
#print(zawartoscpliku)
#
#with open("plik.txt", "+rt") as file:
#    linie = [linia.rstrip("\n") for linia in file.readlines() ]
#   
#print(linie)

#with open("plik.txt", "+rt") as file:
#    linie = file.read().splitlines()
#print(linie)

#with open("plik.txt", "+rt") as file:
#    linie = file.readlines()
#    
#    linie = [linia.replace("\n", "") for linia in linie]
#    print(linie)

try: 
    nazwa = "plik.txt"
    with open(nazwa, "+rt") as file:
        tekst = file.read()
        
        print(f"Tekst w pliku: {tekst}")
        
except FileNotFoundError:
    print(f"Nie znaleziono pliku {nazwa}")
except Exception as ex:
    print(f"Wystąpił nieoczekiwany błąd czytania pliku...")
finally:
    print("zakonczylem")
