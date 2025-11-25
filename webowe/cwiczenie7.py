def wczytaj():
    try:
        with open("symbole.txt", "+rt") as file:
            linie = file.read().split()
            return linie
    except FileNotFoundError as e:
        print("Plik nie znaleziony")
        
def zadanie1(linie):
    for linia in linie:
        n = len(linia)
        jest = True
        for i in range(n//2):
            if linia[i] != linia[n-i-1]:
                jest = False
        if jest:
            print(linia)
            
def zadanie2(linie):
    for i in range(len(linie) - 2):
        n = len(linie[i])
        for j in range(n - 2):
            znak = linie[i][j]
            jest = True
            for a in range(3):
                for b in range(3):
                    if linie[i+a][j+b] != znak:
                        jest = False
                        break
                if jest == False:
                    break
            if(jest):
                print(f"({i+2}, {j+2})")
                
def zadanie3(linie):
    najwiekszaIlosc = 0
    najwieksze = []
    for i in range(len(linie)):
        ilosc = 0
        for j in range(len(linie[i])):
            if linie[i][j] != '*':
                ilosc = j
                break
        if ilosc > najwiekszaIlosc:
            najwiekszaIlosc = ilosc
            najwieksze.clear()
        if ilosc == najwiekszaIlosc:
            najwieksze.append(linie[i])

    najwiekszaCiag = ""
    najwieksza = 0
    for i in range(len(najwieksze)):
        liczba = naTrojkowy(najwieksze[i])
        if najwieksza < liczba:
            najwiekszaCiag = najwieksze[i]
            najwieksza = liczba
            
    print(najwieksza, najwiekszaCiag)

        
def naTrojkowy(linia):
    suma = 0
    n = len(linia)
    for i in range(n):
        if(linia[n - i - 1] == '+'):
            suma += 3**i
        elif(linia[n - i - 1] == "*"):
            suma += 2*3**i
    return suma
    
def zadanie4(linie):
    suma = 0
    for linia in linie:
        suma += naTrojkowy(linia)
    print(suma)
    print(zDziesietnej(suma))


def zDziesietnej(liczba):
    wynik = ""
    while liczba > 0:
        reszta = liczba % 3
        if reszta == 0:
            wynik = "o" + wynik
        elif reszta == 1:
            wynik = "+" +  wynik
        else:
            wynik = "*" + wynik
        liczba //= 3
    return wynik
    
def zadanie5(linie):
    sety = set(linie)
    if len(linie) == len(sety):
        print("Nie powtarza sie")
    else:
        print("Powtarza sie")

    widziane = set()
    duplikaty = set()
    for linia in linie:
        if linia in widziane:
            duplikaty.add(linia)
        else:
            widziane.add(linia)
    
    print(duplikaty)
    

def main():
    linie = wczytaj()
    zadanie1(linie)
    zadanie2(linie)
    zadanie3(linie)
    zadanie4(linie)
    zadanie5(linie)

if __name__ == "__main__":
    main()