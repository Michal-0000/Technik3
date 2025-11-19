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
    najwieksza = 0
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
        else:
            najwieksze.append(linie[i])
                
    print(najwieksze)
        
def naTrojkowy(linia):
    suma = 0
    n = len(linia)
    for i in range(n):
        if(linia[n - i] == '+'):
            suma += 3**i
        elif(linia[n - i] == "*"):
            suma += 2*3**i
    return suma
    
            
    
def main():
    linie = wczytaj()
    zadanie1(linie)
    zadanie2(linie)
    zadanie3(linie)

if __name__ == "__main__":
    main()