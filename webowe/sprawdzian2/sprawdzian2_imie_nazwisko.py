# Michał Rybakowski
# 3TPI
# 22.10.2025
import random as rd

def generuj():
    liczby = [rd.randint(1, 100) for _ in range(1000)]
    try:
        with open("liczby.txt", "+wt") as file:
            for liczba in liczby:
                file.write(str(liczba)+"\n")
    except Exception as e:
        print(f"Błąd obsługi pliku: {e}")
        
def wczytaj():
    try:
        with open("liczby.txt", "+rt") as file:
            linie = file.readlines()
            linie = [int(linia.rstrip("\n")) for linia in linie]
            return linie
    except FileNotFoundError:
        print("Nie znaleziono pliku")
    except Exception as e:
        print(f"Błąd obsługi pliku: {e}")

def suma(liczby):
    sumaLiczb = 0
    for liczba in liczby:
        sumaLiczb += liczba 
    return sumaLiczb
    
def iloczyn(liczby):
    iloczynLiczb = 1
    for liczba in liczby:
        iloczynLiczb *= liczba
    return iloczynLiczb

def srednia(liczby):
    return suma(liczby) / len(liczby)

def maksymalna(liczby):
    curr = liczby[0]
    for liczba in liczby:
        if(liczba > curr):
            curr = liczba
    return curr
            
def minimalna(liczby):
    curr = liczby[0]
    for liczba in liczby:
        if(liczba < curr):
            curr = liczba
    return curr

def najczestsza(liczby):
    wystapienia = {}
    for liczba in liczby:
        if liczba in wystapienia:
            wystapienia[liczba] += 1
        else:
            wystapienia[liczba] = 1
    
    curr = liczby[0]
    for liczba in wystapienia.keys():
       if wystapienia[liczba] > wystapienia[curr]:
           curr = liczba
    return curr

def zapiszStatystyki(statystyki):
    try:
        with open("staty.txt", "+wt") as file:
            for stat in statystyki.keys():
                file.write(f"{stat} - {statystyki[stat]}\n")
    except Exception as e:
        print(f"Błąd obsługi pliku: {e}")

def litery(liczby):
    try:
        with open("kody.txt", "+wt") as file:
            for index, liczba in enumerate(liczby):
                if(liczba in range(65, 90) or liczba in range(97, 122)):
                    file.write(f"{chr(liczba)} - {index}\n")
    except Exception as e:
        print(f"Błąd obsługi pliku: {e}")

def main():
    generuj()
    liczby = wczytaj()
    
    statystyki = {}
    statystyki["suma"] = suma(liczby)
    statystyki["iloczyn"] = iloczyn(liczby)
    statystyki["srednia"] = srednia(liczby)
    statystyki["maksymalna"] = maksymalna(liczby)
    statystyki["minimalna"] = minimalna(liczby)
    statystyki["najczestsza"] = najczestsza(liczby)
        
    zapiszStatystyki(statystyki)
    
    litery(liczby)
    

if __name__ == "__main__":
    main()