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
            linie = [int(linia.strip()) for linia in linie]
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
    n = len(sort)
    if n % 2 == 1:
        return sort[n // 2]
    else:
        return (sort[n // 2 - 1] + sort[n // 2]) / 2

def wystapienia(liczby):
    wystapienia = {}
    for liczba in liczby:
        if liczba in wystapienia:
            wystapienia[liczba] += 1
        else:
            wystapienia[liczba] = 1
    return wystapienia

def main():
    plik = input("Podaj nazwę pliku")
    #generuj(plik)
    liczby = pobierz(plik)
    
    print(f"Ilosc: {ilosc(liczby)}")
    print(f"Suma: {suma(liczby)}")
    print(f"Srednia: {srednia(liczby)}")
    print(f"Min i Max: {minmax(liczby)}")
    print(f"Mediana: {mediana(liczby)}")
    print(f"Wystapienia:")
    wyst = wystapienia(liczby)
    for liczba in sorted(wyst):
        print(f"{liczba}: {wyst[liczba]}")
    


if __name__ == "__main__":
    main()