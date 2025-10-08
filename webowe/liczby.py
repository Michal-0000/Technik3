import random as rd

def generuj(plik):
    liczby = [rd.randint(1, 100) for _ in range(1000)]
    try:
        with open(plik, "+wt") as file:
            for liczba in liczby:
                file.write(str(liczba)+"\n")
            
    except Exception as e:
        print(f"blad: {e}")

def pobierz(plik):
    try:
        with open(plik, "+rt") as file:
            linie = file.readlines()
            linie = [linia.replace("\n", "") for linia in linie]
            return linie
            
    except FileNotFoundError:
        print("Nie znaleziono pliku")
    except Exception as e:
        print(f"blad: {e}")
    
def ilosc(liczby):
    return len(liczby)

def suma(liczby):
    suma = 0
    for liczba in liczby:
        suma += liczba
        return suma
    
def srednia(liczby):
    return suma(liczby) / len(liczby)

def minmax(liczby):
    return min(liczby), max(liczby)

def mediana(liczby):
    sort = sorted(liczby)
    return sort[len(liczby) / 2]


def main():
    plik = input("Podaj nazwę pliku")
    generuj(plik)
    liczby = pobierz(plik)
    
    print(f"Ilosc: {ilosc(liczby)}")
    
    


if __name__ == "__main__":
    main()